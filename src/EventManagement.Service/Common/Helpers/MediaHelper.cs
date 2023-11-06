namespace EventManagement.Service.Common.Helpers
{
    public class MediaHelper
    {
        public static string MakeImageName(string filename)
        {
            FileInfo fileinfo = new FileInfo(filename);
            string extension = fileinfo.Extension;
            string name = "IMG_" + Guid.NewGuid() + extension;
            return name;
        }

        public static string[] GetImageExtensions()
        {
            return new string[]
            {
            ".jpg",".jpeg",".png",".bmp",".svg"
            };
        }
    }
}