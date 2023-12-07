using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotProblem
{
    //UC5
    interface ILotStatusObserver
    {
        void Update(bool isLotFull);

    }
}
