using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.376395,-84.913185,Taco Bell Adairsvill...", -84.913185)]
        [InlineData("33.22997,-86.805275,Taco Bell Alabaste..." , -86.805275)]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...", -84.10353)]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill..", -86.217115)]
        [InlineData("32.92496,-85.961342,Taco Bell Alexander Cit...", -85.961342)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("32.92496,-85.961342,Taco Bell Alexander Cit...", 32.92496)]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill..", 34.280205)]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.376395,-84.913185,Taco Bell Adairsvill...", 34.376395)]
        [InlineData("33.22997,-86.805275,Taco Bell Alabaste..." , 33.22997)]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...", 31.570771)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            
            var actual = tacoParser.Parse(line);
            
            Assert.Equal(expected, actual.Location.Latitude);
        }
            

    }
}
