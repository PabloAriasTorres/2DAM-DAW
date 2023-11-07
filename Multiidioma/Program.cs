using log4net;
using log4net.Config;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using Multiidioma;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace Multiidioma
{
    class Program
    {

        private static ILog configureLog()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("log4net.config"));
            return LogManager.GetLogger(typeof(Program));
        }

        static void Main(string[] args)
        {
            string json = File.ReadAllText("config.json"); // Carga la configuración desde el archivo JSON.
            Configuration config = JsonConvert.DeserializeObject<Configuration>(json);
            if (config == null)
            {
                throw new InvalidDataException();
            }



            var res_lang = new ResourceManager(config.Language);
            CultureInfo cultura = CultureInfoFactory.CreateCultureInfo(config.Language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultura;

            string mensaje = res_lang.GetString("String1");

            var logger = configureLog(); ;
            logger.Debug(mensaje);
            Console.ReadLine();
        }
    }
}