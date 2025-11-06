using System.IO;

namespace W3_REST_API {
    [Obsolete("Replaced by FileHandler.cs", false)]
    public class FileReader {
        //  Constants
        private static String DEFAULT_FOLDER_LOCATION = "../CSV files";    //  Or wherever they may be in relation to this

        //  Fields
        private String[] files;

        //  Properties
        public List<String[]> table = new List<String[]>();

        /// <summary>
        /// Create a new FileReader object which auto-detects files in default file path.
        /// </summary>
        public FileReader() : this(DEFAULT_FOLDER_LOCATION) {
        }

        /// <summary>
        /// Create a new FileReader object which auto-detects files in a given file path
        /// </summary>
        /// <param name="pathToFolder">File path literal. Can be relative or absolute.</param>
        public FileReader(String pathToFolder) {
            discoverFiles(pathToFolder);
        }

        /// <summary>
        /// Discover files and populate 'files' field with paths to files.
        /// </summary>
        /// <param name="pathToFolder">File path literal. Can be relative or absolute.</param>
        public void discoverFiles(String pathToFolder) {
            files = Directory.GetFiles(pathToFolder);
        }

        public int discoveredFilesCount() {
            return files.Length;
        }

        /// <summary>
        /// Read a given file (assuming CSV, breaking on semicolon (';')). 
        /// Split into columns, then add as row of columns to table field.
        /// </summary>
        /// <param name="discoveredFileIndex"></param>
        public void readTableFromFile(int discoveredFileIndex) {
            StreamReader streamReader = new StreamReader(files[0]);

            String line = streamReader.ReadLine();
            while (line != null) {
                table.Add(line.Split(';'));

                line = streamReader.ReadLine();
            }
            streamReader.Close();
        }

        /// <summary>
        /// Get table of items read from CSV file.
        /// </summary>
        /// <returns>Collection of string arrays. Should be parsed before pushing to database.</returns>
        public List<String[]> getTable() { 
            return table;
        }
    }
}
