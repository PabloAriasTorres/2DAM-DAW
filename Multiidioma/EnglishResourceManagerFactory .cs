using System.Reflection;


namespace Multiidioma
{
    internal class EnglishResourceManagerFactory : IResourceManagerFactory
    {
        public System.Resources.ResourceManager CreateResourceManager()
        {
            return new System.Resources.ResourceManager("Multiidioma.Resources.Resource_en", Assembly.GetExecutingAssembly());
        }
    }
}
