using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.EntityLayer
{
   public class Zimmet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int CalisanId { get; set; }
        [ForeignKey("CalisanId")]  //calisan ıd adında ikincil anahtar
        public virtual Calisan Calisan { get; set; }
      
        public int TurId { get; set; }
        [ForeignKey("TurId")]  //calisan ıd adında ikincil anahtar
        public virtual Tur Tur { get; set; }
    }
}
