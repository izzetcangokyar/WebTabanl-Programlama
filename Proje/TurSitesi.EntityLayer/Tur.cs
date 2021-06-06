using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.EntityLayer
{
    [Table("tblTurlar")]
    public class Tur
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Ad { get; set; }


        [Required(ErrorMessage = "Kategori alanı boş geçilemez")]

        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]  //MarkaId ıd adında ikincil anahtar
        public virtual Kategori kategori { get; set; }


        public Boolean DoluMu { get; set; }

    }
}
