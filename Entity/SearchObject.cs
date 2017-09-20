using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Entities
{
    public class SearchObject
    {
        public string LeftOperand { get; set; }
        public string Operator { get; set; }
        public string RightOperand { get; set; }

        public SearchObject(string L, string Op, string R)
        {
            LeftOperand = L;
            Operator = Op;
            RightOperand = R;
        }
    }
}
