using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IRepository _repository;
        public CarsController(IRepository repository)
        {
            this._repository = repository;
        }
        
        [HttpGet]
        public async Task<IResult> GetCars()
        {
            return Results.Ok(_repository.GetCars());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddaCar(Car car)
        {
            if (car != null)
            {
                return _repository.AddCar(car) ? Results.Created($"https://localhost:7242/{car.Id}", car) : Results.NotFound();

            }
            return Results.NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> GetACar(int id)
        {
            try
            {
                var car = _repository.GetCars().FirstOrDefault(c => c.Id == id);
                return car != null ? Results.Ok(car) : Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> DeleteACar(int id)
        {
            try
            {

                if (_repository.GetCars().Any(x => x.Id==id))
                {
                    _repository.DeleteCar(id, out Car? car);

                    return Results.Ok(car);
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.NotFound();
            }
        }


    }
}
