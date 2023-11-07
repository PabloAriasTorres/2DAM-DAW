using System.Reflection;

namespace Multiidioma
{
    internal class SpanishResourceManagerFactory : IResourceManagerFactory
    {
        public System.Resources.ResourceManager CreateResourceManager()
        {
            return new System.Resources.ResourceManager("Multiidioma.Resources.Resource_es", Assembly.GetExecutingAssembly());
        }
    }
}
