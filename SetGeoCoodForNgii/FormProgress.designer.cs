namespace SetGeoCoodForNgii
{
	partial class FormProgress
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lbMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(234, 110);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCancel.Name = "buttonCancel";
			this.btnCancel.Size = new System.Drawing.Size(99, 26);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(19, 76);
			this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(314, 26);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar.TabIndex = 5;
			// 
			// lbMessage
			// 
			this.lbMessage.Location = new System.Drawing.Point(19, 2);
			this.lbMessage.Name = "lbMessage";
			this.lbMessage.Size = new System.Drawing.Size(314, 70);
			this.lbMessage.TabIndex = 4;
			this.lbMessage.Text = "준비중입니다...";
			this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(357, 155);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.lbMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormProgress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormProgress";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lbMessage;
	}
}