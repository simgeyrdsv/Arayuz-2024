using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace WebApplication15.Hubs
{
    public class VideoHub : Hub
    {
        public async Task SendVideoFrame(string base64Image)
        {
            await Clients.All.SendAsync("ReceiveVideoFrame", base64Image);
        }
    }
}
