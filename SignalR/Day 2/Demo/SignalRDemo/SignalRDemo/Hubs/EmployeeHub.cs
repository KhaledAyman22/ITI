using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Models;

namespace SignalRDemo.Hubs
{
    public class EmployeeHub:Hub
    {

        public void AddNEW(Employee emp)
        {
            
            //logic
            Clients.All.SendAsync("NotifyNewEmployee",emp);
            //Clients.Group("Asd").SendAsync....
            //logic
        }
    }
}
