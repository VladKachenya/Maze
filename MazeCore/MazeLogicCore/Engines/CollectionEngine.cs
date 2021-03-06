﻿using MazeLogicCore.Interfases.Engines;
using MazeModelCore.Helper;
using MazeModelCore.Interfases;

namespace MazeLogicCore.Engines
{
    public class CollectionEngine : IEngine
    {
        private readonly ICollector _collector;
        private readonly ICoinContainer _coinContainer;
        private int _previousValue;

        public CollectionEngine(ICollector collector, ICoinContainer coinContainer)
        {
            _collector = collector;
            _coinContainer = coinContainer;
            _previousValue = _coinContainer.CoinCount;
        }
        public void Move(Direction direction)
        {
            int currentVallue = _coinContainer.CoinCount;
            if (_previousValue > currentVallue)
            {
                _previousValue = currentVallue;
                _collector.Collect();
            }
        }
    }
}