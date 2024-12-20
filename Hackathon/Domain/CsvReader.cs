using System.Globalization;
using CsvHelper.Configuration;

namespace Hackathon.Domain;

public class CsvReader
{
    private class CsvRecord
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public static List<Developer> ReadDevs(string filename, Jobs job)
    {
        var result = new List<Developer>();

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
        };

        using (var reader = new StreamReader(filename))
        using (var csv = new CsvHelper.CsvReader(reader, config))
        {
            var records = csv.GetRecords<CsvRecord>();
            foreach (var record in records)
            {
                var dev = new Developer
                {
                    Id = record.Id,
                    Name = record.Name,
                    Job = job
                };
                result.Add(dev);
            }
        }

        return result;
    }
}
