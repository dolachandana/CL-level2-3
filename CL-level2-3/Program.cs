using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
//level-2 & 3 checklist-2
c products = new c();
List<catclass> catlist = new List<catclass>();
bool addAgain = true;
while (addAgain)
{
    while (true)
    {
        products.addprod(catlist);
        Console.Write("press q  to quit or press any:");
        string quit = Console.ReadLine();
        Console.WriteLine("-------------------");
        if (quit == "q") { break; }
    }
    products.display(catlist);

    Console.Write("enter 'add' to add more products, else any other key:");// Level-3 adding more products
    string add = Console.ReadLine();
    Console.WriteLine("-------------------");
    if (add != "add") { addAgain = false; }
}




public class c
{
    public void addprod(List<catclass> catlist)
    {

        Console.Write("Enter the category:");
        string category = Console.ReadLine();

        prodclass prodobj = new prodclass();
        Console.Write("Enter the productnames :");
        prodobj.productname = Console.ReadLine();


        Console.Write("Enter the price :");
        bool t = true;
        while (t) //level-3 error handling
        {
            string p = Console.ReadLine();
            bool i = int.TryParse(p, out int value);
            if (i) { prodobj.price = value; t = false; }
            else
            {
                Console.WriteLine("Please enter number :");
            }
        }


        bool found = false;
        foreach (var cat in catlist)
        {
            if (cat.category == category)
            {
                found = true;
                cat.prodlist.Add(prodobj);
                break;
            }
        }

        if (!found)
        {
            catclass catobj = new catclass();
            catobj.category = category;
            catobj.prodlist.Add(prodobj);
            catlist.Add(catobj);
        }

    }
    public void display(List<catclass> catlist)
    {
        Console.WriteLine("-------------------");
        Console.WriteLine("The list is");
        foreach (var catobj in catlist)  //displaying list
        {
            Console.WriteLine("category:" + catobj.category);

            foreach (var prodobj in catobj.prodlist)
            {
                Console.WriteLine("productname:" + prodobj.productname + "\nprice:" + prodobj.price);
            }
        }
        Console.WriteLine("-------------------");
        Console.WriteLine("The sortedlist:");//sorting list with respect to price
        foreach (var catobj in catlist)
        {
            Console.WriteLine("category:" + catobj.category);
            List<prodclass> sorted = catobj.prodlist.OrderBy(prodObj => prodObj.price).ToList();
            foreach (var s in sorted)
            {
                Console.WriteLine("productname:" + s.productname + "\nprice:" + s.price);
            }
        }

        Console.WriteLine("-------------------");
        int w = 0;
        foreach (var catobj in catlist) //sum of all price
        {
            int sumofprice = catobj.prodlist.Sum(p => p.price);
            w = sumofprice + w;
        }
        Console.WriteLine("The total sum of price:" + w);
        Console.WriteLine("-------------------");
    }
}

public class catclass  //class1
{
    public string category;
    public List<prodclass> prodlist = new List<prodclass>();
}
public class prodclass //class2
{
    public string productname;
    public int price;
}

