using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videojuegos.API.ViewModels
{
    public class VideoGameVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string BarCode { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public string Redump { get; set; }
        public string Genre { get; set; }
        public string Distributor { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public int IdSystem { get; set; }
        public int IdSupport { get; set; }
       // public int IdUser { get; set; }
        public bool IsActive { get; set; }
        public byte[] CoverPage { get; set; }
        public byte[] BackCover { get; set; }
        public string ReleaseDate { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime UpdateDate { get; set; }
        //public string Platform { get; set; }
        //public string User { get; set; }
        //public string Support { get; set; }

    }
}
