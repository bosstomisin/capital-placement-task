using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Dto.Request
{
    public class AddCandidateDto
    {
        [Required]
        [JsonProperty(PropertyName = "questionId")]
        public string? QuestionId { get; set; }
        [Required]
        [JsonProperty(PropertyName = "programId")]
        public string? ProgramId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string? Value { get; set; }
    }
}
