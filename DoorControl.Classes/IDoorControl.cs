using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public interface IDoorControl
	{
		void RequestEntry(int id);
		void DoorClosed();
		void DoorOpened();
	}
}
