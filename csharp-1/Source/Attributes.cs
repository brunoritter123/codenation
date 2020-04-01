using System;

namespace Source
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class RequiredArgumentAttribute : Attribute
    {
        public RequiredArgumentAttribute(object[] arguments = null)
        {
            Console.WriteLine(this);
            foreach (var arg in arguments)
            {
                if (arg is null)
                {
                    throw new ArgumentNullException(arg.ToString());
                }
            }
        }
    }
}
