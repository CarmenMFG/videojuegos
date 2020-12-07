using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Business.DOModels
{
    public class VideoGameDO
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
        public int? IdSystem { get; set; }
        public int? IdSupport { get; set; }
        public bool IsActive { get; set; }
        public string CoverPage { get; set; }
        public string BackCover { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public SystemDO System { get; set; }
        public SupportDO Support { get; set; }
        public PlatformDO  Platform { get; set; }
    }
}
