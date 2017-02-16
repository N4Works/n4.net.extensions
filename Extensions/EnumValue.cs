using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4.Net.Extensions
{
    public class EnumValueAttribute : Attribute
    {
        private string _value;
        public EnumValueAttribute(string value)
        {
            this._value = value;
        }

        public string Value {
            get
            {
                return this._value;
            }
        }
    }
}
