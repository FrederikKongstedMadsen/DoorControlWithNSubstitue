using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public class FakeEntryUI : IEntryUI
	{
		public int GrantedTimesCalled { get; set; }
		public int DeniedTimesCalled { get; set; }

		public FakeEntryUI()
		{
			GrantedTimesCalled = 0;
			DeniedTimesCalled = 0;
		}
		public void NotifyEntryGranted(int id)
		{
			GrantedTimesCalled++;
		}

		public void NotifyEntryDenied(int id)
		{
			DeniedTimesCalled++;
		}
	}
}
