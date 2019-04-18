using MazeModelCore.Interfases.Base;

namespace MazeModelCore.Interfases.Models
{
    public interface IHero : IModelBase, ICollector, ICoinContainer
    {
        bool IsWin { get; set; }
    }
}