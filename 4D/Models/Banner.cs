using System.Collections.Generic;

namespace _4D.Models
{
    public class Banner
    {
        public long Srno { get; set; }
        public string UploadedPath { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string RequestDate { get; set; }
        public string RequestTime { get; set; }

        public string UrlPath { get; set; }
        public int SequenceArrange { get; set; }
        public Banner()
        {
            this.Srno = 0;
            this.UploadedPath = "";
            this.Description = "";
            this.Status = "";
            this.RequestDate = "";
            this.RequestTime = "";
            this.SequenceArrange = 0;
            this.UrlPath = "";
        }


        public List<Banner> TopBanners_List { get; set; }
    }
}