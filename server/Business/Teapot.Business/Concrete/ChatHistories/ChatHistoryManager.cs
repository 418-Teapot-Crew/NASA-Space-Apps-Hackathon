using Microsoft.EntityFrameworkCore;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.ChatHistories
{

    public class ChatHistoryManager : IChatHistoryService
    {
        private readonly Teapot418DbContext _context;

        public ChatHistoryManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task Add(ChatHistory chatHistory)
        {
            await _context.ChatHistories.AddAsync(chatHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<ChatHistory> GetByIdAsync(int id)
        {
            return await _context.ChatHistories.FirstOrDefaultAsync(P => P.Id == id);
        }

        public async Task<List<ChatHistory>> GetList()
        {
            return await _context.ChatHistories.ToListAsync();
        }
    }
}
