// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtension.cs" company="N4Works">
//     Apache License 2.0
// </copyright>
// <summary>
// The <see cref="Enum"/> extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace N4.Net.Extensions
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="Enum"/> extension.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get a enum value from <see cref="EnumValueAttribute"/> attribute.
        /// </summary>
        /// <param name="obj">Enum to read the value.</param>
        /// <returns>The value.</returns>
        public static string GetValue(this Enum obj)
        {
            EnumValueAttribute enumValue = (EnumValueAttribute) obj.GetType().GetField(obj.ToString()).GetCustomAttributes(typeof(EnumValueAttribute), false).FirstOrDefault();
            return enumValue != null ? enumValue.Value: obj.ToString();
        }
    }
}
