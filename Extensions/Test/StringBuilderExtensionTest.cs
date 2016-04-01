// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilderExtensionTest.cs" company="N4Works">
//     Apache License 2.0
// </copyright>
// <summary>
// Tests for string builder extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions.Test
{
    using N4.Net.Extensions;
    using NUnit.Framework;
    using System;
    using System.Text;

    /// <summary>
    /// Tests for string builder extension.
    /// </summary>
    [TestFixture(Category = "General", Description = "A set of tests for StringBuilder extension.")]
    public class StringBuilderExtensionTest
    {
        /// <summary>
        /// Test: Should add separator when second line is added.
        /// </summary>
        [Test(Description = "Should add a separator when second line is added.")]
        public void ShouldAddSeparatorWhenSecondLineIsAdded()
        {
            var stringBuilder1 = new StringBuilder();
            stringBuilder1.AppendLineWithSeparator("First line.", "_");
            stringBuilder1.AppendLineWithSeparator("Second line.", "_");
            Assert.AreEqual(string.Format("First line.{0}_Second line.{0}", Environment.NewLine), stringBuilder1.ToString());

            var stringBuilder2 = new StringBuilder();
            stringBuilder2.AppendLineWithSeparator("First line.", "_", 4);
            stringBuilder2.AppendLineWithSeparator("Second line.", "_", 4);
            Assert.AreEqual(string.Format("    First line.{0}    _Second line.{0}", Environment.NewLine), stringBuilder2.ToString());

            var stringBuilder3 = new StringBuilder();
            stringBuilder3.AppendLineWithSeparator("First line.", "_");
            stringBuilder3.AppendLineWithSeparator("Second line.", "_", 4);
            Assert.AreEqual(string.Format("First line.{0}    _Second line.{0}", Environment.NewLine), stringBuilder3.ToString());

            var stringBuilder4 = new StringBuilder();
            stringBuilder4.AppendLineWithSeparator("First line.", "_", 4);
            stringBuilder4.AppendLineWithSeparator("Second line.", "_");
            Assert.AreEqual(string.Format("    First line.{0}_Second line.{0}", Environment.NewLine), stringBuilder4.ToString());
        }

        /// <summary>
        /// Test: Should ignore all blank lines when count method is called.
        /// </summary>
        [Test(Description = "Should ignore all blank lines when count method is called.")]
        public void ShouldIgnoreAllBlankLinesWhenCountMethodIsCalled()
        {
            var stringBuilder = new StringBuilder();
            Assert.AreEqual(0, stringBuilder.LineCount());
            stringBuilder.AppendLine();
            Assert.AreEqual(0, stringBuilder.LineCount());
            stringBuilder.AppendLine();
            Assert.AreEqual(0, stringBuilder.LineCount());
            stringBuilder.AppendLine("First line.");
            Assert.AreEqual(1, stringBuilder.LineCount());
            stringBuilder.AppendLine();
            Assert.AreEqual(1, stringBuilder.LineCount());
            stringBuilder.AppendLine("Second line.");
            Assert.AreEqual(2, stringBuilder.LineCount());
        }

        /// <summary>
        /// Test: Shouldn't add a separator when first line is added.
        /// </summary>
        [Test(Description = "Shouldn't add a separator when first line is added.")]
        public void ShouldntAddSeparatorWhenFirstLineIsAdded()
        {
            var stringBuilder1 = new StringBuilder();
            stringBuilder1.AppendLineWithSeparator("First line.", "_");
            Assert.AreEqual(string.Format("First line.{0}", Environment.NewLine), stringBuilder1.ToString());

            var stringBuilder2 = new StringBuilder();
            stringBuilder2.AppendLineWithSeparator("First line.", "_", 4);
            Assert.AreEqual(string.Format("    First line.{0}", Environment.NewLine), stringBuilder2.ToString());
        }

        /// <summary>
        /// Test: Shouldn't ignore blank lines when count method is called with false parameter.
        /// </summary>
        [Test(Description = "Shouldn't ignore blank lines when count method is called with false parameter.")]
        public void ShouldntIgnoreBlankLinesWhenCountMethodIsCalledWithFalseParameter()
        {
            var stringBuilder = new StringBuilder();
            Assert.AreEqual(1, stringBuilder.LineCount(false));
            stringBuilder.AppendLine();
            Assert.AreEqual(2, stringBuilder.LineCount(false));
            stringBuilder.AppendLine();
            Assert.AreEqual(3, stringBuilder.LineCount(false));
            stringBuilder.AppendLine("First line.");
            Assert.AreEqual(4, stringBuilder.LineCount(false));
            stringBuilder.AppendLine();
            Assert.AreEqual(5, stringBuilder.LineCount(false));
            stringBuilder.AppendLine("Second line.");
            Assert.AreEqual(6, stringBuilder.LineCount(false));
        }
    }
}