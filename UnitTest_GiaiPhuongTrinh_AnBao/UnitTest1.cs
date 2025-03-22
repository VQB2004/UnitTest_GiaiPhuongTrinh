using System;
using System.CodeDom;
using System.Globalization;
using GiaiPhuongTrinh_AnBao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;
using Microsoft.Office.Interop.Excel;

namespace UnitTest_GiaiPhuongTrinh_AnBao
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        private Bac1_class_AnBao bac1;

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\Bac1.csv", "Bac1#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_Bac1_csvAnBao()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            object expected; // object là kiểu cha của tất cả datatype
            object value = TestContext.DataRow[2];
            if (double.TryParse(value.ToString(), out double paresedValue))
            {
                expected = paresedValue;
            }
            else
            {
                expected = value.ToString();
            }    
        


            Bac1_class_AnBao c = new Bac1_class_AnBao(a, b);

            var actual1 = c.Giai_bac1_AnBao().Item1;
            var actual2 = c.Giai_bac1_AnBao().Item2;

            if (actual2 =="")
            {
                Assert.AreEqual(expected, actual1);
            }    
            else
            {
                Assert.AreEqual(expected, actual2);
            }
         
         
        }

        [TestMethod]
        public void TC_Bac1_excel_AnBao()
        {
            string path = "D:\\Bac1_2.xlsx";
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb_bac1;
            Excel.Worksheet ws_bac1;
            wb_bac1 = excel.Workbooks.Open(path);
            ws_bac1 = wb_bac1.Worksheets[1];

            Range cell = ws_bac1.Range["A1:C2"];

            object[,] table = (object[,])cell.Value;

            for(int i=2; i<=table.GetLength(0);i++)
            {
                int a = int.Parse(table[i, 1].ToString());
                int b = int.Parse(table[i, 2].ToString());
                object expected;

                object value = table[i, 3].ToString();
                if (double.TryParse(value.ToString(), out double paresedValue))
                {
                    expected = paresedValue;
                }
                else
                {
                    expected = value.ToString();
                }

                Bac1_class_AnBao c = new Bac1_class_AnBao(a, b);

                var actual1 = c.Giai_bac1_AnBao().Item1;
                var actual2 = c.Giai_bac1_AnBao().Item2;

                if (actual2 == "")
                {
                    Assert.AreEqual(expected, actual1);
                }
                else
                {
                    Assert.AreEqual(expected, actual2);
                }
            }
            wb_bac1.Close(false);
            excel.Quit();

            ws_bac1 = null;
            wb_bac1 = null;
            excel = null;


        }
    }
}
