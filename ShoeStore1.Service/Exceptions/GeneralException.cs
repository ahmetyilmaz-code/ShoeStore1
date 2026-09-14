namespace ShoeStore1.Service.Exceptions
{
    public class GeneralException : ApplicationException
    {
        public GeneralException(string message = "Bir hata oluştu. Lütfen IT ekibi ile iletişime geçiniz.") : base(message)
        {
        }
    }
}
