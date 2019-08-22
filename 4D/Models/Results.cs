using System.Collections.Generic;

namespace _4D.Models
{
    public class Results
    {
        public long Srno { get; set; }
        public string ResultDate { get; set; }
        public string ResultType { get; set; }
        public string Status { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string S5 { get; set; }
        public string S6 { get; set; }
        public string S7 { get; set; }
        public string S8 { get; set; }
        public string S9 { get; set; }
        public string S10 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string T10 { get; set; }
        public string F_3D_1 { get; set; }
        public string F_3D_2 { get; set; }
        public string F_3D_3 { get; set; }

        public List<Results> Results_List { get; set; }
        public Results()
        {
            Srno = 0;
            ResultDate = "";
            ResultType = "";
            Status = "";
            F1 = "-";
            F2 = "-";
            F3 = "-";
            S1 = "-";
            S2 = "-";
            S3 = "-";
            S4 = "-";
            S5 = "-";
            S6 = "-";
            S7 = "-";
            S8 = "-";
            S9 = "-";
            S10 = "-";
            T1 = "-";
            T2 = "-";
            T3 = "-";
            T4 = "-";
            T5 = "-";
            T6 = "-";
            T7 = "-";
            T8 = "-";
            T9 = "-";
            T10 = "-";
            F_3D_1 = "-";
            F_3D_2 = "-";
            F_3D_3 = "-";
        }

    }
}