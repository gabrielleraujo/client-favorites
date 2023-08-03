namespace Newme.ClientFavorites.Domain.Entities.ShoopingCart
{
    public class DiscountCoupon : Entity
    {
        public DiscountCoupon(
            Guid id,
            string name,
            double percentage,
            string description) : base(id)
        {
            Name = name;
            Percentage = percentage;
            Description = description;
        }

        public string Name { get; private set; }
        public double Percentage { get; private set; }
        public string Description { get; private set; }
    }
}