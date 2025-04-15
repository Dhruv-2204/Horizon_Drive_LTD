namespace MsTesting1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var expected = 5;
            var a = 2;
            var b = 3;
            // Act
            var result = a + b;
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
