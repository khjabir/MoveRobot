

namespace MoveRobot
{
    public class Table
    {
        #region Private Members

        private int rowCount;
        private int columnCount;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        public Table()
        {
            rowCount = 5;
            columnCount = 5;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the row count of table.
        /// </summary>
        /// <returns> rowCount </returns>
        public int GetRowCount()
        {
            return rowCount;
        }

        /// <summary>
        /// Gets the column count of table.
        /// </summary>
        /// <returns> columnCount </returns>
        public int GetColumnCount()
        {
            return columnCount;
        }

        /// <summary>
        /// Determines whether the specified x and y position exists in the table.
        /// </summary>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <returns>
        ///   <c>true</c> if [is position exists]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPositionExists(int xPosition, int yPosition)
        {
            return (XValueInRange(xPosition) && YValueInRange(yPosition));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Determines whether the specified x value in range.
        /// </summary>
        /// <param name="xPosition">The x position.</param>
        /// <returns></returns>
        private bool XValueInRange(int xPosition)
        {
            return (xPosition >= 0 && xPosition < columnCount);
        }

        /// <summary>
        /// Determines whether the specified y value in range.
        /// </summary>
        /// <param name="yPosition">The y position.</param>
        /// <returns></returns>
        private bool YValueInRange(int yPosition)
        {
            return (yPosition >= 0 && yPosition < rowCount);
        }

        #endregion
    }
}
