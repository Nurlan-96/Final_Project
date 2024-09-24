using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Module.Commands
{
    public class CreateReportCommand
    {
        public string Reason { get; set; }
        public int JobPostId { get; set; }
        public int UserId { get; set; }
    }
}
