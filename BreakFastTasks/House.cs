using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakFastTasks
{
	internal class House
	{
		bool isDoorLocked = false;

		public event EventHandler OnDoorOpened;

		public void OpenDoor()
		{
			if (!isDoorLocked)
			{
				Console.WriteLine("Door is opened.");
				OnDoorOpened?.Invoke(this, new EventArgs());
			}
			
		}
	}
}
