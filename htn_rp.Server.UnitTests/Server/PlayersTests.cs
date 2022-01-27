namespace htn_rp.Server.UnitTests
{
    using FluentAssertions;
    using HtbRp.Server;
    using HtbRp.Shared.Domain;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class PlayersTests
    {
        [Fact]
        public void AddPlayerSucceedsWithValidPlayer()
        {
            var sut = new Players();

            var player = new Player
            {
                PlayerId = 1
                
            };

            sut.AddPlayer(player);
            sut.Count.Should().Be(1);

        }

        [Fact]
        public void AddPlayerFailsWithNullPlayer()
        {
            var sut = new Players();

            Action action = () => sut.AddPlayer(null);
            action.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void AddPlayerFailsWithInvalidPlayerId()
        {
            var sut = new Players();

            var player = new Player
            {
                PlayerId = 0

            };

            Action action = () => sut.AddPlayer(player);
            action.Should().Throw<ArgumentException>();

        }

        [Fact]
        public void RemovePlayerRemovesWithValidPlayerId()
        {
            var sut = new Players();

            var player = new Player
            {
                PlayerId = 3

            };

            sut.AddPlayer(player);
            sut.Count.Should().Be(1);

            sut.RemovePlayer(player.PlayerId);
            sut.Count.Should().Be(0);

        }

        [Fact]
        public void RemovePlayerIgnoresWithInvalidPlayerId()
        {
            var sut = new Players();

            var player = new Player
            {
                PlayerId = 3

            };

            int invalidPlayerId = 5;

            sut.AddPlayer(player);
            sut.Count.Should().Be(1);

            sut.RemovePlayer(invalidPlayerId);
            sut.Count.Should().Be(1);

        }

        [Fact]
        public void IndexerRetrievesCorrectPlayer()
        {
            var sut = new Players();

            var steve = new Player
            {
                PlayerId = 3,
                Name = "Steve"
            };

            var john = new Player
            {
                PlayerId = 5,
                Name = "John"
            };

            sut.AddPlayer(steve);
            sut.AddPlayer(john);

            var player = sut[steve.PlayerId];
            player.Name.Should().Be(steve.Name);

        }

    }
}