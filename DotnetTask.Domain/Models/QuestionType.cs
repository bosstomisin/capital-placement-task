using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Models
{
    public enum QuestionType 
    {
        Paragraph = 1,
        YesNo,
        Dropdown,
        MultipleChoice,
        Date,
        Number
    }
}
