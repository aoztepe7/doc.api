using doc.api.Domain;

namespace doc.api.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetByMailAndPassword(string mail, string password);
        public Task<int> Create(User user);
        public Task<User> GetById(Guid id);
    }
}
