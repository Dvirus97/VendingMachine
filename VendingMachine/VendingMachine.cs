using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using static VendingMachine.MainPage;

namespace VendingMachine {
    internal class VendingMachine {
        private int _cups;
        private int _sugar;
        private int _milk;
        private const int MaxBev = 5;

        private List<Beverage> Beverages;
        /// <summary>
        /// { <see langword="get;"/> } The list of Beverage form the VendingMachine. 
        /// </summary>
        public List<Beverage> listOfBeverage { get => Beverages; }
        /// <summary>
        /// { <see langword="get;"/> }  How many types of Beverage are there 
        /// </summary>
        public int CountBev { get => Beverages.Count; }
        public Beverage this[int i] {
            get {
                if (i > Beverages.Count || i < 0)
                    throw new IndexOutOfRangeException();
                return Beverages[i];
            }
        }

        public VendingMachine() {
            Beverages = new List<Beverage>();
        }
        /// <summary>
        /// preper a specific beverage.
        /// </summary>
        /// <param name="tag">the beverage to preper</param>
        /// <returns>The drink. </returns>
        public string Prepare(int tag) {
            return Beverages[tag].Prepare(this);
        }

        /// <summary>
        ///  pay function
        /// </summary>
        /// <param name="tag">the specific beverage</param>
        /// <param name="money">money from user</param>
        /// <returns>Confirmation message</returns>
        /// <exception cref="NotEnoughMoneyException">If enterd less money from the cost of the beverage</exception>
        public string Pay(int tag, double money) {
            if (money < Beverages[tag].Price)
                throw new NotEnoughMoneyException("You Don't Have Enough money. can't continue.");

            return String.Format("You have successfully paid\nTake your change: {0:c}",
                money - Beverages[tag].Price);
        }
        /// <summary>
        /// Add beverage to the machine list.
        /// </summary>
        /// <param name="bev">the beverage to add</param>
        public void AddBeverage(Beverage bev) {
            if (bev == null)
                throw new ArgumentNullException();
            if (listOfBeverage.Contains(bev))
                return;
            if (listOfBeverage.Count > MaxBev)
                throw new Exception("there is no more place in this machine.");
            Beverages.Add(bev);
        }
        /// <summary>
        /// delete beverage from the machine list.
        /// </summary>
        /// <param name="b">the beverage to delete</param>
        public void DeleteBeverage(string name) {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            for (int i = 0 ; i < Beverages.Count ; i++) {
                if (Beverages[i].Name == name) {
                    Beverages.Remove(Beverages[i]);
                }
            }
        }

        /// <summary>
        /// Restock all ingredients to full (10)
        /// </summary>
        /// <returns>Confirmation message</returns>
        public string ReStockIngredients() {
            StringBuilder sb = new StringBuilder();
            _cups = _milk = _sugar = 10;
            foreach (Beverage b in Beverages) {
                sb.AppendLine(b.ReStockMyIngrediant());
            }
            sb.AppendLine("cups, milk and sugar also refill to 10");
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">enum of the ingredient</param>
        /// <param name="value">how many to use</param>
        /// <returns>string representation for using ingredient</returns>
        /// <exception cref="BeverageOutOfingredientsException"></exception>
        public string UseSharedIngrediensts(Ingredients name, int value = 1) {
            string message = "There is no more ingredients for this beverage. \nPlease contact the manager";
            switch (name) {
                case Ingredients.Cups:
                    if (_cups - value < 0) {
                        throw new BeverageOutOfingredientsException(message);
                    }
                    _cups -= value;
                    return $"using {value} cup.";
                case Ingredients.Sugar:
                    if (_sugar - value < 0) {
                        throw new BeverageOutOfingredientsException(message);
                    }
                    _sugar -= value;
                    return $"using {value} sugar";
                case Ingredients.Milk:
                    if (_milk - value < 0) {
                        throw new BeverageOutOfingredientsException(message);
                    }
                    _milk -= value;
                    return $"using {value} milk";
                default:
                    return "there is not such ingredient";
            }
        }

        //public string UseCups(int value = 1)
        //{
        //    if (_cups - value < 0)
        //    {
        //        throw new BeverageOutOfingredients();
        //    }
        //    _cups -= value;
        //    return $"using {value} cup.";// left {_cups}";

        //}
        ////shared
        //public string UseSugar(int value = 1)
        //{
        //    if (_sugar - value < 0)
        //    {
        //        throw new BeverageOutOfingredients();
        //    }
        //    _sugar -= value;
        //    return $"using {value} sugar";//. left {_sugar}";

        //}
        //public string UseMilk(int value = 1)
        //{
        //    if (_milk - value < 0)
        //    {
        //        throw new BeverageOutOfingredients();
        //    }
        //    _milk -= value;
        //    return $"using {value} milk";//. left {_milk}";

        //}

        /// <summary>
        /// add image to specific button
        /// </summary>
        /// <param name="tag">the beverage num</param>
        /// <returns>image to use</returns>
        public BitmapImage AddPhotoToBtn(int tag) {
            return Beverages[tag].photo;
        }
    }

    public enum Ingredients {
        Cups, Sugar, Milk
    }
}
