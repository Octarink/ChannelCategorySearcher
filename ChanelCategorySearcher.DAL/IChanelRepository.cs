namespace ChanelCategorySearcher.DAI;

public interface IChanelRepository
{
    Task<Chanel> CreateAsync(Chanel chanel, CancellationToken cancellationToken = default);

    List<Chanel> GetAll();
    List<Chanel> GetByCategory(string category);
    List<string> GetAllCategory();
}