using DotnetTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetTask.Core.Dto.Request
{
    public class AddQuestionDto
    {
        public string PragramId { get; set; }
        public string Question { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionType Questiontype { get; set; }
    }
}
