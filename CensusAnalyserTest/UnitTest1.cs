using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using Newtonsoft.Json;
using System.Collections.Generic;
using  static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {

        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
      
        static string wrongHeaderIndianCensusFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        
        static string delimiterIndianCensusFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        
        static string wrongIndianStateCensusFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        
        static string wrongIndianStateCensusFileType = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        
        static string indianStateCodeFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        
        static string wrongIndianStateCodeFileType = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        
        static string delimiterIndianstateCodeFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        
        static string wrongHeaderStateCodeFilePath = @"C:\VisualStudio\source\repos\RFP180\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> TotalRecord;
        Dictionary<string, CensusDTO> StateRecord;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            TotalRecord = new Dictionary<string, CensusDTO>();
            StateRecord = new Dictionary<string, CensusDTO>();
        }

        //UC1
        //Test Case 1.1
        [Test]
        public void GivenindianCensusdataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            //For Census Data
            int expected = 29;
            TotalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(expected, TotalRecord.Count);

        }

        //Test Case 1.2
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            //Passing Wrong Census data File
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }

        
        //Test Case 1.3
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            //Passing Wrong Census Data File Type
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
 
        }

       
        //Test Case 1.4
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }


        //Test Case 1.5
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

    }
}