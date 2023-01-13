using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApp.Domain.Entities
{
    public class ItemNotification
    {
        public ItemNotification()
        {
            Name = String.Empty;
            Description= String.Empty;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
