using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        /// <summary>
        /// Get all cars from the DataStore
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetCars()
        {
            return CarDataStore.Cars;
        }

        /// <summary>
        /// Add a car to the Data Store
        /// </summary>
        /// <param name="car">Car instance to be added</param>
        /// <returns></returns>
        public bool AddCar(Car car)
        {
            
            if(car!=null)
            {
                int id = CarDataStore.Cars.Count== 0 ? 1 : CarDataStore.Cars.Max(x => x.Id) + 1;
                car.Id = id;
                CarDataStore.Cars.Add(car);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes a car from the CarDataStore
        /// </summary>
        /// <param name="id">id of car to delete</param>
        /// <returns></returns>
        public bool DeleteCar(int id, out Car? car)
        {
            car = CarDataStore.Cars.FirstOrDefault(x => x.Id == id);
            return CarDataStore.Cars.Remove(car);
        }

        /// <summary>
        /// Gets a car from the CarDataStore
        /// </summary>
        /// <param name="id">id of car to find</param>
        /// <param name="car">out param of Car found</param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            var car = CarDataStore.Cars.FirstOrDefault(c => c.Id == id);
            if(car!=null)
            {
                return car;
            }
            return car;
        }
    }
}
