using System.IO;

namespace RaidMaker.Tests.Helpers
{
    public class EmbeddedResourceHelper
    {
        public static string GetLinesFromEmbeddedResource(string path)
        {
            var assembly = typeof(EmbeddedResourceHelper).Assembly;
            using (var reader = new StreamReader(assembly.GetManifestResourceStream(path)))
                return reader.ReadToEnd();
        }
    }
}