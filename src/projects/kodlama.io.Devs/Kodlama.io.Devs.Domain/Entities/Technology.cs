using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {

        }

        public Technology(int id, int programmingLanguageId, string name) : base(id)
        {
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
