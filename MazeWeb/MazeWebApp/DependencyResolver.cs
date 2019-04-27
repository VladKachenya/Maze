using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MazeWebCore.Helpers.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace MazeWebApp
{
    public class DependencyResolver
    {
        private IEnumerable<Type> _markedInterfaces;
        private IEnumerable<Type> _markedClasses;
        private readonly Type _attribyteForRegictration;
        private readonly Type _attribyteForIngection;



        public DependencyResolver(Type attribyteForRegictration = null, Type attribyteForIngection = null)
        {
            if (attribyteForRegictration == null)
            {
                attribyteForRegictration = typeof(ForRegistration);
            }
            _attribyteForRegictration = attribyteForRegictration;

            if (attribyteForIngection == null)
            {
                attribyteForIngection = typeof(Injection);
            }
            _attribyteForIngection = attribyteForIngection;
        }

        public void Initialization()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var assemblies = Directory.GetFiles(appPath).Where(el => new FileInfo(el).Extension == ".dll");
            List<Type> assembliesTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                assembliesTypes.AddRange(Assembly.LoadFrom(assembly).GetTypes());
            }

            _markedInterfaces = assembliesTypes.Where(t =>
                t.IsInterface && t.GetCustomAttributes().Any(at => at.GetType() == _attribyteForRegictration));
            _markedClasses = assembliesTypes.Where(t =>
                t.IsClass && t.GetCustomAttributes().Any(at => at.GetType() == _attribyteForRegictration));
        }

        public void RegesterMarkedTypes(IServiceCollection service)
        {
            var markedClasses = _markedClasses.ToList();
            foreach (var interfaces in _markedInterfaces)
            {
                var childClass =
                    markedClasses.SingleOrDefault(t => t.GetInterfaces().Any(i => i == interfaces));
                if (childClass != null)
                {
                    markedClasses.Remove(childClass);

                    service.AddScoped(interfaces, x => TypeFactory(x, childClass));
                }
            }
            markedClasses.ForEach(c => service.AddScoped(x => TypeFactory(x, c)));
        }

        private object TypeFactory(IServiceProvider serviceProvider, Type childClass)
        {
            // ctor injections
            var constructor = childClass.GetConstructors().Single(c =>
                c.GetCustomAttributes().Any(a => a.GetType() == _attribyteForIngection));
            var ctorParams = constructor.GetParameters().Select(pi => pi.ParameterType);
            var ctorInjection = new List<Object>();
            foreach (var type in ctorParams)
            {
                ctorInjection.Add(serviceProvider.GetService(type));
            }
            var resyltEntity = constructor.Invoke(ctorInjection.ToArray());

            // property injections
            var markedPropeties = childClass.GetProperties(BindingFlags.Public | BindingFlags.Instance).
                Where(p => p.GetCustomAttributes().Any(a => a.GetType() == _attribyteForIngection));
            foreach (var property in markedPropeties)
            {
                var properyEntity = serviceProvider.GetService(property.PropertyType);
                property.SetMethod.Invoke(resyltEntity, new [] {properyEntity});
            }

            // setter injections
            var markedMethods = childClass.GetMethods(BindingFlags.Public | BindingFlags.Instance).
                Where(p => p.GetCustomAttributes().Any(a => a.GetType() == _attribyteForIngection));
            foreach (var method in markedMethods)
            {
                var methodsParams = method.GetParameters().Select(pi => pi.ParameterType);
                var methodInjection = new List<object>();
                foreach (var type in methodsParams)
                {
                    methodInjection.Add(serviceProvider.GetService(type));
                }
                method.Invoke(resyltEntity, methodInjection.ToArray());
            }

            return resyltEntity;
        }
    }
}