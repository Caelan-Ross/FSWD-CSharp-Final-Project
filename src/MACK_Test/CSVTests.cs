using System.Data;

namespace MACK_Test
{
    public class CSVTests
    {
        [Fact]
        public void CSVTest()
        {
            DataTable dt = MACK.Handlers.CSVHandler.GetDataTableFromCsv("C:\\Users\\caela\\Downloads\\CSV Inventory - Inventory.csv");
            MACK.Handlers.CSVHandler.ConvertDatatableToDb(dt);
        }
    }
}