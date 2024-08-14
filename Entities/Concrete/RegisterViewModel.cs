using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı boş geçilemez!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş geçilemez!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez!")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş geçilemez!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email adresi boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email formatına uygun değil!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tekrar Şifresi boş geçilemez!")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
