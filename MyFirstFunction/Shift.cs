using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyFirstFunction
{
    public class Shift
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("person")]
        public required string Person { get; set; }
    }
}
