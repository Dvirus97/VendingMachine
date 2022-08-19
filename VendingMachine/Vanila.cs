using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine
{
    internal class Vanila : Beverage
    {
        int _vanilaStick;
        public Vanila() : base("vanila", 3)
        { AddPhotoToBtn(new BitmapImage(new Uri(@"ms-appx:///Assets/vanila.jpg"))); }

        protected override string AddIngredient(VendingMachine machine)
        {
            //return $"{machine.UseCups()}\n {machine.UseSugar()}\n {machine.UseMilk()}\n {UseMyIngrediant(ref _vanilaStick, "vanila stick")}. left: {_vanilaStick}\n";
            return String.Format("{0}\n{1}\n{2}\n{3}\n",
                machine.UseCups(),
                machine.UseSugar(),
                machine.UseMilk(),
                UseMyIngrediant(ref _vanilaStick, "Vanila Stick"));
        }
        protected override string AddHotWater()
        {
            return "Add water \n";

        }
        protected override string Stirring()
        {
            return $"Mix clockwise \n";
        }

        public override string ReStockMyIngrediant()
        {
            _vanilaStick = 10;
            return "Refill vanila stick to 10";
        }
    }
}
