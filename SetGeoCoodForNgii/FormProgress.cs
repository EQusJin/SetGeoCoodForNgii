namespace SetGeoCoodForNgii
{
	public partial class FormProgress : Form
	{
		public int ProgressMaximun
		{
			set { progressBar.Maximum = value; }
		}

		public string Message
		{
			set { lbMessage.Text = value; }
		}

		public int ProgressValue
		{
			set { progressBar.Value = value; }
		}

		public ProgressBarStyle ProgressStyle
		{
			set { progressBar.Style = value; }
		}

		public FormProgress()
		{
			InitializeComponent();
		}

		public event EventHandler<EventArgs> Canceled;

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			// Create a copy of the event to work with
			EventHandler<EventArgs> ea = Canceled;
			/* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
			if (ea != null)
				ea(this, e);
		}
	}
}

