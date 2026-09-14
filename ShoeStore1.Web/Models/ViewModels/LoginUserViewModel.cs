using System.ComponentModel.DataAnnotations;

namespace ShoeStore1.Web.Models.ViewModels
{
    public class LoginUserViewModel
    {
        //Required (boş geçilemez). bu alanı boş geçmek isterlerse
        //hata mesajın ( ErrorMessageResourceName ="E-Posta alanını doldurunuz") )
        [Required(ErrorMessage = "E-Posta alanını doldurunuz.")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir Email giriniz.")]
        [Display(Name ="E-posta Adresi")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Şifre alanını doldurunuz.")]
        [DataType(DataType.Password)] // Şifre alanının (***) görünmesini sağlar
        [Display(Name = "Şifre")]
        public string Password { get; set; }


        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
