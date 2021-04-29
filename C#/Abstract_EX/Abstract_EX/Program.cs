using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitOnly
{
    class Transaction
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}";
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Transaction tr1 = new Transaction { From = "Alic", To = "Bob", Amount = 100 };
            Transaction tr2 = new Transaction { From = "Bob", To = "Charlie", Amount = 50 };
            Transaction tr3 = new Transaction { From = "Charlie", To = "Alic", Amount = 50 };
        }
    }
    
}
