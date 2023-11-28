using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;

namespace lesson4_createApi
{
    public class DataContext:IDataContext
    {
        public List<Event> EventLists { get; set; }

        public DataContext()
        {

            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                EventLists = csv.GetRecords<Event>().ToList();
            }
        }
    }
}
