// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReaderExtensionTest.cs" company="N4Works">
//     Apache License 2.0
// </copyright>
// <summary>
// Test class for data reader extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Net.Extensions.Test
{
    using System;
    using System.Data;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Test class for data reader extension.
    /// </summary>
    [TestFixture]
    public class DataReaderExtensionTest
    {
        /// <summary>
        /// Should be possible to check if value is dbnull through the field name.
        /// </summary>
        [Test]
        public void ShouldBePossibleToCheckIfValueIsDBNullThroughTheFieldName()
        {
            var dataReaderMock = new Mock<IDataReader>(MockBehavior.Strict);
            dataReaderMock.Setup(mock => mock.IsDBNull(0)).Returns(true).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal("FieldNameDbNull")).Returns(0).Verifiable();
            dataReaderMock.Setup(mock => mock.IsDBNull(1)).Returns(false).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal("FieldNameNotDbNull")).Returns(1).Verifiable();

            Assert.IsTrue(dataReaderMock.Object.IsDBNull("FieldNameDbNull"));
            Assert.IsFalse(dataReaderMock.Object.IsDBNull("FieldNameNotDbNull"));
        }

        /// <summary>
        /// Should be thrown NotSupportedException when try get a nullable DateTime.
        /// </summary>
        [Test]
        public void ShouldBeThrownNotSupportedExceptionWhenTryGetNullableDateTime()
        {
            var dataReaderMock = new Mock<IDataReader>(MockBehavior.Strict);
            dataReaderMock.Setup(mock => mock.IsDBNull(It.IsAny<int>())).Returns(false).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal(It.IsAny<string>())).Returns(0).Verifiable();

            Assert.Throws<NotSupportedException>(() => dataReaderMock.Object.GetFieldValue<DateTime?>(0));
            Assert.Throws<NotSupportedException>(() => dataReaderMock.Object.GetFieldValue<DateTime?>("FieldName"));
        }

        /// <summary>
        /// Should rethrow the exception when IndexOutOfRangeException was thrown.
        /// </summary>
        [Test]
        public void ShouldRethrowTheExceptionWhenIndexOutOfRangeExceptionWasThrown()
        {
            var dataReaderMock = new Mock<IDataReader>(MockBehavior.Strict);
            dataReaderMock.Setup(mock => mock.IsDBNull(It.IsAny<int>())).Returns(false).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal(It.IsAny<string>())).Returns(0).Verifiable();
            dataReaderMock.Setup(mock => mock[It.IsAny<int>()]).Throws<IndexOutOfRangeException>().Verifiable();
            dataReaderMock.Setup(mock => mock[It.IsAny<string>()]).Throws<IndexOutOfRangeException>().Verifiable();

            Assert.Throws<IndexOutOfRangeException>(() => dataReaderMock.Object.GetFieldValue<string>(0));
            Assert.Throws<IndexOutOfRangeException>(() => dataReaderMock.Object.GetFieldValue<string>("FieldName"));
        }

        /// <summary>
        /// Should return the default value of the type when a different exception of
        /// IndexOutOfRangeException is thrown.
        /// </summary>
        [Test]
        public void ShouldReturnDefaultValueOfTypeWhenDifferentExceptionOfIndexOutOfRangeExceptionIsThrown()
        {
            var dataReaderMock = new Mock<IDataReader>(MockBehavior.Strict);
            dataReaderMock.Setup(mock => mock.IsDBNull(It.IsAny<int>())).Returns(false).Verifiable();
            dataReaderMock.Setup(mock => mock[It.IsAny<int>()]).Throws(new Exception("For test purpose.")).Verifiable();
            dataReaderMock.Setup(mock => mock[It.IsAny<string>()]).Throws(new Exception("For test purpose.")).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal(It.IsAny<string>())).Returns(0).Verifiable();

            var stringValueFromIndex = dataReaderMock.Object.GetFieldValue<string>(0);
            Assert.AreEqual(string.Empty, stringValueFromIndex);

            var intValueFromIndex = dataReaderMock.Object.GetFieldValue<int>(0);
            Assert.AreEqual(0, intValueFromIndex);

            var objectValueFromIndex = dataReaderMock.Object.GetFieldValue<object>(0);
            Assert.AreEqual(null, objectValueFromIndex);

            var stringValueFromName = dataReaderMock.Object.GetFieldValue<string>("FieldName");
            Assert.AreEqual(string.Empty, stringValueFromName);

            var intValueFromName = dataReaderMock.Object.GetFieldValue<int>("FieldName");
            Assert.AreEqual(0, intValueFromName);

            var objectValueFromName = dataReaderMock.Object.GetFieldValue<object>("FieldName");
            Assert.AreEqual(null, objectValueFromName);

            dataReaderMock.Verify(mock => mock[It.IsAny<int>()], Times.Exactly(6));
        }

        /// <summary>
        /// Should return the default value when data value is equals DbNull.
        /// </summary>
        [Test]
        public void ShouldReturnDefaultValueWhenDataValueIsEqualsDbNull()
        {
            var dataReaderMock = new Mock<IDataReader>(MockBehavior.Strict);
            dataReaderMock.Setup(mock => mock.IsDBNull(It.IsAny<int>())).Returns(true).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal(It.IsAny<string>())).Returns(0).Verifiable();

            var stringValueFromIndex = dataReaderMock.Object.GetFieldValue<string>(0);
            Assert.AreEqual(string.Empty, stringValueFromIndex);

            var intValueFromIndex = dataReaderMock.Object.GetFieldValue<int>(0);
            Assert.AreEqual(0, intValueFromIndex);

            var objectValueFromIndex = dataReaderMock.Object.GetFieldValue<object>(0);
            Assert.AreEqual(null, objectValueFromIndex);

            var stringValueFromName = dataReaderMock.Object.GetFieldValue<string>("FieldName");
            Assert.AreEqual(string.Empty, stringValueFromName);

            var intValueFromName = dataReaderMock.Object.GetFieldValue<int>("FieldName");
            Assert.AreEqual(0, intValueFromName);

            var objectValueFromName = dataReaderMock.Object.GetFieldValue<object>("FieldName");
            Assert.AreEqual(null, objectValueFromName);

            dataReaderMock.Verify(mock => mock.IsDBNull(It.IsAny<int>()), Times.Exactly(6));
        }

        /// <summary>
        /// Should trim the string when gets field value.
        /// </summary>
        [Test]
        public void ShouldTrimTheStringWhenGetsFieldValue()
        {
            var dataReaderMock = new Mock<IDataReader>(MockBehavior.Strict);
            dataReaderMock.Setup(mock => mock.IsDBNull(It.IsAny<int>())).Returns(false).Verifiable();
            dataReaderMock.Setup(mock => mock.GetOrdinal(It.IsAny<string>())).Returns(0).Verifiable();
            dataReaderMock.Setup(mock => mock[It.IsAny<string>()]).Returns("  value  ").Verifiable();
            dataReaderMock.Setup(mock => mock[It.IsAny<int>()]).Returns("  value  ").Verifiable();

            var stringValueFromIndex = dataReaderMock.Object.GetFieldValue<string>(0);
            Assert.AreEqual("value", stringValueFromIndex);

            var stringValueFromName = dataReaderMock.Object.GetFieldValue<string>("FieldName");
            Assert.AreEqual("value", stringValueFromName);
        }
    }
}