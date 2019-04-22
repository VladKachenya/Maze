using System;

namespace MazeWebCore.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor)]
    public class Injection : Attribute
    {
    }
}