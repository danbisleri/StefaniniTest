namespace Entities
{
    public class UserSys :Entity
    {
        public virtual string Login { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}