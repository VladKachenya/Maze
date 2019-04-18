using MazeLogicCore.Interfases.Converters;
using MazeModelCore.Interfases.ComplexModels;
using MazeWebApp.Helper.CustomerAttribute;

namespace MazeWebApp.Interfaces
{
    [MazeWebDi]
    public interface IMazeToCharConverter : IConverter<IMaze, char[,]>
    {
        
    }
}