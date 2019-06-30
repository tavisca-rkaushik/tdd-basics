using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            var game = SetupGame();
            RollPins(game, 20, 0);
            Assert.Equal(0, game.GetScore);
        }
        [Fact]
        public void DummyTestHittingOnePinEveryTime()
        {
            var game = SetupGame();
            RollPins(game, 20, 1);
            Assert.Equal(20, game.GetScore);
        }
        [Fact]
        public void TestOneSpare()
        {
            var game = SetupGame();
            RollSpare(game);
            game.Roll(3);
            RollPins(game, 17, 0);
            Assert.Equal(16, game.GetScore);
        }
        [Fact]
        public void TestOneStrike()
        {
            var game = SetupGame();
            RollStrike(game);
            game.Roll(3);
            game.Roll(4);
            RollPins(game, 16, 0);
            Assert.Equal(24, game.GetScore);
        }
        [Fact]
        public void TestPerfectGame()
        {
            var game = SetupGame();
            RollPins(game, 12, 10);
            Assert.Equal(300, game.GetScore);
        }


        #region private methods
        private void RollStrike(Game game)
        {
            game.Roll(10);
        }
        private void RollSpare(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }
        private Game SetupGame()
        {
            return new Game();
        }
        private void RollPins(Game game, int NumberOfRolls, int PinsHitPerRoll)
        {
            for (int i = 0; i < NumberOfRolls; i++)
            {
                game.Roll(PinsHitPerRoll);
            }
        }
        #endregion
    }
}
