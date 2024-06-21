using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication15.Service
{
    public class VehicleService
    {
        private readonly string _host;
        private readonly int _port;

        public VehicleService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public async Task<string> GetVehicleDataAsync()
        {
            try
            {
                using (TcpClient client = new TcpClient(_host, _port))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    return data;
                }
            }
            catch (Exception ex)
            {
                // Hata işleme
                return $"Hata: {ex.Message}";
            }
        }
    }
}
