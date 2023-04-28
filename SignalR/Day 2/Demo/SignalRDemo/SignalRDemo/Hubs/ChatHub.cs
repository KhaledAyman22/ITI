using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace SignalRDemo.Hubs
{
    //Class set MEthod ==>Client 'Caller' call  
    public class ChatHub : Hub
    {
        static Dictionary<string,string> onlineClient=
            new Dictionary<string,string>();

        public override async Task OnConnectedAsync()
        {
            //onlineClient[Context.User.Identity.Name] 
            //    = Context.ConnectionId;
            // await  Clients.All.SendAsync("newUser", Context.User.Identity.Name);
        }
        public void AssignToGroup(string groupNAme)
        {
            //db 
            //Context.User.Claims.
            //FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Groups.AddToGroupAsync(Context.ConnectionId, groupNAme);
        }
        public void NewMessage(string name,string msg,int rate)//,string firendName)
        {
            //string cid = onlineClient[firendName];
            //Clients.Group("Student").SendAsync("NotifyNewMessage", name, msg);
            //logic
            //notify
            //Clients.Client(cid).SendAsync("NotifyNewMessage", name, msg);//RPC Call Method== >Client JS
            Clients.All.SendAsync("NotifyNewMessage",name,msg);//RPC Call Method== >Client JS
            //Clients.AllExcept(Context.ConnectionId).SendAsync("NotifyNewMessage", name, msg);
            //logic
        }
        //SignR Client  call RPC
        //public void method1()
        //{
        //   //any logic /DB
        //   //Notify

        //}
    }
}
