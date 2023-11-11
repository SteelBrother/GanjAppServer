using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.HubMsj
{
    public class UserUpdatesHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Debug.WriteLine(Context.ConnectionId);
            return base.OnConnectedAsync();

        }
    }
}
