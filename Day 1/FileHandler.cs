using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    /// <summary>
    /// A class to handle text files for use in Summative 4
    /// </summary>
    internal class FileReader
    {
        public string directoryPath;
        private IEnumerable<string>? _data;
        /// <summary>
        /// The ".EXT" that you wish to search for
        /// </summary>
        public string wantedExtension { get; set; }
        /// <summary>
        /// The pointer to the current line of the file data.
        /// Read Only
        /// </summary>
        private int _linePointer = 0;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directoryPath">The directory to act as the root of the FileReader</param>
        public FileReader(string rootDirectoryPath, string wantedExtension=".txt")
        {
            this.directoryPath = rootDirectoryPath;
            this.wantedExtension = wantedExtension;
        }

        /// <summary>
        /// Return all accessible files in the directory
        /// </summary>
        /// <returns>An array of the strings of filenames</returns>
        public string[] GetFileNames()
        {
            string[] tempFiles;
            tempFiles = Directory.GetFiles(this.directoryPath,$"*{this.wantedExtension}");
            return tempFiles;
        }
        /// <summary>
        /// Load the data from the target file into memory
        /// </summary>
        /// <param name="fileName">The filepath of the file to be accessed from the root directory of the object</param>
        /// <exception cref="Exception"></exception>
        public void LoadFileData(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception($"{fileName} does not exist.");
            }
            this._data = File.ReadLines(fileName);
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Returns a single as a String.
        /// returns "---EOF---" when end of file reached 
        /// </returns>
        public string ReadLine()
        {
            string output = this._data.ElementAt(_linePointer);
            this._linePointer++;
            if (_linePointer>GetDataLength())
            {
                return "---EOF---";
            }
            return output;
        }
        public void SetLinePointer(int line)
        {
            if (line<0 || line>=this._data.Count())
            {
                throw new Exception("Index Out of Range: Line must be greater than 0 and less than the maximum index of the data");
            }
            this._linePointer = line;
            this.ReadLine();
        }
        /// <summary>
        /// Gets the amount of lines in the file
        /// </summary>
        /// <returns>the amount of lines in the file or -1 if the file contents are null</returns>
        public int GetDataLength() 
        {
            if(this._data is null)
            {
                return -1;
            }
            return this._data.Count(); 
        }

        public void ClearData()
        {
            this._data = null;
            return;
        }
    }
}
