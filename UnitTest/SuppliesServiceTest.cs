using MetersCenter.Business.Interfaces;
using MetersCenter.Business.Services;
using MetersCenter.Core_.Interfaces;
using MetersCenter.Data;
using Moq;
using Xunit.Sdk;
using System.Threading.Tasks;
namespace UnitTest
{
    public class SuppliesServiceTest
    {
        private readonly ISuppliesService service;
        private readonly Mock<ISuppliesRepo> _suppliesRepo;
        private readonly Mock<IMeterDataRepo> _meterDataRepo;
        private readonly Mock<IMeterProviderRepo> _meterProviderRepo;

        public SuppliesServiceTest()
        {
            // Moq SuppliesService constructor
            _suppliesRepo = new Mock<ISuppliesRepo>();
            _meterProviderRepo = new Mock<IMeterProviderRepo>();    
            _meterDataRepo = new Mock<IMeterDataRepo>();

            // Init SuppliesService
            service = new SuppliesService(_suppliesRepo.Object, _meterDataRepo.Object, _meterProviderRepo.Object);
        }

        #region Test GetAllSupplies 

        [Fact]
        public async void GetAllSupplies_haveDataNotReturnNull()
        {
            var suppliedData = new List<Supplies>
            {
                new Supplies { Id = 1, UploadDate=DateTime.Now, UploadUsername="Ibrahim", status="Done", InspectionStartDate=DateTime.Now,InspectionEndDate=DateTime.Now,InspectorUsername="",MeterProviderId=1, Data= null, DocumentName="xyz", UserId= "mmm"},
                new Supplies { Id = 2, UploadDate=DateTime.Now, UploadUsername="Ahmed", status="In Progress", InspectionStartDate=DateTime.Now,InspectionEndDate=DateTime.Now,InspectorUsername="",MeterProviderId=1, Data= null, DocumentName="abc", UserId= "nnn"},
            };

            // Moq ISuppliesRepo => GetAllSupplies
            _suppliesRepo.Setup(repo => repo.GetAllSupplies()).ReturnsAsync(suppliedData);

            var result = await service.GetAllSupplies();

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAllSupplies_haveDataReturnNull()
        {
            List<Supplies> suppliedData = null;

            // Moq ISuppliesRepo => GetAllSupplies
            _suppliesRepo.Setup(repo => repo.GetAllSupplies()).ReturnsAsync(suppliedData);

            var result = await service.GetAllSupplies();

            Assert.Null(result);
        }

        [Fact]
        public async void GetAllSupplies_haveDataReturnEmpty()
        {
            List<Supplies> suppliedData = new List<Supplies> { };

            // Moq ISuppliesRepo => GetAllSupplies
            _suppliesRepo.Setup(repo => repo.GetAllSupplies()).ReturnsAsync(suppliedData);

            var result = await service.GetAllSupplies();

            Assert.Empty(result);
        }

        [Fact]
        public async void GetAllSupplies_haveDataCount2()
        {
            var suppliedData = new List<Supplies>
            {
                new Supplies { Id = 1, UploadDate=DateTime.Now, UploadUsername="Ibrahim", status="Done", InspectionStartDate=DateTime.Now,InspectionEndDate=DateTime.Now,InspectorUsername="",MeterProviderId=1, Data= null, DocumentName="xyz", UserId= "mmm"},
                new Supplies { Id = 2, UploadDate=DateTime.Now, UploadUsername="Ahmed", status="In Progress", InspectionStartDate=DateTime.Now,InspectionEndDate=DateTime.Now,InspectorUsername="",MeterProviderId=1, Data= null, DocumentName="abc", UserId= "nnn"},
            };

            // Moq ISuppliesRepo => GetAllSupplies
            _suppliesRepo.Setup(repo => repo.GetAllSupplies()).ReturnsAsync(suppliedData);

            var result = await service.GetAllSupplies();

            Assert.Equal(2,result.Count());
        }
        #endregion


        #region Test GetSupplyID
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(0)]
        public async void GetSupplyID_haveData(int id)
        {
            var suppliedData = new List<Supplies>
            {
                new Supplies { Id = 1, UploadDate=DateTime.Now, UploadUsername="Ibrahim", status="Done", InspectionStartDate=DateTime.Now,InspectionEndDate=DateTime.Now,InspectorUsername="",MeterProviderId=1, Data= null, DocumentName="xyz", UserId= "mmm"},
                new Supplies { Id = 2, UploadDate=DateTime.Now, UploadUsername="Ahmed", status="In Progress", InspectionStartDate=DateTime.Now,InspectionEndDate=DateTime.Now,InspectorUsername="",MeterProviderId=1, Data= null, DocumentName="abc", UserId= "nnn"},
            };
            _suppliesRepo.Setup(repo => repo.GetSupplyID(It.IsAny<int>()))
                         .ReturnsAsync((int id) => id == 1 ? suppliedData[0]
                                                    : id == 2? suppliedData[1]
                                                    : null);

            if(id == 1)
            {
                var result = await service.GetSupplyID(id);
                Assert.Equal(suppliedData[0], result);
            }
            else if(id == 2) {
                var result = await service.GetSupplyID(id);
                Assert.Equal(suppliedData[1], result);
            }
            else
            {
                var result = await service.GetSupplyID(id);
                Assert.Null(result);
            }
        }
        #endregion

        #region Test GetProviderNameBySupplyId
        [Theory]
        [InlineData(1, "Elsewedy", null, "Elsewedy")]
        [InlineData(2, null, "Something went wrong", "Something went wrong")]
        public async void GetProviderNameBySupplyId_returnsExciptionMesage(int id, string returnedData, string exceptionMessage, string outputMsg)
        {
            if(exceptionMessage == null)
            {
                _meterProviderRepo.Setup(repo=> repo.GetProviderNameById(id)).ReturnsAsync(returnedData);
            }
            else
            {
                _meterProviderRepo.Setup(repo => repo.GetProviderNameById(id)).ThrowsAsync(new Exception(exceptionMessage));
            }


            var result = await service.GetProviderNameBySupplyId(id);
            Assert.Equal(outputMsg, result);
        }

        [Fact]
        public async void GetProviderNameBySupplyId_haveExceptionHandling()
        {
            var id= 1;
            var exceptionMessage = "Something went wrong";

            _meterProviderRepo.Setup(repo => repo.GetProviderNameById(id))
                              .ThrowsAsync(new Exception(exceptionMessage));

            var result = await service.GetProviderNameBySupplyId(id);
            Assert.Equal($"Error: {exceptionMessage}", result);
            
        }

        #endregion

    }
}