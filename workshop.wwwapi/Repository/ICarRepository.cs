using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        bool GetCar(int id, out Car? car);
        bool AddCar(Car car);
        bool DeleteCar(int id);

    }
}
