using APIDemo.Models;

namespace APIDemo.Services
{
    public class RecipientService : IRecipientService
    {
        public Recipient Add(Recipient recipient)
        {
            Random rng = new();
            recipient.Id = rng.Next(0, 1000000);
            MemoryService.Recipients.Add(recipient);
            return recipient;
        }

        public void Delete(int id)
        {
            MemoryService.Recipients.RemoveAll(recipient => recipient.Id == id);
        }

        public List<Recipient> Get()
        {
            return MemoryService.Recipients;
        }

        public Recipient Update(Recipient recipient)
        {
            var record = MemoryService.Recipients.FirstOrDefault(recipient => recipient.Id == recipient.Id);
            if (record != null)
            {
                record.FirstName = recipient.FirstName;
                record.LastName = recipient.LastName;
                return record;
            }
            return recipient;
        }
    }
}
