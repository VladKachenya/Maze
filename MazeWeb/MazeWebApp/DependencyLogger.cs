using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MazeWebCore.Helpers.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace MazeWebApp
{
    public class DependencyLogger
    {
        private IEnumerable<Type> _markedInterfaces;
        private IEnumerable<Type> _markedClasses;
        private readonly Type _attribyteForRegictration;
        private readonly Type _attribyteForIngection;



        public DependencyLogger(Type attribyteForRegictration = null, Type attribyteForIngection = null)
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
                t.IsInterface && t.GetCustomAttributes().Any(at => at.GetType().GUID == _attribyteForRegictration.GUID));
            _markedClasses = assembliesTypes.Where(t =>
                t.IsClass && t.GetCustomAttributes().Any(at => at.GetType().GUID == _attribyteForRegictration.GUID));
        }

        public void RegesterMarkedTypes(IServiceCollection service)
        {
            var markedClasses = _markedClasses.ToList();
            foreach (var interfaces in _markedInterfaces)
            {
                var childClass =
                    markedClasses.SingleOrDefault(t => t.GetInterfaces().Any(i => i.GUID == interfaces.GUID));
                if (childClass != null)
                {
                    markedClasses.Remove(childClass);
                    //var c = childClass.GetConstructors();

                    service.AddScoped(interfaces, childClass);
                }
            }
            markedClasses.ForEach(el => service.AddScoped(el));
        }

    }
}