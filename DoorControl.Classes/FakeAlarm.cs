using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public class FakeAlarm : IAlarm
	{
		public int RaiseAlarmTimesCalled { get; set; }

		public FakeAlarm()
		{
			RaiseAlarmTimesCalled = 0;
		}
		public void RaiseAlarm()
		{
			RaiseAlarmTimesCalled++;
		}
	}
}
