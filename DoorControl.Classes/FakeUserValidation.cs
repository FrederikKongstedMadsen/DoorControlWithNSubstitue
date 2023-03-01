using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public class FakeUserValidation : IUserValidation
	{
		public int ValidateTimesCalled { get; set; }
		private bool access { get; set; }

		public FakeUserValidation(bool access)
		{
			this.access = access;
			ValidateTimesCalled = 0;
		}
		public bool ValidateEntryRequest(int id)
		{
			ValidateTimesCalled++;
			return access;
		}
	}
}
