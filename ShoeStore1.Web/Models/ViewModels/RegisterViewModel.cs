using System.ComponentModel.DataAnnotations;

namespace ShoeStore1.Web.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad Alanı Zorunludur")]
        [Display(Name = "Adınız")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Soyad Alanı Zorunludur")]
        [Display(Name = "Soyadınız")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "E-posta Alanı Zorunludur")]
        [Display(Name = "E-posta Adresiniz")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [Display(Name = "Şifreniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Şifre Tekrar Alanı Zorunludur")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        // Compare attribute, ConfirmPassword property'sinin Password property'si ile
        // eşleşip eşleşmediğini kontrol eder. Eğer eşleşmezse belirtilen hata mesajını gösterir.
        public string ConfirmPassword { get; set; }

    }
}
