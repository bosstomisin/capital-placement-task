using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Models
{
    public class BaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "dateCreated")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "dateUpdated")]
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
