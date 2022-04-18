using HomeQCGauges.Services.Interfaces;

namespace HomeQCGauges.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
