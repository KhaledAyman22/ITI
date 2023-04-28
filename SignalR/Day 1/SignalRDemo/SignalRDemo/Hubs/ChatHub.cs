using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Hubs
{
    //Class set MEthod ==>Client 'Caller' call  
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
           // await  Clients.All.SendAsync("newUser", Context.User.Identity.Name);
        }
        public void NewMessage(string name,string msg,int rate)
        {
            //logic
            //notify
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
