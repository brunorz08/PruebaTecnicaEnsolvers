namespace EnsolversPT.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> InsertNoteAsync(TEntity entity);

        Task<TEntity> Delete(int id);

        Task<TEntity> Modify(TEntity entity, int id);

        Task<IEnumerable<TEntity>> GetByTag(string tag);

    }
}
