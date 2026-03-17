using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Snakes_And_Ladders
{
    internal class Utils
    {
        public static Dictionary<string, Image> GetAllImages()
        {
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            foreach (string fileFullPath in Directory.GetFiles($"{Directory.GetCurrentDirectory()}/images"))
            {
                string fileFullName = Path.GetFileName(fileFullPath);
                List<string> split = fileFullName.Split('.').ToList();
                split.RemoveAt(split.Count - 1);
                string fileName = string.Join(".", split);
                images.Add(fileName, Image.FromFile($"images/{fileFullName}"));
            }
            return images;
        }
    }
}
