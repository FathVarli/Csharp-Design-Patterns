using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            //birden fazla nesneyi tek bir yerde toplayıp sadeleştirme yapma işidir.
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }
   public class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Cached!");
        }

       
    }

    internal interface ILogging
    {
        void Log();
    }

    public class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Logged!");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    public class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked!");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    public class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }
    class CustomerManager
    {
        private CrassCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrassCuttongConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();
            _concerns.Validate.Validate();
            Console.WriteLine("Saved!");
        }
    }

    class CrassCuttongConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;

        public CrassCuttongConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validation();
        }
    }
}
