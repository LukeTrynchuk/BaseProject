﻿using DogHouse.Core.Services;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

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
                string[] paths = FetchFilePaths(directoryPath, omittedFileExtensions);
                string[] files = new string[paths.Length];

                for (int i = 0; i < paths.Length; i++)
                    files[i] = ReadFile(paths[i]);

                return files;
            } 
            catch(Exception e)
            {
                m_logService.Reference?.LogError(e.Message);
            }

            return default(string[]);
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
        #endregion
    }
}
