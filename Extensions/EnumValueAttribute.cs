// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumValueAttribute.cs" company="N4Works">
//     Apache License 2.0
// </copyright>
// <summary>
// the EnumValueAttribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions
{
    using System;

    /// <summary>
    /// Class attribute for EnumValue.
    /// </summary>
    public class EnumValueAttribute : Attribute
    {
        private string _value;

        /// <summary>
        /// Initializes <see cref="EnumValueAttribute"/> attribute.
        /// </summary>
        /// <param name="value">The value.</param>
        public EnumValueAttribute(string value)
        {
            this._value = value;
        }

        /// <summary>
        /// Get the value from enum.
        /// </summary>
        public string Value {
            get
            {
                return this._value;
            }
        }
    }
}
