using DoorControl.Classes;

namespace DoorControl.Test.Unit
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(1)]
		[TestCase(5)]
		[TestCase(0)]
		public void TestRequestEntry_ValidateEntryRequestIsCalled(int callTimes)
		{
			var alarm = new FakeAlarm();
			var door = new FakeDoor();
			var entryUi = new FakeEntryUI();
			var userValidation = new FakeUserValidation(true);
			var doorControl = new Classes.DoorControl(door, alarm, userValidation, entryUi);

			for (int i = 0; i < callTimes; i++)
			{
				doorControl.RequestEntry(5);
			}


			Assert.That(userValidation.ValidateTimesCalled, Is.EqualTo(callTimes));
		}

		[TestCase(1, 1)]
		[TestCase(5, 1)]
		[TestCase(0, 0)]
		public void TestRequestEntry_NotifyEntryGrantedIsCalled(int callTimes, int actualCallTimes)
		{
			var alarm = new FakeAlarm();
			var door = new FakeDoor();
			var entryUi = new FakeEntryUI();
			var userValidation = new FakeUserValidation(true);
			var doorControl = new Classes.DoorControl(door, alarm, userValidation, entryUi);

			for (int i = 0; i < callTimes; i++)
			{
				doorControl.RequestEntry(5);
			}


			Assert.That(entryUi.GrantedTimesCalled, Is.EqualTo(actualCallTimes));
		}

		[TestCase(1, 1)]
		[TestCase(5, 5)]
		[TestCase(0, 0)]
		public void TestRequestEntry_NotifyEntryDeniedIsCalled(int callTimes, int actualCallTimes)
		{
			var alarm = new FakeAlarm();
			var door = new FakeDoor();
			var entryUi = new FakeEntryUI();
			var userValidation = new FakeUserValidation(false);
			var doorControl = new Classes.DoorControl(door, alarm, userValidation, entryUi);

			for (int i = 0; i < callTimes; i++)
			{
				doorControl.RequestEntry(5);
			}


			Assert.That(entryUi.DeniedTimesCalled, Is.EqualTo(actualCallTimes));
		}

		[TestCase(1, 1)]
		[TestCase(5, 1)]
		[TestCase(0, 0)]
		public void TestRequestEntry_OpenIsCalled(int callTimes, int actualCallTimes)
		{
			var alarm = new FakeAlarm();
			var door = new FakeDoor();
			var entryUi = new FakeEntryUI();
			var userValidation = new FakeUserValidation(true);
			var doorControl = new Classes.DoorControl(door, alarm, userValidation, entryUi);

			for (int i = 0; i < callTimes; i++)
			{
				doorControl.RequestEntry(5);
			}


			Assert.That(door.OpenTimesCalled, Is.EqualTo(actualCallTimes));
		}

		[Test]
		public void TestDoorOpened_DoorControlStateIsClosed_RaiseAlarmIsCalled()
		{
			var alarm = new FakeAlarm();
			var door = new FakeDoor();
			var entryUi = new FakeEntryUI();
			var userValidation = new FakeUserValidation(true);
			var doorControl = new Classes.DoorControl(door, alarm, userValidation, entryUi);

			doorControl.DoorOpened();

			Assert.That(alarm.RaiseAlarmTimesCalled, Is.EqualTo(1));
		}
}
}