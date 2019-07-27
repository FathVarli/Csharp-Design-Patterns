using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //önemli bir desen
            //farklı bir sistemin kendi sistemimize eklenmesi sonucu kendi sistemimiz gibi çalışmasına diyebiliriz.
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
       private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("Logged the data!");
            Console.WriteLine("Saved!");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged : {0}", message);
        }
    }
    //Nugetten indirdik.Yani baskası tarafından oluşturulmuş ve biz değişiklik yapamıyoruz.
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4Net : {0}", message);
        }
    }
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
