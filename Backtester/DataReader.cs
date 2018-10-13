using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Backtester
{
    interface IDataReader
    {
        List<MarketPrice> GetData();
    }

    class TestDataReader : IDataReader
    {
        public List<MarketPrice> GetData()
        {
            var data = new List<MarketPrice>();
            for (int i = 1; i < 100; i++)
            {
                DateTime date = new DateTime(2018, 1, 1).AddDays(i);
                decimal price = 100 + (decimal)i / 10;
                data.Add(new MarketPrice(date, price));
            }
            return data;
        }
    }

    class CsvDataReader : IDataReader
    {
        private string _csvFileName { get; set; }

        public CsvDataReader(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public CsvDataReader()
        {
            _csvFileName = GetFileName();
        }

        public List<MarketPrice> GetData()
        {
            var parser = new TextFieldParser(_csvFileName) { TextFieldType = FieldType.Delimited };
            parser.SetDelimiters(",");
            var marketPrices = new List<MarketPrice>();
            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();
                DateTime.TryParse(fields[0], out var date);
                decimal.TryParse(fields[1], out var price);
                marketPrices.Add(new MarketPrice(date, price));
            }
            return marketPrices;
        }

        private string GetFileName()
        {
            string defaultFileName = "AUDUSD.csv";
            Console.WriteLine($"Please enter the name of the csv file containing the market data.");
            Console.WriteLine($"If nothing is entered, the default is {defaultFileName}");
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    input = defaultFileName;
                    break;
                }
                else if (!File.Exists(input))
                {
                    string currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                    Console.WriteLine($"Can't find file {input} in folder {currentDirectory}, please try again.");
                    continue;
                }
                else if (!input.EndsWith(".csv"))
                {
                    Console.WriteLine($"Entered filename is not a standard csv type! Filename must end with .csv");
                    continue;
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }
            return input;
        }
    }
}
