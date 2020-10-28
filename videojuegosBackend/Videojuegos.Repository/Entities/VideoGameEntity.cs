using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Repository.Entities
{
   public class VideoGameEntity
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
        public int IdPlatform { get; set; }
        public int IdSupport { get; set; }
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
        public byte[] CoverPage { get; set; }
        public byte[] BackCover { get; set;}
        public string ReleaseDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public PlatformEntity Platform { get; set; }
        public UserEntity User { get; set; }
        public SupportEntity Support { get; set; }






    }
}
