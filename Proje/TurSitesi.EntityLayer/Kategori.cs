using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.EntityLayer
{

    [Table("tblKategoriler")]// veritabanında kategori adında  tablo olusturuyor
    public class Kategori // Kategori modelimizi olusturdugumuz sınıf 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]// ıd alanını birincil anahtar olarak 
        // belirleyip otomatik sayı olarak tanımlanıyor
        public int Id { get; set; }

        public string Ad { get; set; }
    }

}
