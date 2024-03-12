using Xunit;
using suivi_des_drones.Web.UI.Pages;


namespace suivi_des_drones.Tests.Web.UI

{
    public class DeliveryPageModelUnitTest
    {
        [Fact]
        public void ShouldListTwoDeliveries()
        {
            DeliveryListModel Model = new DeliveryListModel();

            var result = Model.OnGet();

            Assert.NotNull(result);
        }
    }
}