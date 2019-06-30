using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private List<int> _Rolls = new List<int>(21);
        private int _CurrentRoll = 0;
        public Game()
        {
            for(int i=0;i<22;i++)
            {
                _Rolls.Add(0);
            }
        }
        public void Roll(int pins)
        {
            _Rolls[_CurrentRoll++] = pins;
        }

        public int GetScore
        {
            get
            {
                int score = 0;
                int frameIndex = 0;
                for(int frame=0;frame<10;frame++)
                {
                    if (IsStrike(frameIndex))
                    {
                        //strike
                        score += 10 + StrikeBonus(frameIndex);
                        frameIndex ++;
                    }
                    else if(IsSpare(frameIndex))
                    {
                        //spare
                        score += 10 + SpareBonus(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += NormalBonus(frameIndex);
                        frameIndex += 2;
                    }
                }
                return score;
            }
        }

        private int NormalBonus(int frameIndex)
        {
            return _Rolls[frameIndex] + _Rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return _Rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return _Rolls[frameIndex + 1] + _Rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return _Rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return _Rolls[frameIndex] + _Rolls[frameIndex + 1] == 10;
        }
    }
}

