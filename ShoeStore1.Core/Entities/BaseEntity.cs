namespace ShoeStore1.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        // DateTime? ile Dbde Allow Nulls kısmında tik var demek, yani boş geçilebilir.
        public bool IsDeleted { get; set; } = false;
        


    }
}
