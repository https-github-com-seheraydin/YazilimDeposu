using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web_projesi.Models.Model
{
    //Not: Entity Framework CodeFirst Yöntemi ile tablo oluşturduk
    
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [DisplayName("Slider Başlık"),StringLength(30,ErrorMessage ="30 karakter olmalıdır")]
        public string Baslik { get; set; }
        [DisplayName("Slider Açıklama"),StringLength(50,ErrorMessage ="50 karakter olmalıdır")]
        public string Aciklama { get; set; }
        [DisplayName("Slider Resim"),StringLength(250)]
        public string ResimURL { get; set; }
    }
}