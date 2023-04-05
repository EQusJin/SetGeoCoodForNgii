using EGIS.ShapeFileLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGeoCoodForNgii
{
	public class SHPProperty
	{
		public Dictionary<string, string> Property { get; set; }
		public List<PointF> Polygon { get; set; }

		public SHPProperty(Dictionary<string, string> property, List<PointF> polygon)
		{
			Property = property;
			Polygon = polygon;
		}
	}

	public class SHPTools
	{
		public static List<SHPProperty> ReadSHP(string shpFile)
		{
			List<SHPProperty> propertyTable = new List<SHPProperty>();

			ShapeFile.MapFilesInMemory = true;
			ShapeFile sf = new ShapeFile(shpFile);
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			sf.RenderSettings.StringEncoding = Encoding.GetEncoding(51949);
			int recordIndex = 0;

			try
			{
				DbfReader dbfr = sf.RenderSettings.DbfReader;

				ShapeFileEnumerator sfEnum = sf.GetShapeFileEnumerator();

				while (sfEnum.MoveNext())
				{
					System.Collections.ObjectModel.ReadOnlyCollection<PointD[]> pointRecords = sfEnum.Current;

					foreach (PointD[] pts in pointRecords)
					{
						List<PointF> ptList = new List<PointF>();
						string[] fieldNames = dbfr.GetFieldNames();
						string[] fieldDesc = dbfr.GetFields(recordIndex).Select(d => d.TrimEnd()).ToArray();

						if (string.IsNullOrEmpty(fieldDesc[6]))
							fieldDesc[6] = fieldDesc[0];

						Dictionary<string, string> property = new Dictionary<string, string>();

						for (int i = 0; i < fieldNames.Length; i++)
							property.Add(fieldNames[i].Replace(" ", ""), fieldDesc[i].Replace(" ", ""));

						for (int n = 0; n < pts.Length; ++n)
							ptList.Add(new PointF((float)pts[n].X, (float)pts[n].Y));

						propertyTable.Add(new SHPProperty(property, ptList));
					}

					recordIndex++;
				}

				return propertyTable;
			}
			finally
			{
				sf.Close();
				sf.Dispose();
			}
		}
	}
}
