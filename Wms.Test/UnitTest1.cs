using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;

namespace Wms.Test
{
    public class Tests : DependencyInjection
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var packingListDataService = MainServiceProvider.GetRequiredService<IPackingListDataService>();

            var orderId = 272;
            var packingListNo = 186;

            var packingList = await packingListDataService.GetPackingListByOrderIdAsync(orderId: orderId, packingListNo: $"{packingListNo}");

            Assert.IsNotNull(packingList);

            var orderId1 = 101;

            var packingList1 = await packingListDataService.GetPackingListByOrderIdAsync(orderId: orderId1);

            Assert.IsNotNull(packingList1);
        }

        [Test]
        public async Task Test2()
        {
            var lineupDataService = MainServiceProvider.GetRequiredService<ILineupDataService>();

            await lineupDataService.CancelDeliveryAsync(
                lineupId: 542,
                userId: 1);
        }
    }
}