using ChanelCategorySearcher.DAI;

namespace ChanelCategorySearcher.BusinessLogic;

public interface IChanelService
{
    public Task<Chanel> CreateChanel(string name,string category,string link,  CancellationToken cancellationToken = default);

    public List<Chanel> GetAll();
    public List<Chanel> GetByCategory(string category);
    
    public List<string> GetAllCategory();
}