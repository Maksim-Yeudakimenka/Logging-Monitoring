using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogAnalysis
{
    [TestClass]
    public class LogAnalyzerTests
    {
        private readonly LogAnalyzer _logAnalyzer;

        public LogAnalyzerTests()
        {
            var filepath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\MvcMusicStore\logs\2016-11-01.log");
            _logAnalyzer = new LogAnalyzer(filepath);
        }

        [TestMethod]
        public void RecordCountByLevel()
        {
            var recordset = _logAnalyzer.RecordCountByLevel;

            while (!recordset.atEnd())
            {
                var record = recordset.getRecord();

                Console.WriteLine(
                    "Log level: {0} - Record count: {1}",
                    record.getValue("LogLevel"),
                    record.getValue("RecordCount"));

                recordset.moveNext();
            }
        }

        [TestMethod]
        public void ErrorRecords()
        {
            var recordset = _logAnalyzer.ErrorRecords;

            while (!recordset.atEnd())
            {
                var record = recordset.getRecord();

                Console.WriteLine(
                    "Date: {0} - Log level: {1} - Message: {2}",
                    record.getValue("Date"),
                    record.getValue("LogLevel"),
                    record.getValue("Message"));

                recordset.moveNext();
            }
        }
    }
}