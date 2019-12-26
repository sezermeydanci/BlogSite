using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class Kategoriler
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} alanı doldurulmalıdır.")]
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Makale> Makales { get; set; }

    }
}