﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetersCenter.Core_;
using MetersCenter.Data;
using MetersCenter.Core_.Contexts;
using Microsoft.EntityFrameworkCore;
using MetersCenter.Business.Interfaces;
using MetersCenter.Core_.Interfaces;

namespace MetersCenter.Business.Services
{
    public class SuppliesService : ISuppliesService
    {
        private readonly ISuppliesRepo _suppliesRepo;
        private readonly IMeterDataRepo _meterDataRepo;
        private readonly IMeterProviderRepo _meterProviderRepo;
        public SuppliesService(ISuppliesRepo repo, IMeterDataRepo meterDataRepo, IMeterProviderRepo meterProviderRepo)
        {
            _suppliesRepo = repo;
            _meterDataRepo = meterDataRepo;
            _meterProviderRepo = meterProviderRepo;
        }

        public async Task<(int ,IEnumerable<MeterData>)> UploadExcelSheet(Stream excelFileStream, string providerName)
        {
            var compId = await _meterProviderRepo.GetProviderIdByName(providerName);
            Supplies supplies = new Supplies()
            {
                status = "New",
                UploadDate = DateTime.Now,
                MeterProviderId = compId
            };
            supplies = await _suppliesRepo.AddSupply(supplies);

            var batchSerials = new List<string>();
            var failedRows = new List<int>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(excelFileStream))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
                int rowCount = worksheet.Dimension.Rows;
                int batchSize = 1000; // Define batch size
                

                for (int row = 2; row <= rowCount; row += batchSize)
                {
                    int endRow = Math.Min(row + batchSize - 1, rowCount);

                    // Process data in batches
                    var batchData = new List<MeterData>();

                    for (int currentRow = row; currentRow <= endRow; currentRow++)
                    {
                        // Validate records
                        if (batchSerials.Contains(worksheet.Cells[currentRow, 1].Value.ToString()))
                        {
                            failedRows.Add(currentRow);
                            continue;
                        }

                        // Extract data from Excel row and create MeterData objects
                        var Meter = new MeterData()
                        {
                            MeterSerial = worksheet.Cells[currentRow, 1].Value.ToString(),
                            MeterPublicKey = worksheet.Cells[currentRow, 2].Value.ToString(),
                            SuppliesId = supplies.Id
                        };

                        batchSerials.Add(Meter.MeterSerial);
                        batchData.Add(Meter);
                    }
                    //SaveBatchData(batchData);
                    await _meterDataRepo.AddMetersRange(batchData);
                }
            }
            var allMetersInRecord = _meterDataRepo.GetMetersByRecordId(supplies.Id);
            supplies.MeterData = allMetersInRecord.ToList();
            await _suppliesRepo.AttachSupply(supplies);

            int successRows = batchSerials.Count();
            return (successRows, allMetersInRecord);
        }
        //private void SaveBatchData(List<Data.MeterData> batch)
        //{
        //    _context.MeterData.AddRangeAsync(batch);
        //    _context.SaveChanges();
        //}

        public async Task<Supplies> AddSupply(Supplies supply)
        {
            return await _suppliesRepo.AddSupply(supply);
        }

        public async Task<Supplies> AttachSupply(Supplies supply)
        {
            return await _suppliesRepo.AttachSupply(supply);
        }

        public async Task<IEnumerable<Supplies>> GetAllSupplies()
        {
            return await _suppliesRepo.GetAllSupplies();
        }

        public async Task<Supplies> EditSupply(Supplies supply)
        {
            return await _suppliesRepo.EditSupply(supply);
        }

        public async Task<IEnumerable<Supplies>> GetSuppliesByID(int id)// can search by compId, serial,..
        {
            return await _suppliesRepo.GetSuppliesByID(id);
        }

        public IEnumerable<Supplies> GetSuppliesByProviderName(string name)
        {
            return _suppliesRepo.GetSuppliesByProviderName(name);
        }

        public async Task<IEnumerable<Supplies>> GetSuppliesByIdAndProviderName(string name, int id)
        {
            return await _suppliesRepo.GetSuppliesByIdAndProviderName(name, id);
        }
    }
}
