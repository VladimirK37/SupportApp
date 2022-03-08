using Microsoft.Extensions.Configuration;
using SupportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApp.Repository
{
    public class MessagesRepository
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContext context;

        public MessagesRepository(IConfiguration configuration, AppDbContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public List<Messages> GetAllMessages()
        {
            var messages = context.Messages.ToList();
            return messages;
        }

        public void AddMessages(Messages messages)
        {
            context.Messages.Add(messages);
            context.SaveChanges();
        }

        public void DeleteMessages(int id)
        {
            var message = context.Messages.FirstOrDefault(x => x.Id == id);

            context.Messages.Remove(message);
            context.SaveChanges();
        }

        public Messages GetMessages(int id)
        {
            return context.Messages.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMessages(Messages messages)
        {
            context.Messages.Update(messages);
            context.SaveChanges();
        }
    }
}
