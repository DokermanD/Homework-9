using System.Security.Cryptography.X509Certificates;

namespace Homework_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            //Обьявляем экземпляр класса
            ImageDownloader downloader = new ImageDownloader();

            //Подписываемся на события
            downloader.ImageStarted += Downloader_ImageStarted;
            downloader.ImageCompleted += Downloader_ImageCompleted;
            
            //Вызываем метод для загрузки картинки по урлу
            downloader.Download("https://prixoxo.ru/uploads/posts/2021-08/fioletovyj-cvet-kartinki-i-krasivye-foto-3.jpg");

            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            var key = Console.ReadKey().KeyChar;
            Console.WriteLine();

            //Обработка нажатой клавиши
            KeyDown(key, downloader);
        }

        

        //Обработчики событий
        private static void Downloader_ImageCompleted()
        {
            Console.WriteLine("Скачивание файла закончилось");
        }

        private static void Downloader_ImageStarted()
        {
            Console.WriteLine("Скачивание файла началось");
        }

        //Обработка нажатия клавиш
        public static void KeyDown(char key, ImageDownloader downloader)
        {
            if (key == 'A' || key == 'a')
            {
                Environment.Exit(0);
            }

            if (downloader.rezDownload.IsCompleted)
            {
                Console.WriteLine("Cостояние загрузки картинки - загружена");
                return;
            }

            Console.WriteLine("Cостояние загрузки картинки - не загружена");
        }
    }
}