namespace ConnectFour.Validators
{
    public interface IGridCreationValidator
    {
        bool Validate(string rowsString, string columnsString);
    }
}
