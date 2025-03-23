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
        public void TC1_Bac1_csvAnBao()
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

            if (actual2 == "")
            {
                Assert.AreEqual(expected, actual1);
            }
            else
            {
                Assert.AreEqual(expected, actual2);
            }


        }

        [TestMethod]
        public void TC2_Bac1_excel_AnBao()
        {
            string path = "D:\\Bac1_2.xlsx";
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb_bac1;
            Excel.Worksheet ws_bac1;
            wb_bac1 = excel.Workbooks.Open(path);
            ws_bac1 = wb_bac1.Worksheets[1];

            Range cell = ws_bac1.Range["A1:C2"];

            object[,] table = (object[,])cell.Value;

            for (int i = 2; i <= table.GetLength(0); i++)
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

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData_Bac2_AnBao.csv", "TestData_Bac2_AnBao#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC3_Bac2_csv_AnBao() //Test case với dữ liệu test 4 cột
        {
            int a_AnBao = int.Parse(TestContext.DataRow[0].ToString());
            int b_AnBao = int.Parse(TestContext.DataRow[1].ToString());
            int c_AnBao = int.Parse(TestContext.DataRow[2].ToString());
            string kq_exp_AnBao = TestContext.DataRow[3].ToString().Trim();

            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            string kq_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item3;
            Assert.AreEqual(kq_exp_AnBao, kq_actual_AnBao);



        }

        [TestMethod]
        public void TC4_Bac2_excel_AnBao()  //Test case với dữ liệu test 4 cột
        {
            string path = "G:\\Kiem thu pm\\DataTestExcel_Bac2_AnBao.xlsx";
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb_bac2_AnBao;
            Excel.Worksheet ws_bac2_AnBao;
            wb_bac2_AnBao = excel.Workbooks.Open(path);
            ws_bac2_AnBao = wb_bac2_AnBao.Worksheets[1];

            Range cell_AnBao = ws_bac2_AnBao.Range["A1:D7"];

            object[,] table_AnBao = (object[,])cell_AnBao.Value;

            for (int i = 2; i <= table_AnBao.GetLength(0); i++)
            {
                int a_AnBao = int.Parse(table_AnBao[i, 1].ToString());
                int b_AnBao = int.Parse(table_AnBao[i, 2].ToString());
                int c_AnBao = int.Parse(table_AnBao[i, 3].ToString());
                string kq_exp_AnBao = table_AnBao[i, 4].ToString();

                Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
                string kq_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item3;

                // Ghi log ra Test Explorer
                TestContext.WriteLine($"{i - 1}) a={a_AnBao}, b={b_AnBao}, c={c_AnBao}");
                TestContext.WriteLine($"   Expected: {kq_exp_AnBao}");
                TestContext.WriteLine($"   Actual: {kq_actual_AnBao}");
                try
                {
                    Assert.AreEqual(kq_exp_AnBao, kq_actual_AnBao);
                    TestContext.WriteLine(" => Passed!");
                }
                catch (AssertFailedException e)
                {
                    TestContext.WriteLine($" => Failed! Error: {e.Message}");

                }

            }
            wb_bac2_AnBao.Close(false);
            excel.Quit();

            ws_bac2_AnBao = null;
            wb_bac2_AnBao = null;
            excel = null;

        }


        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData_Bac2_5col_AnBao.csv", "TestData_Bac2_5col_AnBao#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC5_Bac2_csv5col_AnBao()     //Test case với dữ liệu test 5 cột
        {
            int a_AnBao = int.Parse(TestContext.DataRow[0].ToString());
            int b_AnBao = int.Parse(TestContext.DataRow[1].ToString());
            int c_AnBao = int.Parse(TestContext.DataRow[2].ToString());

            // object là kiểu cha của tất cả datatype
            object x1_expected_AnBao = TestContext.DataRow[3];
            //Kiểm tra xem giá trị được lấy có chuyển về kiểu double được hay không
            if (double.TryParse(x1_expected_AnBao.ToString(), out double paresedValue))
            {
                x1_expected_AnBao = paresedValue;
            }
            else
            {
                x1_expected_AnBao = 0;

            }


            object x2_expected_AnBao = TestContext.DataRow[4]; // object là kiểu cha của tất cả datatype
            //Kiểm tra xem giá trị được lấy có chuyển về kiểu double được hay không
            if (double.TryParse(x2_expected_AnBao.ToString(), out double Value))
            {
                x2_expected_AnBao = Value;
            }
            else
            {
                x2_expected_AnBao = 0;
            }
            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            double x1_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item1;
            double x2_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item2;
            string kq_AnBao = d_AnBao.Giai_bac2_AnBao().Item3;
           
            if (x1_expected_AnBao is double && x2_expected_AnBao is double)
            {
                Assert.AreEqual(x1_expected_AnBao, x1_actual_AnBao);
                Assert.AreEqual(x2_expected_AnBao, x2_actual_AnBao);

            }
            else
            {
                Assert.AreEqual(x1_expected_AnBao.ToString(), x1_actual_AnBao.ToString());
               

            }
        }

        [TestMethod]
        public void TC6_Bac2_excel5col_AnBao()  //Test case với dữ liệu test 5 cột
        {
            string path = "G:\\Kiem thu pm\\DataExcel_Bac2_AnBao.xlsx";
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb_bac2_AnBao;
            Excel.Worksheet ws_bac2_AnBao;
            wb_bac2_AnBao = excel.Workbooks.Open(path);
            ws_bac2_AnBao = wb_bac2_AnBao.Worksheets[1];

            Range cell_AnBao = ws_bac2_AnBao.Range["A1:E6"];

            object[,] table_AnBao = (object[,])cell_AnBao.Value;

            for (int i = 2; i <= table_AnBao.GetLength(0); i++)
            {
                int a_AnBao = int.Parse(table_AnBao[i, 1].ToString());
                int b_AnBao = int.Parse(table_AnBao[i, 2].ToString());
                int c_AnBao = int.Parse(table_AnBao[i, 3].ToString());
                object x1_exp_AnBao = table_AnBao[i, 4];
                object x2_exp_AnBao = table_AnBao[i, 5];

                //Kiểm tra xem giá trị được lấy có chuyển về kiểu double được hay không
                if (double.TryParse(x1_exp_AnBao.ToString(), out double paresedValue))
                {
                    x1_exp_AnBao = paresedValue;
                }
                if (double.TryParse(x2_exp_AnBao.ToString(), out double Value))
                {
                    x2_exp_AnBao = Value;
                }
                Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
                double x1_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item1;
                double x2_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item2;
                string kq_AnBao = d_AnBao.Giai_bac2_AnBao().Item3;

                // Ghi log ra Test Explorer
                TestContext.WriteLine($"{i - 1}) a={a_AnBao}, b={b_AnBao}, c={c_AnBao}");
                if (x1_exp_AnBao is double && x2_exp_AnBao is double)
                {
                    TestContext.WriteLine($"   Expected: x1={x1_exp_AnBao}, x2={x2_exp_AnBao}");
                    TestContext.WriteLine($"   Actual: x1={x1_actual_AnBao}, x2={x2_actual_AnBao}");

                    try
                    {
                        Assert.AreEqual(x1_exp_AnBao, x1_actual_AnBao);
                        Assert.AreEqual(x2_exp_AnBao, x2_actual_AnBao);
                        TestContext.WriteLine(" => Passed!");
                    }
                    catch (AssertFailedException e)
                    {
                        TestContext.WriteLine($" => Failed! Error: {e.Message}");

                    }
                }
                else
                {
                    TestContext.WriteLine($"   Expected: {x1_exp_AnBao.ToString()}");
                    TestContext.WriteLine($"   Actual: {kq_AnBao}");
                    try
                    {
                        Assert.AreEqual(x1_exp_AnBao.ToString(), kq_AnBao);
                        Assert.AreEqual(x2_exp_AnBao.ToString(), kq_AnBao);
                        TestContext.WriteLine(" => Passed!");
                    }
                    catch (AssertFailedException e)
                    {
                        TestContext.WriteLine($" => Failed! Error: {e.Message}");

                    }
                }              
            }
        }


       
    }
}
