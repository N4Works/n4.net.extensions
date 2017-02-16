using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4.Net.Extensions.Test.Mocks
{
    public enum EnumMock
    {
        [EnumValue("This is the first value")]
        Value1,
        [EnumValue("This is the second value")]
        Value2,
        [EnumValue("This is the third value")]
        Value3,
        Value4
    }
}
