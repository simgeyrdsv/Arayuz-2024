using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace WebApplication15.Hubs
{
    public class ControlHub : Hub
    {
        public async Task Move(string direction)
        {
            await Clients.All.SendAsync("ReceiveMove", direction);
        }
    }
}
