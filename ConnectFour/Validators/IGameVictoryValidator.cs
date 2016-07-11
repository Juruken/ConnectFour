using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public interface IGameVictoryValidator
    {
        bool Validate(GameGrid gameGrid, Players player);
    }
}
