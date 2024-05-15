using DotnetTask.Domain.Config;
using DotnetTask.Domain.Models;
using DotnetTask.Domain.Repository.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Repository.Implementation
{
    public class ProgramRepo : BaseRepository<ProgramModel>, IProgramRepo
    {

        public ProgramRepo(IOptions<DbConfig> dbConfig) : base(dbConfig)
        {

        }



    }
}
