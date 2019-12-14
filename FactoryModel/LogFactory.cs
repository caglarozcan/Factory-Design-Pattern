using FactoryModel.FactoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
	public enum LogType
	{
		DatabaseLog,
		MailLog,
		TxtLog,
		XmlLog
	}

	public class LogFactory
	{
		public LogManager Creator(LogType logTipi)
		{
			LogManager lm = null;
			switch(logTipi)
			{
				case LogType.DatabaseLog:
					lm = new DatabaseLog();
					break;
				case LogType.MailLog:
					lm = new MailLog();
					break;
				case LogType.TxtLog:
					lm = new TxtLog();
					break;
				case LogType.XmlLog:
					lm = new XmlLog();
					break;
				default:
					return null;
			}

			return lm;
		}
	}

	
}
