// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilderExtension.cs" company="N4Works">
//   Apache License 2.0
// </copyright>
// <summary>
//   The string builder extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions
{
    using System;
    using System.Text;

    /// <summary>
    /// The string builder extension.
    /// </summary>
    public static class StringBuilderExtension
    {
        /// <summary>
        /// Append a line with separator when the StringBuilder has one or more lines appended.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// A instance of <see cref="StringBuilder"/> appended with the text and separator.
        /// </returns>
        public static StringBuilder AppendLineWithSeparator(this StringBuilder stringBuilder, string text, string separator)
        {
            return stringBuilder.AppendLineWithSeparator(text, separator, 0);
        }

        /// <summary>
        /// Append a line with separator when the StringBuilder has one or more lines appended.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <param name="indentSize">
        /// The indent Size.
        /// </param>
        /// <returns>
        /// A instance of <see cref="StringBuilder"/> appended with the text and separator.
        /// </returns>
        public static StringBuilder AppendLineWithSeparator(this StringBuilder stringBuilder, string text, string separator, int indentSize)
        {
            var textToAppend = string.Format("{0}{1}{2}", new string(' ', indentSize), stringBuilder.LineCount() > 0 ? separator : string.Empty, text);
            return stringBuilder.AppendLine(textToAppend);
        }

        /// <summary>
        /// Retrieves line count of StringBuilder ignoring blank lines.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <returns>
        /// A number of lines.
        /// </returns>
        public static int LineCount(this StringBuilder stringBuilder)
        {
            return stringBuilder.LineCount(true);
        }

        /// <summary>
        /// Retrieves line count of StringBuilder.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <param name="ignoreEmptyLines">
        /// Defines if empty lines will be ignored.
        /// </param>
        /// <returns>
        /// A number of lines.
        /// </returns>
        public static int LineCount(this StringBuilder stringBuilder, bool ignoreEmptyLines)
        {
            var length = stringBuilder.ToString().Split(new[] { Environment.NewLine }, ignoreEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None).Length;

            return length == 0 ? 0 : length;
        }
    }
}