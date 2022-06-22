using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_recursion
{
    class Branch
    {
        public List<Branch> Branches { get; set; }

        public Branch(List<Branch> branches)
        {
            Branches = branches;
        }
    }
}
