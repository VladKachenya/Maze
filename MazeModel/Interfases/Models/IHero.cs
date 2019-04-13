using MazeModel.Interfases.Base;

namespace MazeModel.Interfases.Models
{
    public interface IHero : IModelBase, ICollector, ICoinContainer
    {
        bool IsWin { get; set; }
    }
}