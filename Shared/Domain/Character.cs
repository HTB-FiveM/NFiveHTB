using System;
using System.Collections.Generic;

namespace HtbRp.Shared.Domain
{
    public class Character
    {
        public int Id { get; set; }
        public string CitizenId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public List<Item> Inventory { get; set; }


        public int PlayerId { get; set; }

    }
}
