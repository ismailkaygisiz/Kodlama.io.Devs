using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingLanguage : Entity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Technology>? Technologies { get; set; }

        public ProgrammingLanguage()
        {

        }

        public ProgrammingLanguage(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
