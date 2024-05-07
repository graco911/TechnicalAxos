using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TechnicalAxos.App.models
{
    public partial class CountryBase
    {
        [JsonProperty("flags")]
        public Flags Flags { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public partial class Flags
    {
        [JsonProperty("png")]
        public Uri Png { get; set; }

        [JsonProperty("svg")]
        public Uri Svg { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("common")]
        public string Common { get; set; }

        [JsonProperty("official")]
        public string Official { get; set; }
    }
}
