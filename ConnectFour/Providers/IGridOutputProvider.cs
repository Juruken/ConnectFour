using ConnectFour.DataModel;

namespace ConnectFour.Providers
{
    public interface IGridOutputProvider
    {
        void Output(GameGrid gameGrid);
    }
}
