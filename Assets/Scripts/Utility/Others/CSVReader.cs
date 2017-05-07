using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace utility.others {
    public class CSVReader {

        private string csvData_;
        private char splitWord_;

        public CSVReader(string csvData, char splitWord = ',') {
            csvData_ = csvData;
            splitWord_ = splitWord;
        }

        public List<List<int>> GetTwoDimensionalDataList() {

            var results = new List<List<int>>();

            var reader = new StringReader(csvData_);

            while (reader.Peek() > -1) {
                string line = reader.ReadLine();
                results.Add(line.Split(splitWord_).Select(w => int.Parse(w)).ToList());
            }

            return results;
        }

        public List<int> GetDataList() {

            var results = new List<int>();

            var reader = new StringReader(csvData_);

            while (reader.Peek() > -1) {
                string line = reader.ReadLine();
                results.AddRange(line.Split(splitWord_).Select(w => int.Parse(w)));
            }

            return results;
        }
    }
}
