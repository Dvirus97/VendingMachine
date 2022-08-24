using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine {
    internal class Vanila : Beverage {
        int _vanilaStick;
        public Vanila(string name, double price) : base(name, price) { photo = new BitmapImage(new Uri(@"ms-appx:///Assets/vanila.jpg")); }

        protected override string AddIngredient(VendingMachine machine) {
            return String.Format("{0}\n{1}\n{2}\n{3}\n",
                machine.UseSharedIngrediensts(Ingredients.Cups),
                machine.UseSharedIngrediensts(Ingredients.Milk),
                machine.UseSharedIngrediensts(Ingredients.Sugar),
                UseMyIngrediant(ref _vanilaStick, "Vanila Stick"));
        }
        protected override string AddHotWater() {
            return "Add water \n";
        }
        protected override string Stirring() {
            return $"Mix clockwise \n";
        }

        public override string ReStockMyIngrediant() {
            _vanilaStick = 10;
            return "Refill vanila stick to 10";
        }
    }
}
