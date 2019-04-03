using MazeConsole.Converters;
using MazeConsole.Drawer;
using MazeLogic.Builders;
using MazeLogic.Engines;
using MazeLogic.Interfases.Converters;
using MazeModel.Helper;
using MazeModel.Interfases;
using MazeModel.Models;
using System;

namespace MazeConsole
{
    internal class Program
    {
        private static IConverter<IMaze, char[,]> _converter;
        private static SimpleDrawer _drawer;

        private static void Main(string[] args)
        {
            Console.WriteLine($"Press any key to start");
            Console.ReadKey();

            _converter = new MazeToCharConverter();
            _drawer = new SimpleDrawer();

            var gameBuilder = new MazeBuilder();
            // Динамически конфигурируем MazeBuilder
            gameBuilder.Builders.Add(new CoinBuilder(10)); // Тут можем указать количество монет в лабиринте
            var maze = gameBuilder.ConstrainMaze(5, 10);
            var hero = Hero.GetHero;

            var processor = GetProcessor(maze, hero);

            Draw(maze, hero);
            ConsoleKeyInfo key;
            do
            {
                if (hero.IsWin)
                {
                    Console.Clear();
                    Console.WriteLine("You win. Press any key to restart.");
                    Console.ReadKey();
                    key = new ConsoleKeyInfo('R', ConsoleKey.R, true, true, true);
                }
                else
                {
                    key = Console.ReadKey();
                }

                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        {
                            processor.Move(Direction.Up);
                            break;
                        }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        {
                            processor.Move(Direction.Right);
                            break;
                        }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            processor.Move(Direction.Down);
                            break;
                        }
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        {
                            processor.Move(Direction.Left);
                            break;
                        }
                    case ConsoleKey.R:
                        {
                            maze = gameBuilder.ConstrainMaze(5, 10);
                            processor = GetProcessor(maze, hero);
                            break;
                        }
                }
                Draw(maze, hero);
            } while (key.Key != ConsoleKey.Escape);
            Console.ReadLine();
        }

        private static void Draw(IMaze maze, Hero hero)
        {
            _drawer.Draw(_converter.Convert(maze));
            Console.WriteLine($"Heros skore {hero.CoinCount}");
            Console.WriteLine($"Maze skore {maze.CoinCount}");
        }

        private static Processor GetProcessor(IMaze maze, Hero hero)
        {
            var processor = new Processor(hero, maze);
            processor.ConfigurationList.Add(new ExitSetEngine(maze));
            processor.ConfigurationList.Add(new VictoryEngine(hero, maze));
            return processor;
        }
    }
}
