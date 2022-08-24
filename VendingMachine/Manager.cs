using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.System;
using Windows.UI.Xaml.Media;

namespace VendingMachine {
    internal class Manager // orginaize all drinks
    {
        private readonly string Password = "1234";
        public VendingMachine Machine { get; private set; }
        public Manager() {
            Machine = new VendingMachine();
            Machine.AddBeverage(new Vanila("Vanilla", 3));
            Machine.AddBeverage(new HotChocolate("Coco", 2.0));
            Machine.AddBeverage(new Tea("Tea", 1.0));
            Machine.AddBeverage(new Coffee("Coffee", 1.5));
        }

        /// <summary>
        /// <br>call <see cref="VendingMachine.ReStockIngredients()"/> </br>
        /// <br>Restock all ingredients to full (10)</br>
        /// </summary>
        /// <returns>Confirmation message</returns>
        public string ReStockIngredients() {
            return Machine.ReStockIngredients();
        }

        /// <summary>
        /// try to pay and preper
        /// </summary>
        /// <param name="tag">the beverage to make</param>
        /// <param name="money">amount of money</param>
        /// <returns>Confirmation message. if exception => error message</returns>
        public string Preper(int tag, double money) {
            try {
                return String.Format("{0}\n{1}",
                    Machine.Pay(tag, money),
                    Machine.Prepare(tag));
            }
            catch (NotEnoughMoneyException err) {
                return err.Message;
            }
            catch (BeverageOutOfingredientsException err) {
                return err.Message;
            }
        }
        /// <summary>
        /// check if Manager Password is correct
        /// </summary>
        /// <param name="pass">the input password</param>
        /// <returns><see langword="true"/> if correct. <see langword="false"/> if not</returns>
        public bool ValidPassword(string pass) {
            if (String.IsNullOrEmpty(pass))
                return false;
            if (pass == Password)
                return true;
            return false;
        }
    }
}
