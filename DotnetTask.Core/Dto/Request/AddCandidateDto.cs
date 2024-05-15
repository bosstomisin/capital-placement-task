using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Dto.Request
{
    public class AddCandidateDto
    {
        public string QuestionId { get; set; }
        public string ProgramId { get; set; }
        public string Value { get; set; }
    }
}
