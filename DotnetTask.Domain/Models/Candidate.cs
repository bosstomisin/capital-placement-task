using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Models
{
    public class Candidate : BaseEntity
    {
        [JsonProperty(PropertyName = "questionId")]
        public string QuestionId { get; set; }

        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
