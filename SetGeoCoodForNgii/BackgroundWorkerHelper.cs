using System.ComponentModel;

namespace SetGeoCoodForNgii
{
	class BackgroundWorkerHelper
	{
		public static void Run(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler completed = null, ProgressChangedEventHandler progressChanged = null)
		{
			using (var backgroundWorker = new BackgroundWorker())
			{
				backgroundWorker.DoWork += doWork;
				backgroundWorker.WorkerSupportsCancellation = true;
				if (completed != null)
					backgroundWorker.RunWorkerCompleted += completed;
				if (progressChanged != null)
				{
					backgroundWorker.WorkerReportsProgress = true;
					backgroundWorker.ProgressChanged += progressChanged;
				}
				backgroundWorker.RunWorkerAsync();
			}
		}
	}
}
