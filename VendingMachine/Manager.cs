using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.System;
using Windows.UI.Xaml.Media;

namespace VendingMachine
{
    internal class Manager // orginaize all drinks
    {
        public VendingMachine Machine { get; set; }

        public Manager()
        {
            Machine = new VendingMachine();
            Machine.AddBeverage(new Coffee());
            Machine.AddBeverage(new Tea());
            Machine.AddBeverage(new HotChocolate());
            Machine.AddBeverage(new Vanila());
        }

        /// <summary>
        /// <br>call <see cref="VendingMachine.ReStockIngredients()"/> </br>
        /// <br>Restock all ingredients to full (10)</br>
        /// </summary>
        /// <returns>Confirmation message</returns>
        public string ReStockIngredients()
        {
            return Machine.ReStockIngredients();
        }

        public string Preper(int tag, double money)
        {
            try
            {
                return $"{Machine.Pay(tag, money)} \n{Machine.Prepare(tag)}";
            }
            catch (NotEnoughMoney err)
            {
                return $"{err.Message}";
            }
            catch (BeverageOutOfingredients err)
            {
                return $"{err.Message}";
            }
        }
    }
}
