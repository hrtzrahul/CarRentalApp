using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using YYvMiniProject.Buisness.DbContext_;
using YYvMiniProject.Buisness.Models;

namespace YYvMiniProject.Buisness.Repository
{
    public class CarCollectionRepository : ICarCollectionRepository
    {
        private readonly AppDbContext _context;

        public CarCollectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarCollectionModel>> GetAllCarCollections()
        {
            return await _context.carCollections.ToListAsync();
        }

        public async Task<CarCollectionModel> GetCarCollectionById(Guid id)
        {
            return await _context.carCollections.FindAsync(id);
        }

        public async Task<Guid> AddCarCollection(CarCollectionModel carCollection)
        {
            await _context.carCollections.AddAsync(carCollection);
            await _context.SaveChangesAsync();
            return carCollection.Vehicle_Id;
        }

        public void UpdateCarCollection(CarCollectionModel carCollection)
        {
            _context.carCollections.Update(carCollection);
            _context.SaveChanges();
        }

        public async Task<int> DeleteCarCollection(Guid id)
        {
            var carCollection = await _context.carCollections.FindAsync(id);
            if (carCollection != null)
            {
                _context.carCollections.Remove(carCollection);
                await _context.SaveChangesAsync();
            }
            return StatusCodes.Status200OK;
        }
    }
}
