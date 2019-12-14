using FactoryModel.FactoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
	class Program
	{
		static void Main(string[] args)
		{
			LogFactory logFactory = new LogFactory();
			LogManager logManager = null;

			logManager = logFactory.Creator(LogType.DatabaseLog);
			logManager.Save("Hata!!");

			logManager = logFactory.Creator(LogType.MailLog);
			logManager.Save("Hata!!");

			logManager = logFactory.Creator(LogType.TxtLog);
			logManager.Save("Hata!!");

			logManager = logFactory.Creator(LogType.XmlLog);
			logManager.Save("Hata!!");

			Console.Read();
		}
	}
}
