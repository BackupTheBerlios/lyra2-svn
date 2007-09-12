using System.Threading;

namespace lyra2
{
	/// <summary>
	/// Summary description for DelayedTask.
	/// </summary>
	public class DelayedTask
	{
		private bool abort = false;
		private int delayMillis;
		private Thread taskThread;
		
		public DelayedTask(ThreadStart task, int delayMillis)
		{
			this.taskThread = new Thread(task);
			this.delayMillis = delayMillis;
		}
		
		public void Start()
		{
			(new Thread(new ThreadStart(this.startTask))).Start();
		}
		
		private void startTask()
		{
			Thread.Sleep(this.delayMillis);
			if(!this.abort)
			{
				this.taskThread.Start();
			}
		}
		
		public void Abort()
		{
			this.abort = true;
		}
	}
}
