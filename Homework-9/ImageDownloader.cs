using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    internal class ImageDownloader
    {
        public Task rezDownload;
        public void Download(string url)
        {
            // Откуда будем качать
            string remoteUri = url;
            // Как назовем файл на диске
            string fileName = "bigimage.jpg";
            // Качаем картинку в текущую директорию
            var myWebClient = new WebClient();
            ImageStarted?.Invoke();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n", fileName, remoteUri);
            
            rezDownload = myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            
            ImageCompleted?.Invoke();
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            
        }

        public event Action ImageStarted;
        public event Action ImageCompleted;
    }
}
