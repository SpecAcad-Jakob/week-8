using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace W3___REST_API {
    public class CSVReader() {
        public static List<CerealItem> Readrows() {
            string path = Path.Combine(Environment.CurrentDirectory, "../CSV files/Cereal.csv");
            CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture) {
                Delimiter = ";"
            };
            StreamReader streamReader = new(path);
            CsvReader csvReader = new(streamReader, csvConfig);
            List<CerealItem> rows = csvReader.GetRecords<CerealItem>().ToList();
            return rows;
        }
    }
}
