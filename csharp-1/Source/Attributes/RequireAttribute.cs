using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
    class RequireAttribute : Attribute
    {
        public RequireAttribute()
        {

        }
    }
}
