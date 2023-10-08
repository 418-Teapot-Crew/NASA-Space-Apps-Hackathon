using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.ChatHistories
{
    public interface IChatHistoryService
    {
        Task Add(ChatHistory chatHistory);
        Task<List<ChatHistory>> GetList();
        Task<ChatHistory> GetByIdAsync(int id);
    }
}
