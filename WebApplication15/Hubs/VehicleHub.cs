using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebApplication15.Service;
    
namespace WebApplication15.Hubs
{
    public class VehicleHub : Hub
    {
        private readonly VehicleService _vehicleService;

        public VehicleHub(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task GetVehicleData()
        {
            string data = await _vehicleService.GetVehicleDataAsync();
            await Clients.All.SendAsync("ReceiveVehicleData", data);
        }

        private static Timer _timer;

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Console.WriteLine("Araç bağlandı: " + Context.ConnectionId);

            // Heartbeat gönderimi
            _timer = new Timer(SendHeartbeat, null, 0, 5000); // 5 saniyede bir heartbeat gönder
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Console.WriteLine("Araç bağlantısı kesildi: " + Context.ConnectionId);

            _timer?.Dispose();
        }

        private void SendHeartbeat(object state)
        {
            Clients.All.SendAsync("ReceiveHeartbeat", "heartbeat");
        }

        public async Task SendCommand(string command)
        {
            Console.WriteLine("Komut alındı: " + command);
            await Clients.All.SendAsync("ReceiveCommand", command);
        }

        public async Task SendVehicleData(string data)
        {
            Console.WriteLine("Araç verisi alındı: " + data);
            await Clients.All.SendAsync("ReceiveVehicleData", data);
        }
    }
}
