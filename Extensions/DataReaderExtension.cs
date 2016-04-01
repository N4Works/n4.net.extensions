// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReaderExtension.cs" company="N4Works">
//   Apache License 2.0
// </copyright>
// <summary>
//   The  extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions
{
    using System;
    using System.Data;

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
            if (dataReader.IsDBNull(index))
            {
                return typeof(TType) == typeof(string) ? (dynamic)string.Empty : default(TType);
            }

            try
            {
                var retorno = dataReader[index];
                if (typeof(TType) == typeof(string))
                {
                    retorno = dataReader[index].ToString().Trim();
                }

                return (TType)Convert.ChangeType(retorno, typeof(TType));
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
                return default(TType);
            }
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
            if (dataReader[fieldName] == DBNull.Value)
            {
                return type == typeof(string) ? string.Empty : GetDefaultValue(type);
            }

            if (typeof(DateTime?) == type)
            {
                throw new NotSupportedException(string.Format("The field {0} is of an unsupported type.", fieldName));
            }

            try
            {
                var fieldValue = dataReader[fieldName];
                if (type == typeof(string))
                {
                    fieldValue = dataReader[fieldName].ToString().Trim();
                }

                return Convert.ChangeType(fieldValue, type);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
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
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}