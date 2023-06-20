namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {

        //Asagidaki kisimlar base e hic dokunmadan repositoryler ile iletisime gecmemizi sagliyor
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        void Save();
    }
}