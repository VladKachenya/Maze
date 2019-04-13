using MazeLogic.Interfases.Builders;
using MazeModel.Interfases;
using MazeModel.Interfases.Base;
using System;
using MazeModel.Interfases.ComplexModels;

namespace MazeLogic.Builders
{
    public class CoinBuilder : IBuilder
    {
        private readonly int _coinCont;
        private readonly Func<IModelBase> _coinFactoryFunc;
        private Random _random;

        public CoinBuilder(int coinCont, Func<IModelBase> coinFactoryFunc)
        {
            _coinCont = coinCont;
            _coinFactoryFunc = coinFactoryFunc;
            _random = new Random();
        }

        public void Build(IMaze maze)
        {
            int counter = 0;
            while (counter < _coinCont)
            {
                var randomPoint = GetRandomPoint(maze.Height, maze.Width);
                if (maze[randomPoint.Item1, randomPoint.Item2].IsEmpty)
                {
                    maze[randomPoint.Item1, randomPoint.Item2].Content = _coinFactoryFunc();

                    counter++;
                }
            }
        }

        protected (int, int) GetRandomPoint(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException();
            }
            return (_random.Next(height), _random.Next(width));
        }
    }
}
