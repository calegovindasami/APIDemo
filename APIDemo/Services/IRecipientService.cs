using APIDemo.Models;

namespace APIDemo.Services
{
    public interface IRecipientService
    {
        Recipient Add(Recipient recipient);
        void Delete(int id);
        List<Recipient> Get();
        Recipient Update(Recipient recipient);
    }
}
