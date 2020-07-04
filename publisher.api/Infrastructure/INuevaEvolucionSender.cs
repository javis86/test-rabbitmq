using publisher.api;

namespace publisher.api.Infrastructure.Messaging
{
    public interface INuevaEvolucionSender
    {
        void SendCustomer(EvolucionMessage customer);
    }
}