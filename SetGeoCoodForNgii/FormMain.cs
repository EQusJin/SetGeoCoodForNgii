using OSGeo.GDAL;
using System.ComponentModel;

namespace SetGeoCoodForNgii
{
	partial class FormMain : Form
	{
		List<NGII>? NGIImages = null;
		List<SHPProperty>? StdIndex = null;

		public FormMain()
		{
			InitializeComponent();

			GdalConfiguration.ConfigureGdal();
		}

		private void BtnFileOpen_Click(object sender, EventArgs e)
		{
			StdIndex = SHPTools.ReadSHP($"{Environment.CurrentDirectory}\\MAPINDX_5K\\MAPINDX_5K_BUF_J_5186.shp");

			SetNGIIProperty(FileOpen());

			if (NGIImages != null)
				UpdateStatusGrid();
		}

		// gdal_translate -a_srs EPSG:5186 -of GTiff -a_ullr 206619.309999999 497391.01 208945.339999999 494514.489999999 "D:/Down/test/(B060)정사영상_2022_37713074.tif" D:/Down/test/tiff/aaa.tif
		private void BtnRun_Click(object sender, EventArgs e)
		{
			if (NGIImages == null)
				return;

			int imageCnt = NGIImages.Count(d => string.IsNullOrEmpty(d.Msg));

			FormProgress formProgress = new FormProgress
			{
				ProgressStyle = ProgressBarStyle.Blocks,
				ProgressValue = 0,
				ProgressMaximun = imageCnt
			};

			// 각 단계별 정합성검사 수행
			BackgroundWorkerHelper.Run
			(
				// dowork
				(s, ea) =>
				{
					int cnt = 1;
					foreach (var ngii in NGIImages)
					{
						if (string.IsNullOrEmpty(ngii.Msg))
						{
							using (Dataset ds = Gdal.Open($"{ngii.Path}\\{ngii.Name}", Access.GA_Update))
							{

								GDALTranslateOptions opts = new GDALTranslateOptions(new string[]
														   {"-a_srs", "EPSG:5186",
															"-of", "GTiff",
															"-a_ullr", $"{ngii.LeftTop5k.X}", $"{ngii.LeftTop5k.Y}", $"{ngii.RightBottom5k.X}", $"{ngii.RightBottom5k.Y}" });

								((BackgroundWorker)s).ReportProgress(cnt++, $"{ngii.Name} 파일에 좌표계를 설정합니다.");

								try
								{
									Gdal.wrapper_GDALTranslate($"{ngii.Path}\\(GTiff)_{ngii.Name}", ds, opts, null, null);
								}
								catch (Exception ex)
								{
									MessageBox.Show($"좌표계 설정중 오류가 발생하였습니다.\r\n\r\n{ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}

								Thread.Sleep(1000);
							}
						}
					}
				},
				// complete
				(s, ea) =>
				{
					formProgress.Close();
					MessageBox.Show($"{imageCnt}개 파일의 좌표계 설정이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
				},
				// reportProgress
				(s, ea) =>
				{
					formProgress.Message = $"{ea.UserState} ({ea.ProgressPercentage} / {imageCnt})";
					formProgress.ProgressValue = ea.ProgressPercentage;
				}
			);

			formProgress.ShowDialog();


		}

		private void UpdateStatusGrid()
		{
			FileGridView.Rows.Clear();

			if (NGIImages == null)
				return;

			foreach (var ngii in NGIImages)
			{
				if (string.IsNullOrEmpty(ngii.Msg))
					FileGridView.Rows.Add(ngii.Name, ngii.IndexNum, $"({ngii.LeftTop5k.X} {ngii.LeftTop5k.Y}), ({ngii.RightBottom5k.X} {ngii.RightBottom5k.Y})");
				else
					FileGridView.Rows.Add(ngii.Name, ngii.Msg, "");
			}

			if (NGIImages.Count(d => string.IsNullOrEmpty(d.Msg)) != 0)
				BtnRun.Enabled = true;
		}

		private void SetNGIIProperty(List<string> selectedFiles)
		{
			if (selectedFiles == null)
				return;

			NGIImages = new List<NGII>();

			foreach (string file in selectedFiles)
			{
				string indexNum = System.Text.RegularExpressions.Regex.Match(file, @"(?<!\d)\d{8}(?!\d)").ToString();

				var index = StdIndex.FirstOrDefault(d => d.Property["Text"].Equals(indexNum) || d.Property["MAPIDCD_NO"].Equals(indexNum));

				if (index != null)
					NGIImages.Add(new NGII(Path.GetFileName(file), Path.GetDirectoryName(file), indexNum, index.Polygon[0], index.Polygon[2], ""));
				else
					NGIImages.Add(new NGII(Path.GetFileName(file), Path.GetDirectoryName(file), "", new PointF(-1.0f, -1.0f), new PointF(-1.0f, -1.0f), "도곽번호없음"));
			}
		}

		private List<string>? FileOpen()
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog
				{
					Multiselect = true,
					Title = $"Select File",
					Filter = $"NGII Image Files(*.tif) | *.tif"
				};

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					return ofd.FileNames.ToList();
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		private void FileGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			var grid = sender as DataGridView;
			var rowIdx = (e.RowIndex + 1).ToString();

			var centerFormat = new StringFormat()
			{
				// right alignment might actually make more sense for numbers
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};

			var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
			e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
		}
	}
}