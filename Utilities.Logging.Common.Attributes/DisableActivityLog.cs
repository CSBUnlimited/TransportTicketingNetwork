using System;

namespace Utilities.Logging.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class DisableActivityLog : Attribute
    {
    }
}
