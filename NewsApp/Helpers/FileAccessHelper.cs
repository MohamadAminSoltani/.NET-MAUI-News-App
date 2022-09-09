namespace NewsApp.Helpers
{
    public class FileAccessHelper
    {
        public static string GetLocalPath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
