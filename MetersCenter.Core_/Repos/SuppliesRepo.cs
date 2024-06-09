﻿using MetersCenter.Core_.Contexts;
using MetersCenter.Core_.Interfaces;
using MetersCenter.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Core_.Repos
{
    public class SuppliesRepo : ISuppliesRepo
    {
        private readonly ApplicationDbContext _context;
        public SuppliesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplies> AddSupply(Supplies supply)
        {
            await _context.Supplies.AddAsync(supply);
            _context.SaveChanges();
            return supply;
        }

        public async Task<Supplies> AttachSupply(Supplies supply)
        {
            _context.Supplies.Attach(supply);
            _context.SaveChanges();
            return supply;
        }

        public async Task<IEnumerable<Supplies>> GetAllSupplies()
        {
            return await _context.Supplies.Include(x=>x.MeterProviders).ToListAsync();
        }

        public async Task<Supplies> EditSupply(Supplies supply)
        {
            Supplies newSupply = await _context.Supplies.FirstOrDefaultAsync(x=>x.Id == supply.Id);
            if (newSupply != null)
            {
                if(supply.status == "In Progress")
                {
                    newSupply.InspectionStartDate = DateTime.Now;
                    newSupply.status = supply.status;
                }
                if(supply.status == "Done")
                {
                    newSupply.InspectionEndDate = DateTime.Now;
                    newSupply.status = supply.status;
                }
                newSupply.InspectorUsername = supply.InspectorUsername;

                _context.Supplies.Update(newSupply);
                _context.SaveChanges();
                return newSupply;
            }
            return supply;
        }

        public async Task<Supplies> GetSupplyID(int id)// can search by compId, serial,..
        {
            return await _context.Supplies.Include(x=>x.MeterProviders).FirstOrDefaultAsync(x=> x.Id == id);
        }
        public IEnumerable<Supplies> GetSuppliesByProviderName(string name)
        {
            return _context.Supplies.Include(x=> x.MeterProviders).Where(x => x.MeterProviders.Name.Contains(name)).ToList();
        }
        public async Task<IEnumerable<Supplies>> GetSuppliesByIdAndProviderName(string name, int id)
        {
            if(id == 0 && name != "")
            {
                return await _context.Supplies.Include(x => x.MeterProviders).Where(x => x.MeterProviders.Name.Contains(name)).ToListAsync();
            }
            else
            {
                return await _context.Supplies.Where(x => x.Id == id).ToListAsync();
            }
        }

        //public async Task<IEnumerable<Supplies>> GetSuppliesBySerial(int serial)
        //{
        //    //return await _context.Supplies.Where(x => x.Id == id).ToListAsync();
        //}
    }
}
