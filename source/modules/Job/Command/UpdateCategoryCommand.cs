using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Module.Command
{
    public class UpdateCategoryCommand
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
