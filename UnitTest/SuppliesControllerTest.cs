using MetersCenter.Business.Interfaces;
using MetersCenter.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalUploadingMeterData.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class SuppliesControllerTest
    {
        private readonly SuppliesController controller;
        private readonly Mock<ISuppliesService> supplyService;

        public SuppliesControllerTest()
        {
            supplyService = new Mock<ISuppliesService>();
            controller = new SuppliesController(supplyService.Object);
        }

        #region Test EditSupply
        [Fact]
        public async Task EditSupply_getMethodReturnsSupplyView()
        {
            // Arrange
            int id = 1;
            var supply = new Supplies { Id = 1, UploadDate = DateTime.Now, UploadUsername = "Ibrahim", status = "Done", InspectionStartDate = DateTime.Now, InspectionEndDate = DateTime.Now, InspectorUsername = "", MeterProviderId = 1, Data = null, DocumentName = "xyz", UserId = "mmm" };
            supplyService.Setup(s => s.GetSupplyID(It.IsAny<int>())).ReturnsAsync(supply);

            //Act
            var result = await controller.EditSupply(id);

            // Assert
            var resultView = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Supplies>(resultView.ViewData.Model);
            Assert.Equal(supply, model);
        }

        [Fact]
        public async Task EditSupply_getMethodReturnsEmptyView()
        {
            // Arrange
            int id = 0;
            var supply = new Supplies(); 
            supplyService.Setup(s => s.GetSupplyID(It.IsAny<int>())).ReturnsAsync(supply);

            //Act
            var result = await controller.EditSupply(id);
             
            // Assert
            var resultView = Assert.IsType<ViewResult>(result);
            Assert.Empty(resultView.ViewData);
        }

        #endregion
    }
}
