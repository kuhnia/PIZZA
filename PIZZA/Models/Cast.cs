using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PIZZA.Models
{
    public class Cast
    {
        public List<Pizza> Pizza { set; get; }
        public List<Drink> Drink { set; get; }
        public List<Sushi> Sushi { set; get; }

        public Cast()
        {
            Pizza = new List<Pizza>();
            Drink = new List<Drink>();
            Sushi = new List<Sushi>();
        }


        public string ToJson()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

        public static Cast FromJson(string json)
        {
            Cast cast;
            if (json != null)
                cast = JsonSerializer.Deserialize<Cast>(json);
            else
                cast = new Cast();
            return cast;
        }

    }

}
