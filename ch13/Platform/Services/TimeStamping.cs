namespace Platform.Services
{
	public interface ITimeStamper
	{
		string TimeStamp { get; set; }
	}
	public class TimeStamping
	{
		public string TimeStamp
		{
			get => DateTime.Now.ToShortTimeString();
		}
	}
}