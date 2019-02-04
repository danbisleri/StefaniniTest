namespace Entities
{
    public class Customer : Entity
    {
        public virtual Classification Classification { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual string LastPurchase { get; set; }
        public virtual UserSys UserSys { get; set; }
    }
}