using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using static ConsoleApp6.Program;

namespace ConsoleApp6
{
    internal class Program
    {
        public class Pet
        {
            public string NickName { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public int Energy { get; set; }
            public int Price { get; set; }
            public int MealQuantity { get; set; }


            public void Eat(int mealQuantity)
            {
                if (Energy == 100 || Energy>100) {
                    Console.WriteLine($"\n{NickName}: is full!!!");
                    Energy = 100;

                }
                else {
                    Energy += 10 * mealQuantity;
                    MealQuantity += mealQuantity;
                    Console.WriteLine($"\n{NickName}: has eaten {MealQuantity} meals");

                    if (Energy > 100)
                    {
                        Energy = 100;
                        Console.WriteLine($"\n{NickName}:is full");
                    }
                    Console.WriteLine($"\nEnergy:{Energy}%");
                }

            }
            public void Sleep()
            {
                if(Energy == 100 || Energy > 100)
                {
                    Console.WriteLine($"\n {NickName}: hasn't want to sleep!!!");
                    Energy = 100;
                }
                else if (Energy == 0 || Energy<50)
                {
                    Console.WriteLine($"\n {NickName}: has slept!");
                    Energy += 20;
                    Console.WriteLine($"\nEnergy:{Energy}%");

                }
            }

            public void Play()
            {
                if (Energy > 0)
                {
                    Energy -= 5;
                    Console.WriteLine($"\n{NickName}: has played");
                    Console.WriteLine($"\nEnergy:{Energy}%");
                }
                if (Energy < 50)
                {
                    Console.WriteLine($"\n{NickName}: is sleepy");
                    if (Energy == 0)
                    {
                        Console.WriteLine($"\n{NickName}: has tired to play go to sleep!!!");
                        Console.WriteLine($"\nEnergy:{Energy}%");
                    }
                }
                else
                {
                    Console.WriteLine($"\nEnergy:{Energy}%");

                }

            }

        }

        public class Cat : Pet
        {
            public Cat(string nickname,int age,string gender,int energy,int price,int mealQuantity)
            {
                NickName = nickname;
                Age=age;
                Gender = gender;
                Energy = 50;
                Price = price;
                MealQuantity = 0;
            }
        }

        public class Dog : Pet
        {
            public Dog(string nickname, int age, string gender, int energy, int price, int mealQuantity)
            {
                NickName = nickname;
                Age = age;
                Gender = gender;
                Energy = 50;
                Price = price;
                MealQuantity = 0;
            }
        }


        public class Bird : Pet
        {
            public Bird(string nickname, int age, string gender, int energy, int price, int mealQuantity)
            {
                NickName = nickname;
                Age = age;
                Gender = gender;
                Energy = 40;
                Price = price;
                MealQuantity = 0;
            }
        }

        public class Fish : Pet
        {
            public Fish(string nickname, int age, string gender, int energy, int price, int mealQuantity)
            {
                NickName = nickname;
                Age = age;
                Gender = gender;
                Energy = 20;
                Price = price;
                MealQuantity = 0;
            }
        }

        public class PetShop
        {
            public List<Cat> Cats { get; set;}
            public List<Dog> Dogs { get; set;}
            public List<Bird> Birds { get; set;}
            public List<Fish> Fishes { get; set;}

            public PetShop()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(26, 2);
                Console.WriteLine("\n\t\t\t\t__________________________________");

                Console.SetCursorPosition(26, 1);
                Console.WriteLine("\t\tWelcome To PetShop");
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Cats = new List<Cat>();
                Dogs = new List<Dog>();
                Birds = new List<Bird>();
                Fishes = new List<Fish>();
            }
            
            public void RemoveByNickName(string nickname)
            {
                foreach (var cat in Cats)
                {
                    if (cat.NickName == nickname)
                    {
                        Cats.Remove(cat);
                        Console.WriteLine($"\n{nickname}: has been removed from ~~~PetShop~~~");
                        return;
                    }
                }
                foreach (var dog in Dogs)
                {
                    if (dog.NickName == nickname)
                    {
                        Dogs.Remove(dog);
                        Console.WriteLine($"\n{nickname}: has been removed from ~~~PetShop~~~");
                        return;
                    }
                }
                foreach (var bird in Birds)
                {
                    if (bird.NickName == nickname)
                    {
                        Birds.Remove(bird);
                        Console.WriteLine($"\n {nickname}: has been removed from ~~~PetShop~~~");
                        return;
                    }
                }
                foreach (var fish in Fishes)
                {
                    if (fish.NickName == nickname)
                    {
                        Fishes.Remove(fish);
                        Console.WriteLine($"\n {nickname}: has been removed from ~~~PetShop~~~");
                        return;
                    }
                }
                Console.WriteLine($"\nNo animal with {nickname} was found in PetShop");

            }

            public int TotalQuantityMeal()
            {
                int TotalMealQuantity = 0;
                foreach (var cat in Cats)
                {

                    TotalMealQuantity += cat.MealQuantity;
                }
                foreach (var dog in Dogs)
                {

                    TotalMealQuantity += dog.MealQuantity;
                }
                foreach (var bird in Birds)
                {

                    TotalMealQuantity += bird.MealQuantity;
                }
                foreach (var fish in Fishes)
                {

                    TotalMealQuantity += fish.MealQuantity;
                }
                return TotalMealQuantity;
            }

            public decimal TotalPrice()
            {
                decimal totalPrice = 0;
                foreach(var cat in Cats)
                {
                    totalPrice += cat.Price;
                }
                foreach (var dog in Dogs)
                {
                    totalPrice += dog.Price;
                }
                foreach (var bird in Birds)
                {
                    totalPrice += bird.Price;
                }
                foreach (var fish in Fishes)
                {
                    totalPrice += fish.Price;
                }
                return totalPrice;
            }
            
        }


        static void Main(string[] args)
        {
            PetShop petShop=new PetShop();
            Cat cat = new Cat("Tom", 2, "Male", 20, 10, 2);
            petShop.Cats.Add(cat);

            Dog dog = new Dog("Ben", 3, "Male", 30, 20, 3);
            petShop.Dogs.Add(dog);

            Bird bird = new Bird("Rose", 1, "Female", 20, 10, 5);
            petShop.Birds.Add(bird);

            Fish fish = new Fish("Armor", 1, "Female", 20, 10, 5);
            petShop.Fishes.Add(fish);

            Console.WriteLine("\n\n\nTotal Quantity Meal:" + petShop.TotalQuantityMeal());
            Console.WriteLine("\nTotal Price:" + petShop.TotalPrice());

            
            cat.Eat(2);
            dog.Eat(6);
            bird.Eat(1);
            fish.Eat(2);


            Console.WriteLine("\nTotal Quantity Meal:" + petShop.TotalQuantityMeal());
            Console.WriteLine("\nTotal Price:" + petShop.TotalPrice());

            
            
            Console.WriteLine("\nTotal Quantity Meal:" + petShop.TotalQuantityMeal());
            Console.WriteLine("\nTotal Price:" + petShop.TotalPrice());



            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();

            //petShop.RemoveByNickName("Tom");

            //Console.WriteLine("\nTotal Quantity Meal:" + petShop.TotalQuantityMeal());
            //Console.WriteLine("\nTotal Price:" + petShop.TotalPrice());

            Console.ReadLine();
        }
    }
}