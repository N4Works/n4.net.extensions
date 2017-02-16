// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensionTest.cs" company="N4Works">
//     Apache License 2.0
// </copyright>
// <summary>
// Test class for enum extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions.Test
{
    using N4.Net.Extensions.Test.Mocks;
    using NUnit.Framework;

    /// <summary>
    /// Test class for enum extension.
    /// </summary>
    [TestFixture]
    public class EnumExtensionTest
    {
        /// <summary>
        /// Should be possible to read a value from an enum using EnumValue class.
        /// </summary>
        /// <param name="enumMock">Enum for test.</param>
        /// <param name="expectedValue">Expected value.</param>
        [Test]
        [TestCase(EnumMock.Value1, "This is the first value")]
        [TestCase(EnumMock.Value2, "This is the second value")]
        [TestCase(EnumMock.Value3, "This is the third value")]
        [TestCase(EnumMock.Value4, "Value4")]
        public void ShouldReturnExpectedValueFromEnum(EnumMock enumMock, string expectedValue)
        {
            Assert.AreEqual(expectedValue, enumMock.GetValue());
        }
    }
}
