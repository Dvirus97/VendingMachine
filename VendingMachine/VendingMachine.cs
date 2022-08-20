using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using static VendingMachine.MainPage;

namespace VendingMachine
{
    internal class VendingMachine
    {
        private int _cups;
        private int _sugar;
        private int _milk;
        private int _countBev = 0;

        private List<Beverage> Beverages;
        /// <summary>
        /// { <see langword="get;"/> } The list of Beverage form the VendingMachine. 
        /// </summary>
        public List<Beverage> listOfBeverage { get => Beverages; }
        /// <summary>
        /// { <see langword="get;"/> }  How many types of Beverage are there 
        /// </summary>
        public int CountBev { get { return _countBev; } }

        public VendingMachine()
        {
            Beverages = new List<Beverage>();
        }
        /// <summary>
        /// preper a specific beverage.
        /// </summary>
        /// <param name="tag">the beverage to preper</param>
        /// <returns>The drink. </returns>
        public string Prepare(int tag)
        {
            return Beverages[tag].Prepare(this);
        }

        /// <summary>
        ///  pay function
        /// </summary>
        /// <param name="tag">the specific beverage</param>
        /// <param name="money">money from user</param>
        /// <returns>Confirmation message</returns>
        /// <exception cref="NotEnoughMoney">If enterd less money from the cost of the beverage</exception>
        public string Pay(int tag, double money)
        {
            if (money < Beverages[tag].Price)
                throw new NotEnoughMoney();

            return String.Format("You have successfully paid\nTake your change: {0:c}",
                money - Beverages[tag].Price);
        }
        /// <summary>
        /// Add beverage to the machine list.
        /// </summary>
        /// <param name="b">the beverage to add</param>
        public void AddBeverage(Beverage b)
        {
            if (b == null)
                return;
            Beverages.Add(b);
            _countBev++;
        }
        /// <summary>
        /// delete beverage from the machine list.
        /// </summary>
        /// <param name="b">the beverage to delete</param>
        public void DeleteBeverage(Beverage b)
        {
            if (b == null)
                return;
            for (int i = 0; i < Beverages.Count; i++)
            {
                if (Beverages[i].Equals(b))
                {
                    Beverages.Remove(Beverages[i]);
                    _countBev--;
                }
            }
        }

        /// <summary>
        /// Restock all ingredients to full (10)
        /// </summary>
        /// <returns>Confirmation message</returns>
        public string ReStockIngredients()
        {
            StringBuilder sb = new StringBuilder();
            _cups = _milk = _sugar = 10;
            foreach (Beverage b in Beverages)
            {
                sb.AppendLine(b.ReStockMyIngrediant());
            }
            sb.AppendLine("cups, milk and sugar also refill to 10");
            return sb.ToString();
        }

        public string UseCups(int value = 1)
        {
            if (_cups - value < 0)
            {
                throw new BeverageOutOfingredients();
            }
            _cups -= value;
            return $"using {value} cup.";// left {_cups}";

        }
        public string UseSugar(int value = 1)
        {
            if (_sugar - value < 0)
            {
                throw new BeverageOutOfingredients();
            }
            _sugar -= value;
            return $"using {value} sugar";//. left {_sugar}";

        }
        public string UseMilk(int value = 1)
        {
            if (_milk - value < 0)
            {
                throw new BeverageOutOfingredients();
            }
            _milk -= value;
            return $"using {value} milk";//. left {_milk}";

        }

        /// <summary>
        /// add image to specific button
        /// </summary>
        /// <param name="tag">the beverage num</param>
        /// <returns>image to use</returns>
        public BitmapImage AddPhotoToBtn(int tag)
        {
            return Beverages[tag].photo;
        }
    }
}
