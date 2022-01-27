namespace HtbRp.Server
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using HtbRp.Shared.Domain;

    public class Players : IDisposable
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();
        private int _position = -1;

    
        public void Dispose()
        {
            _players.Clear();
            _players = null;
        }

        public int Count => _players.Count;


        public void AddPlayer(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.PlayerId == 0) throw new ArgumentException("PlayerId cannot be 0", nameof(player.PlayerId));

            _players.Add(player.PlayerId, player);

        }

        public void RemovePlayer(int playerId)
        {
            if (_players.ContainsKey(playerId))
            {
                _players.Remove(playerId);
            }
        }

        public Player this[int playerId] => _players[playerId];


    }
}
