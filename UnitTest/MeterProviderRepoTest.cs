using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetersCenter.Core_.Contexts;
using Moq;

namespace UnitTest
{
    public class MeterProviderRepoTest
    {
        private readonly Mock<ApplicationDbContext> _context;
        public MeterProviderRepoTest()
        {
            _context = new Mock<ApplicationDbContext>();
        }

        #region Test GetProviderNameById
        /*[Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async GetProviderNameById_haveData(int id)
        {
            List<string> providers = new List<string> { "", ""};

        }*/

        #endregion
    }
}
