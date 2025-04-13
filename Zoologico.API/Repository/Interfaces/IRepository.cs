namespace Zoologico.API.Repository.Interfaces
{
    public interface IRepository<Model>
    {
        public Task<bool> Create (Model model);
        public Task<IEnumerable<Model>> Search (Model model);

        public Task<bool> Update(Model model);
        public Task<bool> Remove(Model model);
        public Task<Model> SearchId(int id);
    }
}
