using MazeWebCore.Entities;
using MazeWebCore.Helpers.Attributes;

namespace MazeWebCore.Interfaces.Services
{

    [ForRegistration]
    public interface IPlayService
    {
        void Play(Game game);
    }
}