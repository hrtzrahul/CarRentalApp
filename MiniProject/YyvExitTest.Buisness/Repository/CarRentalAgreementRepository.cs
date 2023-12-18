using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using YYvMiniProject.Buisness.DbContext_;
using YYvMiniProject.Buisness.Models;

namespace YYvMiniProject.Buisness.Repository
{
    public class CarRentalAgreementRepository
    {
        private readonly AppDbContext _context;

        public CarRentalAgreementRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarRentalAgreementModel>> GetAllRentalAgreementsAsync()
        {
            return await _context.carRentalAgreements.ToListAsync();
        }

        public void CarRentalAgreement(CarRentalAgreementModel agreement)
        {
            
            agreement.RentalDuration = (int)(agreement.RentalEndDate - agreement.RentalStartDate).TotalDays;
            var car =  _context.carCollections.FirstOrDefault(c => c.Vehicle_Id == agreement.CarId);

            if (car == null)
            {
                throw new InvalidOperationException("Car not found.");
            }
            agreement.TotalCost = agreement.RentalDuration * car.RentalPrice;

            var newAgreement = new CarRentalAgreementModel()
            {
                CarId = agreement.CarId,
                UserEmail = agreement.UserEmail,
                RentalStartDate = agreement.RentalStartDate,
                RentalEndDate = agreement.RentalEndDate,
                RentalDuration = agreement.RentalDuration,
                TotalCost = agreement.TotalCost,
            };

            _context.carRentalAgreements.Add(newAgreement);
            _context.SaveChangesAsync();
        }

        public async Task<CarRentalAgreementModel> getCarRentalAgreementById(int id)
        {
            return await _context.carRentalAgreements.FindAsync(id);
        }
        public void EditAgreement(CarRentalAgreementModel model)
        {
            
            var existingModel = _context.carRentalAgreements.Find(model.Id);
            model.RentalDuration = (int)(model.RentalEndDate - model.RentalStartDate).TotalDays;
            var car = _context.carCollections.FirstOrDefault(c => c.Vehicle_Id == model.CarId);
            model.TotalCost = model.RentalDuration * car.RentalPrice;
            if (existingModel != null)
            {
                //existingModel.CarId = model.CarId;
                existingModel.RentalStartDate = model.RentalStartDate;
                existingModel.RentalEndDate = model.RentalEndDate;
                existingModel.RentalDuration = model.RentalDuration;
                existingModel.TotalCost = model.TotalCost;


                _context.carRentalAgreements.Update(existingModel);
                _context.SaveChanges();
            }
        }

        public void isReturned (CarRentalAgreementModel isReturn)
        {
            isReturn.IsReturnRequested = true;
            _context.Update(isReturn);
            _context.SaveChanges();
        }
        public void deleteAgreemet(CarRentalAgreementModel carRentalAgreement)
        {
            _context.Remove(carRentalAgreement);
            _context.SaveChanges();
        }

    }
}
