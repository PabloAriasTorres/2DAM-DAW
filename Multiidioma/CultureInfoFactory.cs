using System.Globalization;

namespace Multiidioma
{
    public static class CultureInfoFactory
    {
        public static CultureInfo CreateCultureInfo(string language)
        {
            try
            {
                return new CultureInfo(language);
            }
            catch (CultureNotFoundException)
            {
                // Handle the case where the culture is not found, perhaps provide a default culture.
                return new CultureInfo("en-US"); // Default to English (or another suitable default).
            }
        }
    }
}