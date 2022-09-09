namespace NewsApp.Helpers
{
    public class FileAccessHelper
    {
        public static string GetLocalPath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
