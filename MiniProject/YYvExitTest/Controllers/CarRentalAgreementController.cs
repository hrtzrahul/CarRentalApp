using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YYvMiniProject.Buisness.Models;
using YYvMiniProject.Buisness.Repository;

namespace YYvMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalAgreementController : ControllerBase
    {
        private readonly CarRentalAgreementRepository _repository;

        public CarRentalAgreementController(CarRentalAgreementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("getCarAgreement")]

        public async Task<IActionResult> GetRentalAgreements()
        {
            var agreements = await _repository.GetAllRentalAgreementsAsync();
            return Ok(agreements);
        }

        [HttpPost]
        [Route("AddCarAgreement")]
        public IActionResult AddCarRentalAgreement([FromBody]CarRentalAgreementModel agreement)
        {
            _repository.CarRentalAgreement(agreement);
            return Ok();
        }
        [HttpPut]
        [Route("EditAgreement")]

        public void editAgreement([FromBody] CarRentalAgreementModel carRentalAgreementModel)
        {
            _repository.EditAgreement(carRentalAgreementModel);
        }
        [HttpPut]
        [Route("isReturn/{Id}")]

        public async Task< IActionResult> isReturn(int Id)
        {
            var agreement = await _repository.getCarRentalAgreementById(Id);
            if (agreement != null)
            {
                _repository.isReturned(agreement);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("deleteAgreement/{Id}")]

        public async Task<IActionResult> deleteAgreement(int Id)
        {
            var agreement = await _repository.getCarRentalAgreementById(Id);
            if(agreement != null)
            {
                _repository.deleteAgreemet(agreement);
                return Ok();
            }
            else { return NotFound(); }
        }




    }
}
