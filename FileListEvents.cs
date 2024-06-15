using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Generic
{
    public class FileListEvents
    {
        public delegate void EventHandler(string directoryPath);

        public event EventHandler<FileFound> FileListSelected;
        public void Search(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Путь должен быть не пустым.");
            }

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException("Указанный путь не существует.");
            }
          

            SearchDirectory(path, SearchOption.AllDirectories);
        }
        private void SearchDirectory(string path, SearchOption searchOption)
        {
            try
            {

                string[] files = Directory.GetFiles(path, "*.*", searchOption);

                foreach (string file in files)
                {
                    OnFileListSelected(new FileFound(file));
                    if (Console.KeyAvailable == true)
                    {
                        cki = Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.J) break;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Доступ запрещен.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Путь слишком длинный.");
            }
        }
        ConsoleKeyInfo cki = new ConsoleKeyInfo();
        protected virtual void OnFileListSelected(FileFound fileF)
        {
           
            FileListSelected.Invoke(this, fileF);

        }
       
    }
    
    public class FileFound : EventArgs
    {
        public string FilePath { get; }

        public FileFound(string filePath)
        {
            FilePath = filePath;
        }

    }
}
