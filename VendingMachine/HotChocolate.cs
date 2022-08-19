using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine
{
    internal class HotChocolate : Beverage
    {
        protected int _chocolatePowder;

        public HotChocolate() : base("Chocolate", 2.0)
        { AddPhotoToBtn(new BitmapImage(new Uri(@"ms-appx:///Assets/choco.jpg"))); }

        protected override string AddIngredient(VendingMachine machine)
        {
            //return $"{machine.UseCups()}\n {machine.UseSugar()}\n  {machine.UseMilk()}\n {UseMyIngrediant(ref _chocolatePowder, "chocolate powder")}. left: {_chocolatePowder}\n";
            return String.Format("{0}\n{1}\n{2}\n{3}\n",
                machine.UseCups(),
                machine.UseSugar(),
                machine.UseMilk(),
                UseMyIngrediant(ref _chocolatePowder, "Chocolate Powder"));
        }

        protected override string AddHotWater()
        {
            return "Add water. 160 ML \n";

        }
        protected override string Stirring()
        {
            return $"Mix clockwise \n";
        }
        public override string ReStockMyIngrediant()
        {
            _chocolatePowder = 10;
            return $"Refill chocolate powder to 10";
        }
    }
}
