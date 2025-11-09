namespace Business.Interfaces.Querys
{
    public interface IQueryServices<TEntity,TReadDto>
    {
        Task<IEnumerable<TReadDto>> GetAllServices(int? status);
        Task<TReadDto> GetByIdServices(int id);
    }
}
