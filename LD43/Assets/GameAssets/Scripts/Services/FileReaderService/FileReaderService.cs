using DogHouse.Core.Services;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;

namespace DogHouse.Services
{
    /// <summary>
    /// FileReaderService is a concrete implementation
    /// of the File Reader Service interface. The 
    /// File Reeader Service is responsible for reading
    /// files from the hard drive.
    /// </summary>
    public class FileReaderService : BaseService<IFileReaderService>, IFileReaderService
    {
        #region Private Variables
        private ServiceReference<ILogService> m_logService 
            = new ServiceReference<ILogService>();
        #endregion

        #region Main Methods
        public string ReadFile(string path)
        {
            if (!File.Exists(path)) return default(string);

            try
            {
                return File.ReadAllText(path);
            }
            catch(Exception e)
            {
                m_logService.Reference?.LogError(e.Message);
            }

            return default(string);
        }

        public string[] ReadDirectory(string directoryPath, string[] omittedFileExtensions = null)
        {
            if (!Directory.Exists(directoryPath)) return default(string[]);

            try
            {
                return ExecuteDirectoryRead(directoryPath, omittedFileExtensions);
            } 
            catch(Exception e)
            {
                m_logService.Reference?.LogError(e.Message);
            }

            return default(string[]);
        }

        public void ReadDirectoryAsync(string directoryPath, Action<string[]> callback, string[] omittedFileExtensions = null)
        {
            if (!Directory.Exists(directoryPath)) callback?.Invoke(default(string[]));
            Thread thread = new Thread( ()=> ReadDirectoryAsynchonously(directoryPath, callback, omittedFileExtensions));
            thread.Start();
        }

        public void ReadFileAsync(string path, Action<string> callback)
        {
            if (!File.Exists(path)) return;
            Thread thread = new Thread(() => ReadFileAsynchronously(path, callback));
            thread.Start();
        }
        #endregion

        #region Utility Methods
        private string[] FetchFilePaths(string directoryPath, string[] omittedFileExtensions = null)
        {
            if (!Directory.Exists(directoryPath)) return default(string[]);

            try
            {
                List<string> paths = Directory.GetFiles(directoryPath).ToList();
                if (omittedFileExtensions == null) return paths.ToArray();

                paths = paths.Where(x => !omittedFileExtensions.Any(x.EndsWith)).ToList();
                return paths.ToArray();
            }
            catch (Exception e)
            {
                m_logService.Reference?.LogError(e.Message);
            }

            return default(string[]);
        }

        private void ReadDirectoryAsynchonously(string directoryPath, Action<string[]> callback, string[] omittedFileExtensions = null)
        {
            string[] result = null;

            try
            {
                result = ReadDirectory(directoryPath, omittedFileExtensions);    
            }
            catch (Exception e)
            {
                m_logService.Reference?.LogError(e.Message);
            }

            callback?.Invoke(result);
        }

        private void ReadFileAsynchronously(string path, Action<string> callback)
        {
            string result = null;

            try
            {
                result = ReadFile(path);
            }
            catch(Exception e)
            {
                m_logService.Reference?.LogError(e.Message);
            }

            callback?.Invoke(result);
        }

        private string[] ExecuteDirectoryRead(string directoryPath, string[] omittedFileExtensions = null)
        {
            string[] paths = FetchFilePaths(directoryPath, omittedFileExtensions);
            string[] files = new string[paths.Length];

            for (int i = 0; i < paths.Length; i++)
                files[i] = ReadFile(paths[i]);

            return files;
        }
        #endregion
    }
}
