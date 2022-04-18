using System;
using Xunit;
using Repository.DB;


namespace MariaDBTest
{
    public class MariaDBshould
    {
        
        [Fact]
        public void ConnectPass()
        {
            MariaDB DBUUT = new MariaDB("192.168.0.3", 3306, "Acub", "@Aa16621662", "QCGauges",2);
            Assert.Equal("192.168.0.3",DBUUT.IP);
            Assert.True(DBUUT.Connected);
        }
        [Fact]
        public void ConnectFail()
        {
            //Wrong connection settings. Expection must ocur
            var caughtexception = Assert.Throws<AccessViolationException>(() =>  new MariaDB("192.168.0.87", 3306, "Acub", "@Aa16621662", "QCGauges", 2));           
        }
        [Fact]
        public void ReadNonEmpty1ColumnTable()
        {
            //Test that a uknown test table can be read
            MariaDB DBUUT = new MariaDB("192.168.0.3", 3306, "Acub", "@Aa16621662", "QCGauges", 2);
            QueryResults queryresults = DBUUT.ReadQuery("SELECT Description FROM `Test2`", false);
            Assert.NotNull(queryresults);
            Assert.Equal("Description", queryresults.ColumnNames[0]);
            Assert.Equal("VARCHAR", queryresults.ColumnDataTypes[0]);

            Assert.Equal("Hola", queryresults.Results2D[0][0]);
        }
        [Fact(Skip = "not developed")]
        public void ReadEmptyTable()

        {

        }
        [Fact(Skip = "not developed")]
        public void ReadNonEmptyMultipleColumnTable()

        {

        }
        [Fact]
        public void ReadNonEmptyMultipleWithNullTable()
        {
            //Test that a uknown test table can be read
            MariaDB DBUUT = new MariaDB("192.168.0.3", 3306, "Acub", "@Aa16621662", "QCGauges", 2);
            QueryResults queryresults = DBUUT.ReadQuery("SELECT * FROM `Test2`", false);
            Assert.NotNull(queryresults);
            Assert.Equal("ID", queryresults.ColumnNames[0]);
            Assert.Equal("INT", queryresults.ColumnDataTypes[0]);

            Assert.Equal("33", queryresults.Results2D[3][2]);
        }
    }
}
