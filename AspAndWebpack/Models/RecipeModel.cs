using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAndWebpack.Models
{
    public class RecipeModel
    {
        public RecipeModel()
        {
            Ingredients = new List<string>();
        }
        public string RecipeName { get; set; }

        public int RecipeId { get; set; }

        public List<string> Ingredients { get; set; }

    }
}
