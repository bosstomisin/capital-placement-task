using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Dto.Request
{
    public class AddProgramDto
    {
        [Required]
        [JsonProperty(PropertyName = "programTitle")]
        public string? ProgramTitle { get; set; }

        [JsonProperty(PropertyName = "programDescription")]
        [Required]
        public string? ProgramDescription { get; set; }
    }
}
