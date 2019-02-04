namespace Entities
{
    public class City :Entity
    {
        public virtual string Name { get; set; }

        public virtual Region Region { get; set; }
    }
}