
using DogBoarding.Models;

Dog TestDog = new Dog("John Doe", "Rex", 45.5);
Console.Clear();
Console.WriteLine($"\nOwner: {TestDog.OwnerName} | Dog: {TestDog.DogName} | Weight: {TestDog.DogWeight} lbs");
Console.Write("\nThis Dog was created successfully!");
