﻿using System;
using MazeGameConsole.Converters;
using MazeGameConsole.Drawer;
using MazeLogicCore.Builders;
using MazeLogicCore.Engines;
using MazeLogicCore.Interfases.Converters;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Models;

namespace MazeGameConsole
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

            var hero = new Hero();
            var maze = new MazeBuilder(hero).ConstrainMaze(5, 10);
            var processor = new Processor(hero, maze);

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
                            hero = new Hero();
                            maze = new MazeBuilder(hero).ConstrainMaze(5, 10);
                            processor = new Processor(hero, maze);
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
    }
}
