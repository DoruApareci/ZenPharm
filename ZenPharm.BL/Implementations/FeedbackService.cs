using ZenPharm.BL.Interfaces;
using ZenPharm.DAL;
using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Implementations;

public class FeedbackService : IFeedbackService
{
    private readonly ApplicationDbContext _context;
    public FeedbackService(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public PagedResult<FeedBack> GetMessages(int page, int count)
    {
            var Feeds = _context.FeedBacks.Skip((page-1)*count).Take(count).OrderByDescending(x => x.Placed);
            var totalItems = Feeds.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / count);
            var pageResult = new PagedResult<FeedBack>(Feeds, totalPages, page, totalItems);
            return pageResult;
    }

    public void PlaceFeedback(FeedBack feedBack)
    {
        feedBack.Placed = DateTime.Now;
        _context.FeedBacks.Add(feedBack);
        _context.SaveChanges();
    }
}
