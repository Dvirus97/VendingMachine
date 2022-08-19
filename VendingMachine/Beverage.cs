using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine
{
    internal abstract class Beverage
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public BitmapImage photo { get; set; }

        public Beverage(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void AddPhotoToBtn(BitmapImage photo1)
        {
            photo = photo1;
        }

        public string Prepare(VendingMachine machine)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(this.ToString());
            //sb.AppendLine(AddIngredient(machine));
            //sb.AppendLine(AddHotWater());
            //sb.AppendLine(Stirring());
            //return sb.ToString();
            return String.Format("{0}{1}{2}{3}",
               this.ToString(),
               AddIngredient(machine),
               AddHotWater(),
               Stirring());
        }
        protected abstract string AddIngredient(VendingMachine machine);
        protected abstract string AddHotWater();
        protected abstract string Stirring();

        protected string UseMyIngrediant(ref int ingredient, string name, int value = 1)
        {
            if (ingredient <= 0)
            {
                throw (new BeverageOutOfingredients());
            }
            ingredient -= value;
            return $"use {name}";
        }
        public abstract string ReStockMyIngrediant();


        public override string ToString()
        {
            return $"{Name} - {Price:c}";
        }

        public override bool Equals(object obj)
        {
            Beverage other = obj as Beverage;
            if (other == null)
                return false;
            if (this.Name == other.Name)
                return true;
            return false;
        }
    }
}
