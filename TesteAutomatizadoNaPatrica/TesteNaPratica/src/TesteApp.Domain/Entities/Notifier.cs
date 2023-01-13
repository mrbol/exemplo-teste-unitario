using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApp.Domain.Entities
{
    public class Notifier
    {
        private List<ItemNotification> _notifications;

        public Notifier()
        {
            _notifications = new List<ItemNotification>();
        }

        public void Add(ItemNotification value) {
            _notifications.Add(value);
        }

        public List<ItemNotification> GetAll()
        {
            return _notifications;
        }

        public bool Exists()
        {
            return _notifications.Any();
        }
    }
}
