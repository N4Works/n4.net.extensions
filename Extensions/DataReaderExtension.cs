// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReaderExtension.cs" company="N4Works">
//     Apache License 2.0
// </copyright>
// <summary>
// The extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions
{
    using System;
    using System.Data;
    using System.Diagnostics;

    /// <summary>
    /// The <see cref="IDataReader"/> extension.
    /// </summary>
    public static class DataReaderExtension
    {
        /// <summary>
        /// Get the field value by index.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <typeparam name="TType">
        /// The type of return.
        /// </typeparam>
        /// <returns>
        /// The field value.
        /// </returns>
        public static TType GetFieldValue<TType>(this IDataReader dataReader, int index)
        {
            return (TType)dataReader.GetFieldValue(typeof(TType), index);
        }

        /// <summary>
        /// Get the field value by name.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="fieldName">
        /// The field name.
        /// </param>
        /// <returns>
        /// The field value.
        /// </returns>
        public static object GetFieldValue(this IDataReader dataReader, Type type, string fieldName)
        {
            return dataReader.GetFieldValue(type, dataReader.GetOrdinal(fieldName));
        }

        /// <summary>
        /// Get the field value by name.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="fieldIndex">
        /// The field index.
        /// </param>
        /// <returns>
        /// The field value.
        /// </returns>
        public static object GetFieldValue(this IDataReader dataReader, Type type, int fieldIndex)
        {
            if (dataReader.IsDBNull(fieldIndex))
            {
                return GetDefaultValue(type);
            }

            if (typeof(DateTime?) == type)
            {
                throw new NotSupportedException(string.Format("The type of field is unsupported."));
            }

            try
            {
                var fieldValue = dataReader[fieldIndex];
                if (type == typeof(string))
                {
                    fieldValue = dataReader[fieldIndex].ToString().Trim();
                }

                return Convert.ChangeType(fieldValue, type);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // If not a IndexOutOfRangeException, returns default value of type.
                Debug.WriteLine(ex);
                return GetDefaultValue(type);
            }
        }

        /// <summary>
        /// Get the field value by name.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        /// <param name="fieldName">
        /// The field name.
        /// </param>
        /// <typeparam name="TType">
        /// The type of return.
        /// </typeparam>
        /// <returns>
        /// The field value.
        /// </returns>
        public static TType GetFieldValue<TType>(this IDataReader dataReader, string fieldName)
        {
            return (TType)dataReader.GetFieldValue(typeof(TType), fieldName);
        }

        /// <summary>
        /// The get default value.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GetDefaultValue(Type type)
        {
            if (type == typeof(string))
            {
                return string.Empty;
            }

            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}