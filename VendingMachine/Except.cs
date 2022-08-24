using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class BeverageOutOfingredientsException : Exception {
        public BeverageOutOfingredientsException() { }
        public BeverageOutOfingredientsException(string message) : base(message) { }

    }
    internal class NotEnoughMoneyException : Exception {
        public NotEnoughMoneyException() { }
        public NotEnoughMoneyException(string message) : base(message) { }

    }
}
