using System.Windows.Forms;

namespace SetGeoCoodForNgii
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			BtnFileOpen = new Button();
			BtnRun = new Button();
			FileGridView = new DataGridView();
			GridFilename = new DataGridViewTextBoxColumn();
			GridIndexNum = new DataGridViewTextBoxColumn();
			GridExtend = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)FileGridView).BeginInit();
			SuspendLayout();
			// 
			// BtnFileOpen
			// 
			BtnFileOpen.Location = new Point(12, 12);
			BtnFileOpen.Name = "BtnFileOpen";
			BtnFileOpen.Size = new Size(94, 29);
			BtnFileOpen.TabIndex = 0;
			BtnFileOpen.Text = "열기";
			BtnFileOpen.UseVisualStyleBackColor = true;
			BtnFileOpen.Click += BtnFileOpen_Click;
			// 
			// BtnRun
			// 
			BtnRun.Enabled = false;
			BtnRun.Location = new Point(112, 12);
			BtnRun.Name = "BtnRun";
			BtnRun.Size = new Size(94, 29);
			BtnRun.TabIndex = 1;
			BtnRun.Text = "시작";
			BtnRun.UseVisualStyleBackColor = true;
			BtnRun.Click += BtnRun_Click;
			// 
			// FileGridView
			// 
			FileGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			FileGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			FileGridView.BackgroundColor = SystemColors.Control;
			FileGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			FileGridView.Columns.AddRange(new DataGridViewColumn[] { GridFilename, GridIndexNum, GridExtend });
			FileGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
			FileGridView.Location = new Point(11, 48);
			FileGridView.Margin = new Padding(3, 4, 3, 4);
			FileGridView.MultiSelect = false;
			FileGridView.Name = "FileGridView";
			FileGridView.ReadOnly = true;
			FileGridView.RowHeadersWidth = 51;
			FileGridView.RowTemplate.Height = 23;
			FileGridView.ScrollBars = ScrollBars.Vertical;
			FileGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			FileGridView.Size = new Size(1036, 455);
			FileGridView.TabIndex = 2;
			FileGridView.RowPostPaint += FileGridView_RowPostPaint;
			// 
			// GridFilename
			// 
			GridFilename.HeaderText = "파일명";
			GridFilename.MinimumWidth = 6;
			GridFilename.Name = "GridFilename";
			GridFilename.ReadOnly = true;
			GridFilename.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// GridIndexNum
			// 
			GridIndexNum.HeaderText = "도곽번호";
			GridIndexNum.MinimumWidth = 6;
			GridIndexNum.Name = "GridIndexNum";
			GridIndexNum.ReadOnly = true;
			GridIndexNum.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// GridExtend
			// 
			GridExtend.HeaderText = "도곽범위(LeftTop XY), (RightBottom XY)";
			GridExtend.MinimumWidth = 6;
			GridExtend.Name = "GridExtend";
			GridExtend.ReadOnly = true;
			GridExtend.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1059, 516);
			Controls.Add(FileGridView);
			Controls.Add(BtnRun);
			Controls.Add(BtnFileOpen);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "지리원 정사영상 좌표입력 프로그램 (only for 1:5000)";
			((System.ComponentModel.ISupportInitialize)FileGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button BtnFileOpen;
		private Button BtnRun;
		private DataGridView FileGridView;
		private DataGridViewTextBoxColumn GridFilename;
		private DataGridViewTextBoxColumn GridIndexNum;
		private DataGridViewTextBoxColumn GridExtend;
	}
}