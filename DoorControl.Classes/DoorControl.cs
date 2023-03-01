using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl.Classes
{
	public class DoorControl : IDoorControl
	{
		private enum States
		{
			Opening,
			Closed,
			Breached,
			Closing
		};
		private readonly IDoor _door;
		private readonly IEntryUI _entryUi;
		private readonly IAlarm _alarm;
		private readonly IUserValidation _userValidation;
		private States _doorState;

		public DoorControl(IDoor door, IAlarm alarm, IUserValidation userValidation, IEntryUI entryUi)
		{
			_doorState = States.Closed;
			_door = door;
			_alarm = alarm;
			_userValidation = userValidation;
			_entryUi = entryUi;
		}

		public void RequestEntry(int id)
		{
			if (_userValidation.ValidateEntryRequest(id) && _doorState == States.Closed)
			{
				_doorState = States.Opening;
				_door.Open();
				_entryUi.NotifyEntryGranted(id);
			}
			else
			{
				_entryUi.NotifyEntryDenied(id);
			}
		}


		public void DoorOpened()
		{
			if (_doorState == States.Closed)
			{
				_doorState = States.Breached;
				_alarm.RaiseAlarm();

			}
			else if (_doorState == States.Opening)
			{
				//vent tid
				_door.Close();
				_doorState = States.Closing;
			}

		}

		public void DoorClosed()
		{
			_doorState = States.Closed;
			//alt er fint
		}
	}
}
