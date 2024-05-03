using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Interfaces;

public interface IFeedbackService
{
    public void PlaceFeedback(FeedBack feedBack);
    public PagedResult<FeedBack> GetMessages(int page, int count);
}
