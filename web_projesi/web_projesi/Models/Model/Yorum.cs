using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web_projesi.Models.Model
{
    [Table("Yorum")]
    public class Yorum
    {
 
        public int YorumId { get; set; }
        [Required,StringLength(50,ErrorMessage = "50 Karekter olabilir")]
        public string AdSoyad { get; set; }
        [Required]
        public string Eposta { get; set; }
        [Required,DisplayName("Yorumunuz"), StringLength(500, ErrorMessage ="500 Karakter olabilir")]
        public string Icerik { get; set; }
        public bool Onay { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }


    }
}