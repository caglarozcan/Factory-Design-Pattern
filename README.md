## Factory (Fabrika) Tasarım Deseni
Factory tasarım deseni, aynı interface (arayüz) veya aynı abstract (sanal) sınıftan türeyen nesnelerin üretiminden sorumlu desendir. Bu tasarım deseninde nesne oluşturma işi, kalıtım (inheritance) yöntemi ile istemci tarafından ayırıp alt sınıflara ayrılarak yerine getirilir.

Bu tasarım deseni ile yeni bir ürün (class - sınıf) eklemek daha basit ve daha az değişiklik ile projeye uygulanır. Bu sayede istemci (client) tarafı bu değişiklikten hiç etkilenmemiş olur. Yani istemci tarafında hiç değişiklik yapmadan ya da ufak, basit değişiklikler ile istenen güncelleme işlemi yapılmış olur. Ayrıca nesnelerin bir birine olan bağımlılığı azaltılarak daa esnek uygulamalar geliştirilir.


![Image of Class](https://raw.githubusercontent.com/caglarozcan/Factory-Design-Pattern/master/FactoryModel/Factory-Model-Class-Diagram.png)

Yukarıda verilen class diyagramında, değişik ortamlarda log tutan bir mekanizma tasarlanmıştır. Veritabanı, metin dosyası, XML dosyası ve mail gönderme olmak üzere dört farklı ortamda log tutma işlemi yapılmaktadır.  Her ortamda log almayı sağlayacak sınıflar tasarlanmıştır, çünkü her ortamda log kaydedilmesi farklı işlemlerin yerine getirilmesini gerektirir. Değişik ortamlarda log tutma işlemini yerine getirecek olan sınıflar LogManager isimli Abstract sınıftan türetilmektedir. Abstract sınıf içerisinde tüm alt sınıflarda ortak olan log tutma işlemini yerine getirecek, string olarak log mesajını parametre alan `Save(string messae)` metodu tanımlanmıştır.

```csharp
public abstract class LogManager
{
	public abstract void Save(string message);
}
```
`LogFactory` sınıfı içerisinde log tipi için enum değişken tanımlanmıştır. LogFactory sınıfı içerisinde yer alan `Creator` metodu parametre olarak `LogType` enum değerini almaktadır. Gelen enum değerine göre LogManager lm isimli değişkene ilgili log türünü tutacak sınıfın nesnesi oluşturulur ve geri döndürülür.

```csharp
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
```
Log alma işlemini yerine getiren sınıflar ise LogManager abstract (sanal) sınıfı ile implemente edilmiştir. Örnek olarak veritabanında log tutma işlemi yapan `DatabaseLog` sınıfı;

```csharp
public class DatabaseLog : LogManager	
{
    public override void Save(string message)
    {
    	Console.WriteLine("Log bilgisi veritabanına kaydedildi. [" + message + "]");
    }
}
```
Log alma işlemi için, hangi ortamda kayıt yapılacaksa o ortama iat `..Logger` sınıfı nesnesi LogManager sınıfının constructor metoduna paramete olarak verilir.
```csharp
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
```
Yukarıdaki örnek uygulamada LogFactory sınıfından bir nesne oluşturulur; Creator metodu ile LogManager lm değişkenine belirtilen log türünde kayıt tutacak olan nesne oluşturulur ve atama yapılır. lm değişkeni içerisinden Save() metodu çağrılarak log tutma işlemi gerçekleştirilir.
