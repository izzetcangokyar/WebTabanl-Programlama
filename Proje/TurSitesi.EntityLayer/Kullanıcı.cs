using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.EntityLayer
{
    public enum Yetkiler //enum veri türünde yetkiler olusturuldu
    {
        Yonetici, Gorevli
    }

    [Table("tblKullanıcılar")]
    public class Kullanıcı
    {
        [Key, Required(ErrorMessage = "EPosta alanı boş geçilemez")]
        public string EPosta { get; set; }
        [Required(ErrorMessage = "Parola belirlemelisiniz")]
        [MinLength(3, ErrorMessage = "Parola en az 3 karakterden oluşmalıdır")]
        public string Parola { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyad { get; set; }
        public Yetkiler Yetki { get; set; }
    }
}
