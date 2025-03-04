using ChanelCategorySearcher.DAI;

namespace ChanelCategorySearcher.BusinessLogic;

public class ChanelService : IChanelService
{
    private readonly IChanelRepository _chanelRepository;
    
    public ChanelService(IChanelRepository chanelRepository)
    {
        _chanelRepository = chanelRepository;
    }

    public async Task<Chanel> CreateChanel(string name,string category,string link, CancellationToken cancellationToken = default)
    {
        var chanel = new Chanel();
        chanel.Name = name;
        chanel.Category = category;
        chanel.Link = link;
        //temporary protection
        if (_chanelRepository.GetAll().Count > 100)
        {
            return null;
        }
        return await _chanelRepository.CreateAsync(chanel, cancellationToken);
    }

    public List<Chanel> GetAll()
    {
        return _chanelRepository.GetAll();
    }

    public List<Chanel> GetByCategory(string category)
    {
        return _chanelRepository.GetByCategory(category);
    }

    public List<string> GetAllCategory()
    {
        return _chanelRepository.GetAllCategory();
    }
}