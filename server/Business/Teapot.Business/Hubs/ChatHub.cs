using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;
using Teapot.Business.Concrete.ChatHistories;
using Teapot.Business.Concrete.Projects;
using Teapot.Entities.Concrete;


namespace Teapot.Business.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatHistoryService _chatHistoryService;
        private readonly IProjectService _projectService;

        private readonly static ConnectionMapping<int> _connections =
           new ConnectionMapping<int>();

        public ChatHub(IChatHistoryService chatHistoryService, IProjectService projectService)
        {
            _chatHistoryService = chatHistoryService;
            _projectService = projectService;
        }

        public override async Task OnConnectedAsync()
        {
            //var claims = Context.User.Claims;
            //var userId = Convert.ToInt32(claims.FirstOrDefault(x => x.Type == "UserId").Value);


            _connections.Add(GetUserId(), Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        private int GetUserId()
        {
            var a = Context.GetHttpContext().Request.Query["access_token"];
            var token = new JwtSecurityToken(jwtEncodedString: a);
            string id = token
                .Claims
                .First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                .Value;
            return Convert.ToInt32(id);
        }

        public async Task SendMessage(string message, int projectId)
        {
            var receiverId = await _projectService.GetOwnerIdByProject(projectId);
            if (_connections.GetConnections(receiverId).Count() <= 0)
            {
                await Task.CompletedTask;
            }

            var targetUserConnectionId = _connections.GetConnections(receiverId).First();
            await Clients.Client(targetUserConnectionId).SendAsync("ChatChannel", message);

            await AddChatHistory(message, receiverId, projectId);
        }

        private async Task AddChatHistory(string message, int receiverUserId, int projectId)
        {
            var senderUserId = GetUserId();

            await _chatHistoryService.Add(new ChatHistory
            {
                SenderId = senderUserId,
                ReceiverId = receiverUserId,
                Message = message,
                ProjectId = projectId
            });
        }
    }
}
