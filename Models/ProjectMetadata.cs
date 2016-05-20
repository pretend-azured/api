using Newtonsoft.Json;

namespace Azured.Web.Api.Models
{
    public sealed class ProjectMetadata
    {        
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}