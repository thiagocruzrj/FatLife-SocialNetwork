using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSocialNetwork.DomainModel.Interfaces.Repositories;

namespace TheSocialNetwork.DomainModel.Entities
{
    public class Post : EntityBase
    {
        public Profile Sender { get; set; }
        public Profile Recipient { get; set; }

        public Group Group { get; set; }

        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }

        public string PhotoUrl { get; set; }
        public string Review { get; set; }
        public decimal Price { get; set; }
        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5!")]
        public decimal Rate { get; set; }

        public Post()
        {
            PublishDateTime = DateTime.Now;
        }
    }
}
