using MSUtil;

namespace LogAnalysis
{
    public class LogAnalyzer
    {
        private readonly LogQueryClass _logQuery = new LogQueryClass();

        private readonly COMTSVInputContextClass _context = new COMTSVInputContextClass
        {
            headerRow = false,
            iTsFormat = "yyyy-MM-dd HH:mm:ss.ffff",
            iSeparator = "|",
            nFields = 3
        };

        private readonly string _filepath;

        public LogAnalyzer(string filepath)
        {
            _filepath = filepath;
        }

        public ILogRecordset RecordCountByLevel
        {
            get
            {
                var query = $"SELECT Field2 AS LogLevel, COUNT(*) AS RecordCount " +
                            $"FROM {_filepath} " +
                            $"GROUP BY Field2";

                return _logQuery.Execute(query, _context);
            }
        }

        public ILogRecordset ErrorRecords
        {
            get
            {
                var query = $"SELECT Field1 AS Date, Field2 AS LogLevel, Field3 AS Message " +
                            $"FROM {_filepath} " +
                            $"WHERE Field2 = 'ERROR'";

                return _logQuery.Execute(query, _context);
            }
        }
    }
}