using Multiidioma;
using System.Globalization;
using System.Reflection;


namespace Multiidioma
{
    public class ResourceManager
    {
        private IResourceManagerFactory factory;
        private System.Resources.ResourceManager resourceManager;

        public ResourceManager(string language)
        {
            // Seleccionar la factoría adecuada según el idioma
            if (language == "en_EN")
            {
                factory = new EnglishResourceManagerFactory();
            }
            else if (language == "es_ES")
            {
                factory = new SpanishResourceManagerFactory();
            }
            else
            {
                throw new ArgumentException("Language not supported");
            }

            // Crear el resource manager usando la factoría
            resourceManager = factory.CreateResourceManager();
        }

        // Método que usa el resource manager para obtener una cadena de texto
        public string GetString(string name)
        {
            return resourceManager.GetString(name);
        }
    }
}