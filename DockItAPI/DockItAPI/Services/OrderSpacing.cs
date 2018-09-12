using DockItAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DockItAPI.Services
{
    internal class OrderSpacing
    {
        private static OrderSpacing instance;
        private readonly int orderLimit;
        private readonly int orderTimePeriodMinutes;
        private readonly int orderSpacingMinutes;
        private int orderCount = 0;
        private DateTime timeLimit = DateTime.Now;

        private OrderSpacing() {

            var propertiesRepo = new OrderSpacingPropertiesRepository();
            orderLimit = propertiesRepo.Get().OrderLimit;
            orderTimePeriodMinutes = propertiesRepo.Get().OrderTimePeriodMinutes;
            orderSpacingMinutes = propertiesRepo.Get().OrderSpacingMinutes;
        }


        public static OrderSpacing Get() {
            if (instance == null) {
                instance = new OrderSpacing();
            }
            return instance;
        }

        public bool IsOrderSpacingRequired() {

            DateTime currentTime = new DateTime();

            orderCount += 1;

            if (currentTime > timeLimit)
            {
                timeLimit = currentTime.AddMinutes(orderTimePeriodMinutes);
                orderCount = 0;
            }

            if (orderCount > orderLimit)
            {
                return true;
            }

            return false;
        }

        public DateTime OffsetOrderTime(DateTime currentMinutes) {

            var adjustedOrderSpacingMinutes = (orderCount % orderLimit) * orderSpacingMinutes;

            currentMinutes.AddMinutes(orderSpacingMinutes);

            return currentMinutes;

        }
    }
}
