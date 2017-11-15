using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveRobot
{
    public class Table
    {
        public int mValue;
        public int nValue;

        public Table()
        {
            mValue = 5;
            nValue = 5;
        }

        public bool IsPositionExists(int xPosition, int yPosition)
        {
            return (XValueInRange(xPosition) && YValueInRange(yPosition));
        }

        private bool XValueInRange(int xPosition)
        {
            return (xPosition >= 0 && xPosition < mValue);
        }

        private bool YValueInRange(int yPosition)
        {
            return (yPosition >= 0 && yPosition < mValue);
        }
    }
}
