using Ionic.Zip;

namespace TranslationJetBrains
{
    public class ZipTool
    {
        public static void Extract(string resourcePath, string extractPath)
        {
            using (ZipFile file = new ZipFile(resourcePath))
            {
                foreach (ZipEntry ze in file)
                {
                    ze.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static void Compress(string compressPath, string savePaht)
        {
            using (ZipFile file = new ZipFile())
            {
                file.AddDirectory(compressPath);
                file.Save(savePaht);
            }
        }

        public static void Compress(string[] filePath, string savePath)
        {
            using (ZipFile file = new ZipFile())
            {
                foreach (string path in filePath)
                {
                    file.AddFiles(filePath);
                    file.Save(savePath);
                }
            }
        }
    }
}