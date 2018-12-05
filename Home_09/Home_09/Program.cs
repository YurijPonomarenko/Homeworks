using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_09
{
    class Car
    {
        /// <summary>
        /// 
        /// </summary>
        List<Car> cars = new List<Car>();
        public string Mark { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"{Mark} {Model} {Price} $ {Color}";
        }

        /// <summary>
        /// Adding a new object to the list
        /// </summary>
        /// <param name="a"></param>
        public void Ad(Car a)
        {
            cars.Add(a);
        }
        /// <summary>
        /// Select all cars whose price is greater than 10_000
        /// </summary>
        public void SelectMore_10_000() //1
        {
            foreach (var item in cars.Where(car => car.Price > 10_000m))
            {
                Console.WriteLine("\t" + item);
            }
        }
        /// <summary>
        /// Select all cars in red
        /// </summary>
        public void SelectCarsRed()    //2
        {
            foreach (var item in cars.Where(car => car.Color == "Red"))
            {
                Console.WriteLine("\t" + item);
            }
        }
        /// <summary>
        /// Select all cars for a given price and brand of car
        /// </summary>
        /// <param name="price">Car price</param>
        /// <param name="mark">Car mark</param>
        public void SelectPriceAndMark(decimal price, string mark) //3
        {
            foreach (var item in cars.Where(car=>car.Price==price).Where(car=>car.Mark==mark))
            {
                
                Console.WriteLine("\t" + item);
            }
        }
        /// <summary>
        /// Print the sum of the cost of all machines
        /// </summary>
        public void ShowSumAll()   //4
        {
            decimal summ = 0;
            foreach (var item in cars)
            {
                summ += item.Price;
            }
            Console.WriteLine("\t" + summ);
        }
        /// <summary>
        /// Print how many cars are red
        /// </summary>
        public void ShowCountCarRed()  //5
        {
            Console.WriteLine("\t" + cars.Count(car => car.Color == "Red"));
        }
        /// <summary>
        /// Select all cheap cars (price < 5_000) and with the help of the projection select only the make and model of cars
        /// </summary>
        public void SelectCheapCar()   //6
        {
            foreach (var item in cars.Where(car => car.Price < 5000).Select(c => new { c.Mark, c.Model }))
            {
                Console.WriteLine("\t" + item);
            }
        }
        /// <summary>
        /// Select all cars (by price) in the range specified by the user and count how many cars are red, black
        /// </summary>
        /// <param name="tuple">tuple, min range (a) and max (b)</param>
        public void SelectAllCarsToPrice((decimal a, decimal b) tuple)   //7
        {
            var v = cars.Where(car => car.Price > tuple.a && car.Price < tuple.b);
            (int, int) kol = (v.Count(car => car.Color == "Red"), v.Count(car => car.Color == "Black"));
            foreach (var item in v)
            {
                Console.WriteLine("\t" + item);
            }
            Console.WriteLine($"\n\tКрасных: {kol.Item1}");
            Console.WriteLine($"\tЧерных: {kol.Item2}");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Car a = new Car();
            a.Ad(new Car { Mark = "Audi", Model = "TT", Price = 15_000m, Color = "Red" });
            a.Ad(new Car { Mark = "BMW", Model = "525", Price = 5_000m, Color = "Black" });
            a.Ad(new Car { Mark = "ZAZ", Model = "968", Price = 500m, Color = "White" });
            a.Ad(new Car { Mark = "Porshe", Model = "Panamera", Price = 45_000m, Color = "Black" });
            a.Ad(new Car { Mark = "VAZ", Model = "2101", Price = 550m, Color = "Red" });
            a.Ad(new Car { Mark = "Audi", Model = "A8", Price = 10_200m, Color = "Red" });
            a.Ad(new Car { Mark = "BMW", Model = "X5", Price = 90_000m, Color = "Black" });
            a.Ad(new Car { Mark = "Opel", Model = "Astra", Price = 7000m, Color = "White" });
            a.Ad(new Car { Mark = "BMW", Model = "X5", Price = 90_000m, Color = "White" });




            Console.WriteLine("Все машины у которых цена  больше 10_000\n");
            a.SelectMore_10_000();

            Console.WriteLine("\nВсе машины красного цвета\n");
            a.SelectCarsRed();

            Console.WriteLine("\nВсе машины по заданной цене и марке машины\n");
            a.SelectPriceAndMark(90_000m, "BMW");

            Console.WriteLine("\nСумму стоимости всех машин\n");
            a.ShowSumAll();

            Console.WriteLine("\nCколько машин красного цвета\n");
            a.ShowCountCarRed();

            Console.WriteLine("\nДешевые машины (цена < 5_000) только марка и модель машин\n");
            a.SelectCheapCar();

            Console.WriteLine("\nВсе машины(по цене) в диапазоне заданным пользователем \nи посчитайте сколько машин красного, черного цвета\n");
            (decimal, decimal) diapozon = (10000,20000);
            a.SelectAllCarsToPrice(diapozon);
            
            Console.ReadKey();
        }
        
    }
}
