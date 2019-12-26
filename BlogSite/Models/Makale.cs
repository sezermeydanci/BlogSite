using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class Makale
    {
        public int Id { get; set; }
        [StringLength(100),Required(ErrorMessage ="{0} alanı doldurulmalıdır.")]
        public string Baslik { get; set; }        
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int YazarId { get; set; }
        public virtual Yazarlar Yazar { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategoriler Kategori { get; set; }
        



    }   
}