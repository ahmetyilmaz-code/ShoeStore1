namespace ShoeStore1.Service.Exceptions
{
    internal class NotRemoveException : ApplicationException
    {
        public override string Message => "Servis katmanı tamamen silme işlemine onay vermemektedir. Silme işlemi için IT ekibi ile iletişime geçiniz.";
    }
}
