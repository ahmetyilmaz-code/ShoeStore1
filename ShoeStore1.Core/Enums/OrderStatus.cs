namespace ShoeStore1.Core.Enums
{
    public enum OrderStatus
    {
        Received = 1,   //sipariş alındı.
        Processing,     //sipariş hazırlanıyor.
        Shipped,        //sipariş kargoya verildi.
        Delivered,      //sipariş teslim edildi.
        Cancelled       //sipariş iptal edildi.

    }
}
