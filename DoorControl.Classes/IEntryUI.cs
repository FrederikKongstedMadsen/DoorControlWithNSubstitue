using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public interface IEntryUI
	{
		void NotifyEntryGranted(int id);
		void NotifyEntryDenied(int id);
	}
}
