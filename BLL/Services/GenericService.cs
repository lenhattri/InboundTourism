using DAL.Interfaces;
using BLL.Interfaces;

namespace BLL.Services
{
    /*
     * 
     Service bản chung(Generic) có thể dùng cho mọi Entity
     *
     */
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }

}
