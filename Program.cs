using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Magaz
    {
        public static void Menu(Buyer x)
        {
            Console.WriteLine(" 1-to buy \n 2-to Baglist \n 3-to delete \n 4-end ");
            int a;
            bool go = Int32.TryParse((Console.ReadLine()), out a);
            if (go == true)
            {
                if (a == 1)
                { Magaz.Sell(x); }
                else if (a == 2 && x.isBagEmpty() == false)
                { x.BagList(); Console.WriteLine("\n " + x.BagSum()); Magaz.Menu(x); }
                else if (a == 2 && x.isBagEmpty() == true)
                { Console.Clear(); Console.WriteLine("bag is empty press any key for main menu"); Console.ReadKey(); Console.Clear(); Magaz.Menu(x); }
                else if (a == 3)
                { x.removeItem(); Magaz.Menu(x); }
                else { Magaz.Menu(x); };
            }
            else { Console.WriteLine("Input error"); Magaz.Menu(x); }
        }
        public void EndSell (Buyer x)
            {if (x.BagSum() <= x.userCash()) { }    ///////////////////////

        }


        public static void Sell(Buyer x)
        {
            Product A = new Product("fignja", 100);
            Product B = new Product("dorogaya fignja", 1000);
            Product C = new Product("erunda", 10);
            Product D = new Product("hz", 100);

            Console.WriteLine(" 1 - to buy fignja \n 2 - to buy dorogaya fignja \n 3 - to buy erunda \n 4 - to main menu");
            int a;
            bool go = Int32.TryParse((Console.ReadLine()), out a);
            if (go == true)
            {
                if (a == 1)
                { x.addItem(A); Console.Clear(); Magaz.Menu(x); }
                else if (a == 2)
                { x.addItem(B); Console.Clear(); Magaz.Menu(x); }
                else if (a == 3)
                { x.addItem(C); Console.Clear(); Magaz.Menu(x); }
                else { Console.Clear(); Magaz.Menu(x); };
            }
            else { Console.WriteLine("Input error"); Magaz.Menu(x); }

            

        }

        
    }
    public class Buyer
    {
        private string ID="name";
        private int Cash=0;
        List<Product> Bag = new List<Product>();
        public Buyer(string a, int b) { ID = a;  Cash = b; }
        public void BuyerStat() { Console.WriteLine("Name is "+ID + "\n" + "cash is "+ Cash); }
        public void addItem (Product b) { Bag.Add(b); }

        public void removeItem()
        { //Bag.RemoveAt(z);
            foreach (Product x in Bag) { Console.WriteLine($"{Bag.IndexOf(x)} -- {x.prodNameOut()} -- {x.priseOut()}"); }
            Console.WriteLine("Enter number to delete");
            int ntd = Convert.ToInt32(Console.ReadLine());
            Bag.RemoveAt(ntd);

        }
        
        public bool isBagEmpty() { if (Bag.Count == 0) { return true; } else return false; }
        public void BagList() { foreach (Product x in Bag) { x.ProdInfo(); } }
        public int BagSum() { int sum = 0; foreach (Product x in Bag) { sum += x.priseOut(); } return sum; }
        public int userCash() { return Cash; }

    }
    public class Product
    {
        private string prodName;
        private int Prise;
        private int Quantity = 1;
        public Product(string n, int p) { prodName = n; Prise = p; }
        public int priseOut() { return Prise; }
        public string prodNameOut() { return prodName; }
        public void ProdInfo() { Console.WriteLine("Product - "+ prodName +"\t"+ "Prise is - "+Prise+"\t"+"Quantity - "+Quantity); }
        public void QuantityUp() { Quantity++; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Buyer one = new Buyer("buyer", 100);
           /* one.BuyerStat();
            one.addItem(A);
            one.BagList();*/
            Magaz.Menu(one);

            
            Console.ReadKey();
        }
    }
}
