using System;
using System.CodeDom;
using System.Linq;
using System.Threading;
using Homework.Floors;

namespace Homework
{
    public class Elevator
    {
        public string[] floors = new[] {nameof(GFloor), nameof(SFloor), nameof(T1Floor), nameof(T2Floor)};
        public string CurrentFloor { get; private set; }

        public void ChangeElevatorPosition(string floorDestination)
        {
            if (!this.floors.Contains(floorDestination))
            {
                Console.WriteLine("Invalid floor");
            }
            else
            {
                this.CurrentFloor = floorDestination;
            }
        }
    }
}
