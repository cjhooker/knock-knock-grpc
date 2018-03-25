using System;
using Xunit;
using KnockKnockServer;

namespace KnockKnockServer.Tests
{
    public class StringUtilitiesTests
    {
        [Fact]
        public void RemoveDiacriticals_HasAccentedLetter_ConvertedToUnaccented()
        {
            // Arrange
            var withAccents = "Déja";
            var expected = "Deja";

            // Act
            var actual = StringUtilities.RemoveDiacriticals(withAccents);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
