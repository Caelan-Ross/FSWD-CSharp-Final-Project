using MACK.Models;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace MACK.Handlers
{
    public class CSVHandler
    {
        public static DataTable GetDataTableFromCsv(string path)
        {
            DataTable dt = new DataTable();
            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach(string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while(!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for(int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static void ConvertDatatableToDb(DataTable dataTable)
        {
            foreach(DataRow row in dataTable.Rows)
            {
                Manufacturer manu = ManufacturerHandlers.IfManufacturerExists(row["Make"].ToString());
                Model model = ModelHandlers.IfModelExists(row["model"].ToString(), manu.ManufacturerId);
                bool vehicleExists = VehicleHandlers.IfVehicleExists(row["vin"].ToString(), model.ModelId);

                if(!vehicleExists) 
                {
                    int.TryParse((string)row["year"], out int year);
                    int.TryParse((string)row["Body Door Ct"], out int bodyDoorCount);
                    bool isUsed = true;
                    if(row["New/Used"].ToString() == "N") { isUsed = false; }
                    bool isAutomatic = true;
                    if(!row["Transmission"].ToString().Contains("Automatic")) { isAutomatic = false; }
                    int.TryParse((string)row["Price"], out int price);

                    VehicleHandlers.CreateVehicle(
                        row["vin"].ToString(),
                        year,
                        row["fuel"].ToString(),
                        row["colour"].ToString(),
                        row["Interior Color"].ToString(),
                        bodyDoorCount,
                        isUsed,
                        isAutomatic,
                        row["features"].ToString(),
                        row["description"].ToString(),
                        model.ModelId,
                        price,
                        row["Stock #"].ToString()
                        );
                }
            }
        }

    }
}
