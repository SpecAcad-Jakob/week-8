
using System.Data;
using System.IO.Pipelines;
using W3___REST_API;
using Week_4_PDF_downloader;

namespace W3_REST_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //driver();
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseWebRoot("wwwroot");
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapGet("/hello", (string navn) => $"hello world {navn}");
            app.MapGet("/", () => Results.File("index.html", "text/html"));
            app.MapGet("/partial1", () => Results.File("partialpage1.html", "text/html"));
            app.MapGet("/partial2", () => Results.File("partialpage2.html", "text/html"));
            app.MapGet("/partial3", () => Results.File("partialpage3.html", "text/html"));

            //  Query endpoints as required by assignment. I hadn't time to implement these
            app.MapPost("/query/create", () => {
            });
            app.MapGet("/query/read", (int id) => { 
            });
            app.MapPut("/query/update", (int id) => {
            });
            app.MapDelete("/query/delete", () => {
            });

            app.Run();

            /*var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();*/
        }

        private static void driver() {
            List<CerealItem> cerealItems = CSVReader.Readrows();
            foreach (CerealItem cerealItem in cerealItems) {
                Console.WriteLine(cerealItem.name);
            }

            DatabaseConnector databaseConnector = new DatabaseConnector();
            databaseConnector.Server = "localhost";
            databaseConnector.Username = "root";
            databaseConnector.Password = "12345";
            //databaseConnector.DatabaseName = "cereal";

            DatabaseHandler databaseHandler = new DatabaseHandler(databaseConnector);
            String dataBaseName = "cereal";
            int num = databaseHandler.createDatabase(dataBaseName);
            Console.WriteLine(num);
            databaseHandler.CreateTable("products");


            /*
            //  FileReader test: works
            Console.WriteLine("DEBUG: filereader, readAll cereal.csv");
            FileReader fileReader = new FileReader();
            Console.WriteLine("DEBUG: filereader, files counted: " + fileReader.discoveredFilesCount());
            fileReader.readTableFromFile(0);
            foreach (String[] row in fileReader.getTable()) {
                foreach (String column in row) {
                    Console.Write(column.PadLeft(8) + "|");
                }
                Console.WriteLine();
            }
            */

            /*FileHandler fileHandler = new FileHandler("../CSV files");
            Console.WriteLine("DEBUG: filereader, files counted: " + fileHandler.discoveredFilesCount());
            fileHandler.readTableFromCsvFileWithHeadersAndTypes(0, ';');*/

            /*StreamReader streamReader = new StreamReader("../CSV files/Cereal.csv");
            List<CerealItem> list = new List<CerealItem>();
            String line = streamReader.ReadLine();
            while (line != null) {
                Console.WriteLine(line);
                CerealItem cereal = new CerealItem(line.Split(';'));


                line = streamReader.ReadLine();
            }/**/

            /*List<CerealItem> cerealItems = new List<CerealItem>();
            foreach (DataRow dataRow in fileHandler.getTable().Rows) {
                cerealItems.Add(new CerealItem(dataRow));
                /*for (int i = 0; i < dataRow.ItemArray.Length; i++) {
                }
            }
            Console.WriteLine(cerealItems[0].name);*/



            //  Database connection test: does NOT work?
            /*DatabaseConnector dataBaseConnector = new DatabaseConnector();

            DatabaseConnector.Server = "localhost";
            DatabaseConnector.DatabaseName = "cereal";
            DatabaseConnector.Username = "root";
            DatabaseConnector.Password = "12345";

            dataBaseConnector.TableName = "cereal";

            DatabaseConnector.connect();
            dataBaseConnector.readAll();*/
        }

    }
}
