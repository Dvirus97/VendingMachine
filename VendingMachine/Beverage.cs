using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine {
    internal abstract class Beverage {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public BitmapImage photo { get; set; }
        /// <summary>
        /// init new beverage. (name, price)
        /// </summary>
        /// <param name="name">name of beverage</param>
        /// <param name="price">price of beverage</param>
        public Beverage(string name, double price) {
            Name = name;
            Price = price;
        }
        /// <summary>
        /// add image to specific button. save image prop
        /// </summary>
        /// <param name="photo1">the photo</param>
        /// 
        /// <summary>
        /// AddIngredient, AddHotWater, Stirring
        /// </summary>
        /// <param name="machine">the machine that preaper</param>
        /// <returns></returns>
        public string Prepare(VendingMachine machine) {
            return String.Format("{0}\n{1}{2}{3}",
               this.ToString(),
               AddIngredient(machine),
               AddHotWater(),
               Stirring());
        }
        protected abstract string AddIngredient(VendingMachine machine);
        protected abstract string AddHotWater();
        protected abstract string Stirring();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredient">the name of the ingredient</param>
        /// <param name="name">string representing of ingredient</param>
        /// <param name="value">how many you need to use</param>
        /// <returns>Confirmation message</returns>
        protected string UseMyIngrediant(ref int ingredient, string name, int value = 1) {
            if (ingredient <= 0) {
                throw (new BeverageOutOfingredientsException($"There is no more {name} for this beverage. \nPlease contact the manager"));
            }
            ingredient -= value;
            return $"use {name}";
        }
        /// <summary>
        /// refill ingredients
        /// </summary>
        /// <returns>Confirmation message</returns>
        public abstract string ReStockMyIngrediant();
        public override string ToString() {
            return $"{Name} - {Price:c}";
        }
        public override bool Equals(object obj) {
            Beverage other = obj as Beverage;
            if (other == null)
                return false;
            if (this.Name == other.Name)
                return true;
            return false;
        }
    }
}
