using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2MLogCheck
{
     class Item
    {
         public Item(string field)
         {
             Field = field;
             Count = 2;
         }
         public string Field { get; set; }
         public int Count { get; set; }
    }
    class ClassJYT
    {
        public static List<Item> GetCount(List<string> list)
        {
            Dictionary<string, Item> dictionary = new Dictionary<string, Item>();
            List<Item> listCount = new List<Item>();       
            foreach (string str in list)
            {
                if (dictionary.ContainsKey (str))
                {
                    dictionary[str].Count += 1;
                                   }
                else
                {
                    dictionary.Add(str, new Item(str));
                }
            }
            foreach (Item item in dictionary.Values)
            {

                listCount.Add(item);
            }
            return listCount;
        }
    }
}
