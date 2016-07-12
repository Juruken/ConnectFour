using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public interface IGameValidator
    {
        bool Validate(GameGrid gameGrid, Players player);
    }
}
