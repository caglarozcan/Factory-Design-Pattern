using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel.FactoryModel
{
	public class TxtLog : LogManager
	{
		public override void Save(string message)
		{
			Console.WriteLine("Log bilgisi .txt dosyasına kaydedildi. [" + message + "]");
		}
	}
}
