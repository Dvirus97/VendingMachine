﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingMachine
{
    internal class Coffee : Beverage
    {
        protected int _coffeeBean;

        public Coffee() : base("Coffee", 1.5)
        {
            AddPhotoToBtn(new BitmapImage(new Uri(@"ms-appx:///Assets/coffee.png")));
        }


        protected override string AddIngredient(VendingMachine machine)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(machine.UseCups());
            //sb.AppendLine(machine.UseSugar());
            //sb.AppendLine(machine.UseMilk());
            //sb.AppendLine(UseMyIngrediant(ref _coffeeBean, "coffee beans"));

            return String.Format("{0}\n{1}\n{2}\n{3}\n",
                machine.UseCups(),
                machine.UseSugar(),
                machine.UseMilk(),
                UseMyIngrediant(ref _coffeeBean, "coffee beans"));
        }

        protected override string AddHotWater()
        {
            return "Add water. 150 ML\n";

        }
        protected override string Stirring()
        {
            return $"Mix clockwise \n";
        }

        public override string ReStockMyIngrediant()
        {
            _coffeeBean = 10;
            return "Refill coffee beans to 10";
        }
    }
}