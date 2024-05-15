using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Models
{
    public class Questions : BaseEntity
    {
        public string PragramId { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
    }
}
