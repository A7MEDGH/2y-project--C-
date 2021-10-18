using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Description
    {

        //Properties
        public string Info { get; set; }

        //Constructors
        public Description (string info)
        {
            Info = info;
        }
        public Description()
        {

        }
        //Method
        public override string ToString()
        {
            return string.Format($"{Info}");
        }

    }
}
