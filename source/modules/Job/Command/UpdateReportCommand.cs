using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Module.Command
{
    public class UpdateReportCommand
    {
        public int ReportId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
