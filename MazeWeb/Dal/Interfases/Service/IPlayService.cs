using Dal.Helper.CustomAttribute;
using Dal.Model;

namespace Dal.Interfases.Service
{
    [UseDi]
    public interface IPlayService
    {
        void Play(Game game);
    }
}