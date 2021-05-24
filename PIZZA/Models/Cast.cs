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
        Dictionary<int, int> Pizza;
        Dictionary<int, int> Drink;
        Dictionary<int, int> Sushi;

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Cast FromJson(string json)
        {
            Cast cast = JsonSerializer.Deserialize<Cast>(json);
            return cast;
        }

    }
}
