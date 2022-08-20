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
        public VendingMachine Machine { get; private set; }

        public Manager()
        {
            Machine = new VendingMachine();
            Machine.AddBeverage(new Coffee("Coffee", 1.5));
            Machine.AddBeverage(new Tea("Tea", 1.0));
            Machine.AddBeverage(new HotChocolate("Coco", 2.0));
            Machine.AddBeverage(new Vanila("Vanilla", 3));
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

        /// <summary>
        /// try to pay and preper
        /// </summary>
        /// <param name="tag">the beverage to make</param>
        /// <param name="money">amount of money</param>
        /// <returns>Confirmation message. if exception => error message</returns>
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
