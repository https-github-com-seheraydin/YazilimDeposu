using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web_projesi.Models.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        [Required, StringLength(50,ErrorMessage ="50 karakter olmalıdır.")]
        public string KategoriAd { get; set; }
    
        public string Aciklama { get; set; }

        //veri tabanındaki blog ve kategori araasındaki 1'e çok ilişki
        public ICollection<Blog> Blogs { get; set; }
    }
}