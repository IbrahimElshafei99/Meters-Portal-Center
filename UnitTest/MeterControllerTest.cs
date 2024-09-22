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
    public class MeterControllerTest
    {
        private readonly MeterController controller;
        private readonly Mock<IMeterService> service;
        public MeterControllerTest()
        {
            service = new Mock<IMeterService>();
            controller = new MeterController(service.Object);
        }

        #region Test FilterMeters
        [Fact]
        //[InlineData ("rtyui",1)]
        public async Task FilterMeters_returnsNullInRedirectToController()
        {
            // Arrange 
            string serial = "dfghj";
            int id = 1;
            service.Setup(s => s.GetMetersBySerial(It.IsAny<string>(), It.IsAny<int>()))
                   .Verifiable();

            // Act
            var result = await controller.FilterMeters(serial, id);

            // Assert
            var redirectActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectActionResult.ControllerName);
            

        }

        [Fact]
        public async Task FilterMeters_RedirectToActionResultSuccessfully()
        {
            // Arrange 
            string serial = "dfghj";
            int id = 1;
            service.Setup(s => s.GetMetersBySerial(It.IsAny<string>(), It.IsAny<int>()))
                   .Verifiable();

            // Act
            var result = await controller.FilterMeters(serial, id);

            // Assert
            var redirectActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Null(redirectActionResult.ControllerName);
            Assert.Equal("MetersList", redirectActionResult.ActionName);


        }

        [Fact]
        public async Task FilterMeters_RedirectToActionResultFailed()
        {
            // Arrange 
            string serial = "dfghj";
            int id = 1;
            service.Setup(s => s.GetMetersBySerial(It.IsAny<string>(), It.IsAny<int>()))
                   .Verifiable();

            // Act
            var result = await controller.FilterMeters(serial, id);

            // Assert
            var redirectActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Null(redirectActionResult.ControllerName);
            Assert.NotEqual("", redirectActionResult.ActionName);

        }

        #endregion

        #region Test MetersList
        [Fact]
        public async Task MetersList_returnsListOfMetersAndNotEmptyView()
        {
            // Arrange
            List<MeterData> meters = new List<MeterData>
            {
                new MeterData { Id =1, MeterPublicKey="mmm", MeterSerial="m1", SuppliesId=3},
                new MeterData { Id =2, MeterPublicKey="bbb", MeterSerial="m2", SuppliesId=3},
                new MeterData { Id =3, MeterPublicKey="xyz", MeterSerial="m3", SuppliesId=3}
            };
            int supId = 3;

            service.Setup(s => s.GetMetersByRecordId(It.IsAny<int>())).ReturnsAsync(meters);

            //Act 
            var result = await controller.MetersList(supId, 1);

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model);

        }

        [Fact]
        public async Task MetersList_returnsNotFoundView()
        {
            // Arrange
            List<MeterData> meters = null;
            int supId = 3;

            service.Setup(s => s.GetMetersByRecordId(It.IsAny<int>())).ReturnsAsync(meters);

            //Act 
            var result = await controller.MetersList(supId, 1);

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", viewResult.ViewName);

        }
        #endregion
    }
}
