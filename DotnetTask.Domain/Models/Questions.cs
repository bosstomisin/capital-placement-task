using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Models
{
    public class Questions : BaseEntity
    {
        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; }

        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }

        [JsonProperty(PropertyName = "questionType")]
        public string QuestionType { get; set; }
    }
}
