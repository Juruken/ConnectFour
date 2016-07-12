using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public interface IMoveValidator
    {
        bool Validate(GameGrid gameGrid, int column);
    }
}
