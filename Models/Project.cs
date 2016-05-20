using System.Collections.Generic;
using Newtonsoft.Json;

namespace Azured.Web.Api.Models
{
    public sealed class Project
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "title")]        
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "sections")]
        public Dictionary<string, string> Sections { get; set; }
    }
}