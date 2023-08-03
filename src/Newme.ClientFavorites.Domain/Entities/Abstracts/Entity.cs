namespace Newme.ClientFavorites.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
            CreateDate = DateTime.Now;
            UpdateDate = null;
        }

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}