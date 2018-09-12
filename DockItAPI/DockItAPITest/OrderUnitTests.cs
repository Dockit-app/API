using NUnit.Framework;
using DockItAPI.Services;
using DockItAPI.Repositories;

namespace DockItAPITest
{
    [TestFixture]
    public class OrderUnitTests
    {
        [TestCase]
        public void OrderSpacingIsRequired()
        {
            var orderSpacing = OrderSpacing.Get();

            int orderSpacingLimit = new OrderSpacingPropertiesRepository().Get().OrderLimit;

            for (var orderCount = 0; orderCount <= orderSpacingLimit + 1; orderCount++) {
                if (orderSpacing.IsOrderSpacingRequired()) {
                    if (orderCount > orderSpacingLimit) {
                        Assert.Pass();
                    }
                }

            }

            Assert.Fail();
        }
    }
}
