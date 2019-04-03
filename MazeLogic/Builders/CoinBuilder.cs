using MazeLogic.Interfases.Builders;
using MazeModel.Interfases;
using MazeModel.Models;
using System;

namespace MazeLogic.Builders
{
    public class CoinBuilder : IBuilder
    {
        private readonly int _coinCont;
        private Random _random;

        public CoinBuilder(int coinCont)
        {
            _coinCont = coinCont;
            _random = new Random();
        }
        public void Build(ref IMaze maze)
        {
            int counter = 0;
            while (counter < _coinCont)
            {
                var randomPoint = GetRandomPoint(maze.Height, maze.Width);
                if (maze[randomPoint.Item1, randomPoint.Item2].IsEmpty)
                {
                    maze[randomPoint.Item1, randomPoint.Item2].Content = new Coin();
                    counter++;
                }

            }
        }
        private (int, int) GetRandomPoint(int height, int width)
        {
            return (_random.Next(height), _random.Next(width));
        }
    }
}
