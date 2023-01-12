using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApp.Domain.Entities
{
    public class Notifier
    {
        private List<String> _notifications;

        public Notifier()
        {
            _notifications = new List<String>();
        }

        public void Add(string value) {
            _notifications.Add(value);
        }

        public List<string> GetAll()
        {
            return _notifications;
        }

        public bool Exists()
        {
            return _notifications.Any();
        }
    }
}
