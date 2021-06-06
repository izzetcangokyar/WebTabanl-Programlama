using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.EntityLayer
{
    [Table("tblCalisanlar")]
    public class Calisan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyad { get; set; }
        [NotMapped]
        public string AdSoyad { get { return Ad + " " + Soyad; } }


    }
}


