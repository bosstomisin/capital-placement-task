using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Dto
{
    public class AddProgramDto
    {
        [Required]
        public string ProgramTitle { get; set; }

        [Required]
        public string ProgramDescription { get; set; }
    }
}
