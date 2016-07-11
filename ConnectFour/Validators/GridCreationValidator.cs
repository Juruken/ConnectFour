namespace ConnectFour.Validators
{
    /// <summary>
    /// Validates whether the number of rows and columns are valid for game grid creation
    /// </summary>
    public class GridCreationValidator : IGridCreationValidator
    {
        private const int MINIMUM_ROWS = 5;
        private const int MINIMUM_COLUMNS = 5;
        private const int MAXIMUM_ROWS = 6;
        private const int MAXIMUM_COLUMNS = 7;

        /// <summary>
        /// Expects direct user input as strings. Will validate if the expected input are string integers.
        /// </summary>
        /// <param name="rowsString"></param>
        /// <param name="columnsString"></param>
        /// <returns></returns>
        public bool Validate(string rowsString, string columnsString)
        {
            int rows;
            int columns;

            if (!int.TryParse(rowsString, out rows))
                return false;
            
            if (!int.TryParse(columnsString, out columns))
                return false;

            if (rows < MINIMUM_ROWS || rows > MAXIMUM_ROWS)
                return false;

            if (columns < MINIMUM_COLUMNS || columns > MAXIMUM_COLUMNS)
                return false;

            return true;
        }
    }
}
