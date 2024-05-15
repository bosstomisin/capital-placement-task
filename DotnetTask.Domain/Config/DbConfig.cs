using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Config
{
    public class DbConfig
    {
        public DbConnection DbConnection { get; set; }
        public ContainerConfig ContainerConfig { get; set; }

    }
    public class DbConnection
    {
        public string Endpoint { get; set; } = string.Empty;
        public string AuthKey { get; set; } = string.Empty;
        public string DatabaseId { get; set; } = string.Empty;
    }
    public class ContainerConfig
    {
        public string ProgramContainer { get; set; } = string.Empty;
        public string QuestionContainer { get; set; } = string.Empty;
        public string CandidateContainer { get; set; } = string.Empty;
    }
}
