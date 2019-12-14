using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel.FactoryModel
{
	public class DatabaseLog : LogManager	
	{
		public override void Save(string message)
		{
			Console.WriteLine("Log bilgisi veritabanına kaydedildi. [" + message + "]");
		}
	}
}
