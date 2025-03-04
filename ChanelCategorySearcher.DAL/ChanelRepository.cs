namespace ChanelCategorySearcher.DAI;

internal class ChanelRepository : IChanelRepository
{
    private readonly AppDbContext _context;
    
    public ChanelRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Chanel> CreateAsync(Chanel chanel, CancellationToken cancellationToken = default)
    {
        await _context.Chanels.AddAsync(chanel,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return chanel;
    }

    public List<Chanel> GetAll()
    {
        return _context.Chanels.ToList();
    }
    

    public List<Chanel> GetByCategory(string category)
    {
        var channels = _context.Chanels.Where(x => x.Category == category).ToList();
        return channels;
    }

    public List<string> GetAllCategory()
    {
        var categories = _context.Chanels.Select(x => x.Category).Distinct().ToList();
        return categories;
    }
}