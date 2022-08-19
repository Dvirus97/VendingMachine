using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine
{
    internal class Tea : Beverage
    {
        protected int _teaBag;

        public Tea() : base("Tea", 1.0)
        { AddPhotoToBtn(new BitmapImage(new Uri(@"ms-appx:///Assets/tea.jpg"))); }

        protected override string AddIngredient(VendingMachine machine)
        {
            //return $"{machine.UseCups()}\n {machine.UseSugar()}\n {UseMyIngrediant(ref _teaBag, "tea bag")}. left: {_teaBag}\n";
            return String.Format("{0}\n{1}\n{2}\n",
                machine.UseCups(),
                machine.UseSugar(),
                UseMyIngrediant(ref _teaBag, "Tea Bag"));
        }

        protected override string AddHotWater()
        {
            return "Add water. 200 ML \n";

        }
        protected override string Stirring()
        {
            return $"Mix clockwise \n";
        }
        public override string ReStockMyIngrediant()
        {
            _teaBag = 10;
            return "Refill tea bag to 10";
        }
    }
}
