using System;

namespace MazeWebCore.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor | AttributeTargets.Method)]
    public class Injection : Attribute
    {
    }
}