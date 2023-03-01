using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public class FakeDoor : IDoor
	{
		public int OpenTimesCalled { get; set; }
		public int CloseTimesCalled { get; set; }

		public FakeDoor()
		{
			OpenTimesCalled = 0;
			CloseTimesCalled = 0;
		}
		public void Open()
		{
			OpenTimesCalled++;
		}

		public void Close()
		{
			CloseTimesCalled++;
		}
	}
}
