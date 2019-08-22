using System.Collections.Generic;

namespace _4D.Models
{
    public class Result_5D
    {
        public long Srno { get; set; }
        public string ResultDate { get; set; }
        public string ResultType { get; set; }
        public string Status { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string F6 { get; set; }

        public List<Result_5D> Result_5D_List { get; set; }

        public Result_5D()
        {
            Srno = 0;
            ResultDate = "";
            ResultType = "";
            Status = "";
            F1 = "-";
            F2 = "-";
            F3 = "-";
            F4 = "-";
            F5 = "-";
            F6 = "-";
        }


    }
}