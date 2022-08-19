using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class BeverageOutOfingredients : Exception
    {
        public override string Message => "There is no more ingredients for this beverage. \nPlease contact the manager";
    }
    internal class NotEnoughMoney : Exception
    {
        public override string Message => "You Don't Have Enough money. can't continue.";
    }

}
