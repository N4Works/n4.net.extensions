// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilderExtensionTest.cs" company="N4Works">
//   Apache License 2.0
// </copyright>
// <summary>
//   Tests for string builder extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions.Test
{
    using System.Text;

    using N4.Net.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// Tests for string builder extension.
    /// </summary>
    [TestFixture(Category = "General", Description = "A set of tests for StringBuilder extension.")]
    public class StringBuilderExtensionTest
    {
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