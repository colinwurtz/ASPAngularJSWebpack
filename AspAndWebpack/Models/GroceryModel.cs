using System.Collections.Generic;

namespace AspAndWebpack.Models
{
    public class GroceryModel
    {
        public GroceryModel(string groceryName, int id)
        {
            GroceryName = groceryName;
            GroceryId = id;
            //SelectedLocation = GroceryStoreLocation.CreateGroceryStoreLocation();
            GroceryStoreLocations = new List<string>();
        }

        public string GroceryName { get; set; }

        public int? GroceryId { get; set; }


        public List<string> GroceryStoreLocations { get; set; }


        public double Quantity { get; set; }


        //Optional Properties?
        public int? LocationId { get; set; }

        public int? CategoryId { get; set; }

        public string UserId { get; set; }


    }
}