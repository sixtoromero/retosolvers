using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TechAndSolve.LazyLoad.Common.Clases.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Método que permite obtener los registro del archivo
        /// </summary>
        /// <param name="path">Es la ruta donde se encuentra el archivo a leer</param>
        /// <returns>Retorna la lista del archivo leido</returns>
        public static List<int> getFile(string path)
        {
            try
            {
                List<int> listFile = new List<int>();
                using (StreamReader reader = new StreamReader(path, false))
                {
                    var line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listFile.Add(Convert.ToInt32(line));
                    }
                    reader.Close();
                }
                return listFile;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool setFile(string path, string result, string document)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(path))
                {   
                    write.WriteLine("El usuario con documento: " + document + " con fecha " + DateTime.Now.ToLongDateString() + " " + Environment.NewLine + result);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
