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
    public class Test_Bac1_AnBao
    {
        public TestContext TestContext { get; set; }

        //Các test case có dữ liệu từ code
        //TC1: a_AnBao = 1, b_AnBao = -2, x_e_AnBao = 2, kq: pass
        [TestMethod]
        public void TC1_Bac1_1Nghiem_AnBao()
        {
            int a_AnBao = 1;
            int b_AnBao = -2;
            double x_e_AnBao = 2;
            Bac1_class_AnBao c_AnBao = new Bac1_class_AnBao(a_AnBao, b_AnBao);
            Assert.AreEqual(x_e_AnBao, c_AnBao.Giai_bac1_AnBao().Item1);
          
        }

        //TC2: a_AnBao = 0, b_AnBao = -2, kq_e_AnBao = "No sol", kq: pass
        [TestMethod]
        public void TC2_Bac1_VoNghiem_AnBao()
        {
            int a_AnBao = 0;
            int b_AnBao = -2;
            string kq_e_AnBao = "No sol";
            Bac1_class_AnBao c_AnBao = new Bac1_class_AnBao(a_AnBao, b_AnBao);
            Assert.AreEqual(kq_e_AnBao, c_AnBao.Giai_bac1_AnBao().Item2);

        }

        //TC3: a_AnBao = 0, b_AnBao = -2, x_e_AnBao = 2, kq: fail
        [TestMethod]
        public void TC3_Bac1_1Nghiem_AnBao()
        {
            int a_AnBao = 0;
            int b_AnBao = -2;
            double x_e_AnBao = 2;
            Bac1_class_AnBao c_AnBao = new Bac1_class_AnBao(a_AnBao, b_AnBao);
            Assert.AreEqual(x_e_AnBao, c_AnBao.Giai_bac1_AnBao().Item1);

        }


        //Các test case với dữ liệu đầu vào lấy từ file

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data_AnBao\TestData_Bac1_AnBao.csv", "TestData_Bac1_AnBao#csv",
            DataAccessMethod.Sequential)]
        //5 dữ liệu đầu vào, KQ: 3 pass, 2 fail
        [TestMethod]
        public void TC4_Bac1_csvAnBao()
        {
            int a_AnBao = int.Parse(TestContext.DataRow[0].ToString());
            int b_AnBao = int.Parse(TestContext.DataRow[1].ToString());

            // object là kiểu cha của tất cả datatype
            object expected_AnBao; 
            object value_AnBao= TestContext.DataRow[2];
            if (double.TryParse(value_AnBao.ToString(), out double paresedValue_AnBao))
            {
                expected_AnBao = paresedValue_AnBao;
            }
            else
            {
                expected_AnBao = "No sol";
            }

            Bac1_class_AnBao c_AnBao = new Bac1_class_AnBao(a_AnBao, b_AnBao);

            var actual1_AnBao = c_AnBao.Giai_bac1_AnBao().Item1;
            var actual2_AnBao = c_AnBao.Giai_bac1_AnBao().Item2;

            if (actual2_AnBao == "")
            {
                Assert.AreEqual(expected_AnBao, actual1_AnBao);
            }
            else
            {
                Assert.AreEqual(expected_AnBao.ToString(), actual2_AnBao);
            }

        }

        //Test với dữ liệu từ file excel. 5 dữ liệu đầu vào, KQ: 5 pass
        [TestMethod]
        public void TC5_Bac1_excel_AnBao()
        {
            string path_AnBao = "G:\\Kiem thu pm\\TestData_Bac1_AnBao.xlsx";
            Excel.Application excel_AnBao = new Excel.Application();
            Excel.Workbook wb_bac1_AnBao;
            Excel.Worksheet ws_bac1_AnBao;
            wb_bac1_AnBao = excel_AnBao.Workbooks.Open(path_AnBao);
            ws_bac1_AnBao = wb_bac1_AnBao.Worksheets[1];

            // truyền kích thước đúng file 
            Range cell_AnBao = ws_bac1_AnBao.Range["A1:C6"];

            object[,] table_AnBao = (object[,])cell_AnBao.Value;

            for (int i_AnBao = 2; i_AnBao <= table_AnBao.GetLength(0); i_AnBao++)
            {
                int a_AnBao = int.Parse(table_AnBao[i_AnBao, 1].ToString());
                int b_AnBao = int.Parse(table_AnBao[i_AnBao, 2].ToString());
                object expected_AnBao;

                object value_AnBao = table_AnBao[i_AnBao, 3].ToString();
                if (double.TryParse(value_AnBao.ToString(), out double paresedValue_AnBao))
                {
                    expected_AnBao = paresedValue_AnBao;
                }
                else
                {
                    expected_AnBao = value_AnBao.ToString();
                }

                Bac1_class_AnBao c_AnBao = new Bac1_class_AnBao(a_AnBao, b_AnBao);

                var actual1_AnBao = c_AnBao.Giai_bac1_AnBao().Item1;
                var actual2_AnBao = c_AnBao.Giai_bac1_AnBao().Item2;

                // Ghi ra Test Explorer
                TestContext.WriteLine($"{i_AnBao - 1}) a={a_AnBao}, b={b_AnBao}");
                TestContext.WriteLine($"   Expected: {expected_AnBao}");

                try
                {
                    if (actual2_AnBao == "")
                    {
                        TestContext.WriteLine($"   Actual: {actual1_AnBao}");
                        Assert.AreEqual(expected_AnBao, actual1_AnBao);

                    }
                    else
                    {
                        TestContext.WriteLine($"   Actual: {actual2_AnBao}");
                        Assert.AreEqual(expected_AnBao, actual2_AnBao);
                    }
                    TestContext.WriteLine("=> Pass");
                }
                catch (AssertFailedException e_AnBao)
                {
                    TestContext.WriteLine($" => Failed! Error: {e_AnBao.Message}");

                }
               
            }
            wb_bac1_AnBao.Close(false);
            excel_AnBao.Quit();

            ws_bac1_AnBao = null;
            wb_bac1_AnBao = null;
            excel_AnBao = null;


        }
       
    }
}
