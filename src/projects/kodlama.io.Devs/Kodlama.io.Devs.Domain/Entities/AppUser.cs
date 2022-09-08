using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class AppUser : User
    {
        public string GithubAddress { get; set; }

        public AppUser()
        {

        }

        public AppUser(int id, string githubAddress)
        {
            Id = id;
            GithubAddress = githubAddress;
        }
    }
}
