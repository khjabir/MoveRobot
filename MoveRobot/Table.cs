

namespace MoveRobot
{
    public class Table
    {
        #region Private Members

        private int rowValue;
        private int columnValue;

        #endregion

        #region Constructor

        public Table()
        {
            rowValue = 5;
            columnValue = 5;
        }

        #endregion

        #region Public Methods

        public int getRowValue()
        {
            return rowValue;
        }

        public int getColumnValue()
        {
            return columnValue;
        }

        public bool IsPositionExists(int xPosition, int yPosition)
        {
            return (XValueInRange(xPosition) && YValueInRange(yPosition));
        }

        #endregion

        #region Private Methods

        private bool XValueInRange(int xPosition)
        {
            return (xPosition >= 0 && xPosition < columnValue);
        }

        private bool YValueInRange(int yPosition)
        {
            return (yPosition >= 0 && yPosition < rowValue);
        }

        #endregion
    }
}
