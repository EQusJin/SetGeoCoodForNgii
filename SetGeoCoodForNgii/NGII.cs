using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGeoCoodForNgii
{
	public class NGII
	{
		public string Name { get; private set; }
		public string? Path { get; private set; }
		public string IndexNum { get; private set; }
		public PointF LeftTop5k { get; private set; }
		public PointF RightBottom5k { get; private set; }
		public string Msg { get; private set; }

		public NGII(string name, string? path, string indexNum, PointF leftTop5k, PointF rightBottom5k, string msg)
		{
			Name = name;
			Path = path;
			IndexNum = indexNum;
			LeftTop5k = leftTop5k;
			RightBottom5k = rightBottom5k;
			Msg = msg;
		}
	}
}
