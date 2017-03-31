using System;
using System.Collections.Generic;
using System.Linq;

namespace ConAppListExcept
{
    /// <author>Siken Man Singh Dongol</author>
    /// <datecreated>2017-03-31</datecreated>
    /// <summary>
    /// Finds the difference between two given list on basis of one unique field 
    /// The unique field is [Code] in this example
    /// This code make use of efficient [Except] method
    /// </summary>
    class ListExcept
    {
        static void Main(string[] args)
        {
            // By using Array ---------------------------------------------------------
            CustomItem[] list1 = {
                new CustomItem("ID09","Apple ",12.5f),
                new CustomItem("ID12","Banana",9.3f),
                new CustomItem("ID10","Orange",8.4f),
                new CustomItem("ID11","Lemon ",4.3f),
                new CustomItem("ID13","Mango ",7.7f)
            };

            CustomItem[] list2 = {
                new CustomItem("ID09","Apple ",12.5f),
                new CustomItem("ID11","Lemon ",4.3f)
            };

            //Get all the elements from the first array
            //except for the elements from the second array.

            IEnumerable<CustomItem> except = list1.Except(list2, new ListComparer());   // core logic
            foreach (var each in except)
                each.DisplayList();

            Console.WriteLine();

            // By using List ----------------------------------------------------------
            List<CustomItem> listA = new List<CustomItem>();
            listA.Add(new CustomItem("Item-01", "Dell Laptop       ", 499.99f));
            listA.Add(new CustomItem("Item-03", "Beats Headphone   ", 150.00f));
            listA.Add(new CustomItem("Item-05", "Bluetooth Keyboard", 39.99f));
            listA.Add(new CustomItem("Item-07", "MS Windows 10 Prof", 98.99f));

            List<CustomItem> listB = new List<CustomItem>();
            listB.Add(new CustomItem("Item-03", "Beats Headphone   ", 150.00f));
            listB.Add(new CustomItem("Item-07", "MS Windows 10 Prof", 98.99f));     //price is different but Code is same

            IEnumerable<CustomItem> except2 = listA.Except(listB, new ListComparer());
            foreach (var each in except2)
                each.DisplayList();

            Console.ReadKey();
        }
    }

    public class CustomItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public CustomItem(string code, string name, float price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        public void DisplayList()
        {
            Console.WriteLine(Code + " - " + Name + " - " + Price);
        }
    }

    class ListComparer : IEqualityComparer<CustomItem>
    {
        // CustomItem are equal if their codes are equal.
        public bool Equals(CustomItem x, CustomItem y)
        {
            // Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            // Only check if two codes are equal or not
            return x.Code == y.Code;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(CustomItem cl)
        {
            int result = 17;

            //Check whether the object is null
            if (Object.ReferenceEquals(cl, null)) return 0;

            //Get hash code for the Code field.
            int hashMLCode = cl.Code.GetHashCode();

            //Calculate the hash code
            return (31 * result + hashMLCode);
        }

    }
}
