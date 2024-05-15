﻿using DotnetTask.Domain.Models;
using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; }

        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }

        [JsonProperty(PropertyName = "questiontype")]

        [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionType QuestionType { get; set; }
    }
}
