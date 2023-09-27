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
        Repository repository = new Repository();

        bool result = repository.AddCar(car);

        Assert.IsTrue(repository.GetCars().ToList().Count == 1);


    }
    [Test]
    public void TestAddCar()
    {
        CarDataStore.Cars.Clear();
        Car car = new Car();
        car.Make = "Volkswagen";
        car.Model = "Beetle";
        Repository repository = new Repository();

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
        Repository repository = new Repository();

        repository.AddCar(car);
        Assert.IsTrue(CarDataStore.Cars.Count == 1);
        bool result = repository.DeleteCar(1, out Car? deletedCar);
        Assert.IsTrue(CarDataStore.Cars.Count == 0);
        Assert.IsTrue(result);
        Assert.IsNotNull(deletedCar);
    }
    [Test]
    public void DeleteACarThatIsNotThere()
    {
        Repository repository = new Repository();
        bool result = repository.DeleteCar(1, out Car? car);
        Assert.IsFalse(result);
        Assert.IsNull(car);
    }
    [Test]
    public void SingleCarTest()
    {
        CarDataStore.Cars.Clear();
        Car newCar = new Car();
        newCar.Make = "Volkswagen";
        newCar.Model = "Beetle";
        Repository repository = new Repository();
        repository.AddCar(newCar);
                
        Assert.IsTrue(CarDataStore.Cars.Count == 1);

        var addedCar = repository.GetCar(1);        
        Assert.IsTrue(newCar.Make==addedCar.Make);
        Assert.IsTrue(newCar.Model == addedCar.Model);
        Assert.IsNotNull(addedCar);



    }

}