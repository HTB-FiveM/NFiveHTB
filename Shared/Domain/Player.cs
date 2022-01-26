namespace HtbRp.Shared.Domain
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public int Id { get; set; }
        public List<string> Identifiers { get; set; }
        public string License { get; set; }
        public string Name { get; set; }
        public DateTime ConnectDateTime { get; set; }
        public DateTime? DisconnectDateTime { get; set; }



    }
}
