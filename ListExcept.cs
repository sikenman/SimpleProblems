using System;
using System.Collections.Generic;
using System.Linq;      // used for Except() method

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
            CustomList[] list1 = {
                new CustomList("ID9","Apple",12.5f),
                new CustomList("ID12","Banana",9.3f),
                new CustomList("ID10","Orange",8.4f),
                new CustomList("ID11","Lemon",4.3f),
                new CustomList("ID13","Mango",7.7f)
            };

            CustomList[] list2 = {
                new CustomList("ID9","Apple",12.5f),
                new CustomList("ID11","Lemon",4.3f)
            };

            //Get all the elements from the first array
            //except for the elements from the second array.

            IEnumerable<CustomList> except = list1.Except(list2, new ListComparer());
            foreach (var each in except)
                each.DisplayList();

            Console.WriteLine();

            // By using List ----------------------------------------------------------
            List<CustomList> listA = new List<CustomList>();
            listA.Add(new CustomList("Item-01", "Dell Laptop", 499.99f));
            listA.Add(new CustomList("Item-03", "Beats Headphone", 150.00f));
            listA.Add(new CustomList("Item-05", "Bluetooth Keyboard", 39.99f));
            listA.Add(new CustomList("Item-07", "MS Windows 10 Prof", 98.99f));

            List<CustomList> listB = new List<CustomList>();
            listB.Add(new CustomList("Item-03", "Beats Headphone", 150.00f));
            listB.Add(new CustomList("Item-07", "MS Windows 10 Prof", 98.76f));     //price is different but Code is same

            IEnumerable<CustomList> except2 = listA.Except(listB, new ListComparer());
            foreach (var each in except2)
                each.DisplayList();

            Console.ReadKey();
        }
    }

    public class CustomList
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public CustomList(string code, string name, float price)
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

    class ListComparer : IEqualityComparer<CustomList>
    {
        // CustomList are equal if their codes are equal.
        public bool Equals(CustomList x, CustomList y)
        {
            // Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            // Only check if two codes are equal or not
            return x.Code == y.Code;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(CustomList cl)
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
