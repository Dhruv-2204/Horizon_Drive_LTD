//using Xunit;

//namespace xUnitTesting1
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void Test1()
//        {

//        }
//    }
//}

using Xunit;
using Horizon_Drive_LTD;
using System.Collections.Generic;
using Horizon_Drive_LTD.DataStructure;

namespace xUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void InsertAndSearch_ReturnsCorrectValue()
        {
            // Arrange
            var table = new HashTable<string, string>(5);

            // Act
            table.Insert("username", "tisha123");
            var result = table.Search("username");

            // Assert
            Assert.Equal("tisha123", result);
        }
    }
}
