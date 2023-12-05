using Microsoft.AspNetCore.SignalR;

namespace SOPlabNEW.Hubs {
    public class LibHub : Hub {
        public async Task NotifyWebUsers(string user, string message) {
            await Clients.All.SendAsync("DisplayNotification", user, message);
        }
    }
}
