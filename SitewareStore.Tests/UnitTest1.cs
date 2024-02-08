namespace SitewareStore.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            decimal productValue = 10;
            int cutQuantity = 3;
            int productQuantity = 13;

            int rest = productQuantity % cutQuantity;
            int result = productQuantity / cutQuantity;

            Assert.True(rest > 0);
        }
    }
}