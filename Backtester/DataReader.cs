using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;


namespace Backtester
{
    interface IDataReader
    {
        bool GetData(out List<MarketPrice> data);
    }

    class TestDataReader : IDataReader
    {
        public bool GetData(out List<MarketPrice> data)
        {
            var marketPrices = new List<MarketPrice>();
            for (int i = 1; i < 100; i++)
            {
                DateTime date = new DateTime(2018, 1, 1).AddDays(i);
                decimal price = 100 + (decimal)i / 10;
                marketPrices.Add(new MarketPrice(date, price));
            }
            data = marketPrices;
            return true;
        }
    }

    class CsvDataReader : IDataReader
    {
        public static string DefaultFileName = "AUDUSD.csv";

        private string _csvFileName;

        public CsvDataReader(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public bool GetData(out List<MarketPrice> data)
        {
            var parser = new TextFieldParser(_csvFileName) { TextFieldType = FieldType.Delimited };
            parser.SetDelimiters(",");
            var marketPrices = new List<MarketPrice>();
            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();
                if (fields.Length != 2)
                {
                    TextBoxWriter.WriteMessage($"Record ({string.Join(",", fields)}) doesn't have exactly two fields.\r\n" +
                        "Simulation aborted.");
                    data = new List<MarketPrice>();
                    return false;
                }
                var r0 = DateTime.TryParse(fields[0], out var date);
                var r1 = decimal.TryParse(fields[1], out var price);
                if (!r0 || !r1)
                {
                    TextBoxWriter.WriteMessage($"Couldn't parse record ({string.Join(", ", fields)}) as (DateTime, Price).\r\n" +
                        "Simulation aborted.");
                    data = new List<MarketPrice>();
                    return false;
                }
                marketPrices.Add(new MarketPrice(date, price));
            }
            data = marketPrices;
            return true;
        }

        public static bool ValidateAndSetFileName(IMainForm form, out string filename)
        {
            string input = form.GetInput();
            if (String.IsNullOrEmpty(input))
            {
                filename = DefaultFileName;
                return true;
            }
            else if (!File.Exists(input))
            {
                string currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                TextBoxWriter.WriteMessage($"Can't find file {input} in folder {currentDirectory}, please try again.");
                filename = "N/A";
                return false;
            }
            else if (!input.EndsWith(".csv"))
            {
                TextBoxWriter.WriteMessage($"Entered filename is not a standard csv type! Filename must end with .csv");
                filename = "N/A";
                return false;
            }
            else
            {
                filename = input;
                return true;
            }
        }
    }
}
