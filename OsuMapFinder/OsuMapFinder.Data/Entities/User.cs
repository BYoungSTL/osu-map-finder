using OsuMapFinder.Data.Entities.BaseEntity;

namespace OsuMapFinder.Data.Entities
{
    public class User : Entity<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? OsuId { get; set; }
    }
}
