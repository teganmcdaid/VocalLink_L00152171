// <copyright file="InverseBoolConverterTests.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink.Tests
{
    using VocalLink_L00152171.Converters;

    /// <summary>
    /// This class is used to test the inverse boolean converter.
    /// </summary>
    public class InverseBoolConverterTests
    {
        /// <summary>
        /// This test checks that true is converterted to false.
        /// </summary>
        [Fact]
        public void ConvertTrueReturnsFalse()
        {
            var converter = new InverseBoolConverter();
            var result = converter.Convert(true, null, null, null);
            Assert.False((bool)result);
        }

        /// <summary>
        /// This test checks that false is converted to true.
        /// </summary>
        [Fact]
        public void ConvertFalseReturnsTrue()
        {
            var converter = new InverseBoolConverter();
            var result = converter.Convert(false, null, null, null);
            Assert.True((bool)result);
        }

        /// <summary>
        /// This class is used to test if value is not bool and returns false.
        /// </summary>
        [Fact]
        public void Convert_NonBool_ReturnsFalse()
        {
            var converter = new InverseBoolConverter();
            var result = converter.Convert("not a bool", null, null, null);
            Assert.False((bool)result);
        }
    }
}