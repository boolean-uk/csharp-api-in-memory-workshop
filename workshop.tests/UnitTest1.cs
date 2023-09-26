using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        CarDataStore.Cars.Clear();
    }
    [Test]
    public void TestGetCars()
    {
        CarDataStore.Cars.Clear();
        Car car = new Car();
        car.Make = "Volkswagen";
        car.Model = "Beetle";
        CarRepository repository = new CarRepository();

        repository.AddCar(car);

        Assert.IsTrue(repository.GetCars().ToList().Count == 1);
    }
    [Test]
    public void TestAddCar()
    {
        CarDataStore.Cars.Clear();
        Car car = new Car();
        car.Make = "Volkswagen";
        car.Model = "Beetle";
        CarRepository repository = new CarRepository();

        repository.AddCar(car);

        Assert.IsTrue(CarDataStore.Cars.Count==1);
    }
    [Test]
    public void DeleteCar()
    {
        CarDataStore.Cars.Clear();
        Car car = new Car();
        car.Make = "Volkswagen";
        car.Model = "Beetle";
        CarRepository repository = new CarRepository();

        repository.AddCar(car);
        Assert.IsTrue(CarDataStore.Cars.Count == 1);
        bool result = repository.DeleteCar(1);
        Assert.IsTrue(CarDataStore.Cars.Count == 0);
        Assert.IsTrue(result);
    }
    [Test]
    public void DeleteACarThatIsNotThere()
    {
        CarRepository repository = new CarRepository();
        bool result = repository.DeleteCar(1);
        Assert.IsFalse(result);
    }
    [Test]
    public void SingleCarTest()
    {
        CarDataStore.Cars.Clear();
        Car car = new Car();
        car.Make = "Volkswagen";
        car.Model = "Beetle";
        CarRepository repository = new CarRepository();
        repository.AddCar(car);
                
        Assert.IsTrue(CarDataStore.Cars.Count == 1);

        bool result = repository.GetCar(1, out Car carFromDataStore);        
        Assert.IsTrue(result);
        Assert.IsTrue(car.Make == carFromDataStore.Make);
        Assert.IsTrue(car.Model == carFromDataStore.Model);


    }

}