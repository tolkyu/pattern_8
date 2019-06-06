using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PizzaQuatroFormatge
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza(new QuatroFormatgeIngredientsFactory());
            Write(pizza.ToString());
            WriteLine($"\tPrice: {pizza.CalculatePrice()}");
            WriteLine();
            pizza = new Pizza(new VeganIngredientsFactory());
            Write(pizza.ToString());
            WriteLine($"\tPrice: {pizza.CalculatePrice()}");
            WriteLine();
            pizza = new Pizza(new NapoletanaIngredientsFactory());
            Write(pizza.ToString());
            WriteLine($"\tPrice: {pizza.CalculatePrice()}");
            WriteLine();
        }
    }
    class Pizza
    {
        private Base pizzaBase;
        private Sauce sauce;
        private Cheese cheese;
        private List<Addon> addons;
        public Pizza(IngredientsFactory factory)
        {
            pizzaBase = factory.createBase();
            sauce = factory.createSauce();
            cheese = factory.createCheese();
            addons = factory.createAddons();
        }
        public double CalculatePrice()
        {
            double price = pizzaBase.Price + sauce.Price + cheese.Price;
            foreach (Addon item in addons)
            {
                price += item.Price;
            }
            return price;
        }
        public override string ToString()
        {
            string tmp = $"\tBase: {pizzaBase.Name}\n\tSauce: {sauce.Name}\n\tCheese: {cheese.Name}\n\tAddons:\n";
            foreach (Addon item in addons)
            {
                tmp += $"\t{item.Name}\n";
            }
            return tmp;
        }
    }
    abstract class IngredientsFactory
    {
        public abstract Base createBase();
        public abstract Sauce createSauce();
        public abstract Cheese createCheese();
        public abstract List<Addon> createAddons();
    }
    class QuatroFormatgeIngredientsFactory : IngredientsFactory
    {
        public override Base createBase()
        {
            return new Standart();
        }
        public override Sauce createSauce()
        {
            return new Tomato();
        }
        public override Cheese createCheese()
        {
            return new Mozarella();
        }
        public override List<Addon> createAddons()
        {
            return new List<Addon>() { new Mushroom(), new Seafood()};
        }
    }
    class VeganIngredientsFactory : IngredientsFactory
    {
        public override Base createBase()
        {
            return new XXL();
        }
        public override Sauce createSauce()
        {
            return new Barbecue();
        }
        public override Cheese createCheese()
        {
            return new Parmesan();
        }
        public override List<Addon> createAddons()
        {
            return new List<Addon>() { new Salami(), new Pepperoni()};
        }
    }
    class NapoletanaIngredientsFactory : IngredientsFactory
    {
        public override Base createBase()
        {
            return new XXL();
        }
        public override Sauce createSauce()
        {
            return new Tomato();
        }
        public override Cheese createCheese()
        {
            return new Ricotta();
        }
        public override List<Addon> createAddons()
        {
            return new List<Addon>() { new Salami(), new Mushroom()};
        }
    }
    abstract class Base
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Standart : Base
    {
        public Standart()
        {
            Name = "Standart";
            Price = 100;
        }
    }
    class XXL : Base
    {
        public XXL()
        {
            Name = "XXL";
            Price = 200;
        }
    }
    abstract class Sauce
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Tomato : Sauce
    {
        public Tomato()
        {
            Name = "Tomato";
            Price = 25;
        }
    }
    class Barbecue : Sauce
    {
        public Barbecue()
        {
            Name = "BBQ";
            Price = 50;
        }
    }
    abstract class Cheese
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Mozarella : Cheese
    {
        public Mozarella()
        {
            Name = "Mozzarella";
            Price = 50;
        }
    }
    class Parmesan : Cheese
    {
        public Parmesan()
        {
            Name = "Parmesan";
            Price = 100;
        }
    }
    class Ricotta : Cheese
    {
        public Ricotta()
        {
            Name = "Ricotta";
            Price = 75;
        }
    }
    abstract class Addon
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Mushroom : Addon
    {
        public Mushroom()
        {
            Name = "Mushroom";
            Price = 50;
        }
    }
    class Seafood : Addon
    {
        public Seafood()
        {
            Name = "Seafood";
            Price = 150;
        }
    }
    class Salami : Addon
    {
        public Salami()
        {
            Name = "Salami";
            Price = 75;
        }
    }
    class Pepperoni : Addon
    {
        public Pepperoni()
        {
            Name = "Pepperoni";
            Price = 100;
        }
    }
}