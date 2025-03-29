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
	public class Test_Bac2_AnBao
	{
        public TestContext TestContext { get; set; }
        //Các test case với dữ liệu có sẵn trong code:

        //TC1: a_AnBao=1, b_AnBao=1, c_AnBao=0 , x1_e_AnBao =0, x2_e_AnBao=-1, kq: pass
        [TestMethod]
        public void TC1_Bac2_HaiNghiemPB_AnBao()
        {
            int a_AnBao = 1;
            int b_AnBao = 1;
            int c_AnBao = 0;
            double x1_e_AnBao = 0;
            double x2_e_AnBao = -1;

            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            Assert.AreEqual(x1_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item1);
            Assert.AreEqual(x2_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item2);
        }

        //TC2: a_AnBao=1, b_AnBao=-4, c_AnBao=4 , x_e_AnBao =2, kq: pass
        [TestMethod]
        public void TC2_Bac2_NghiemKep_AnBao()
        {
            int a_AnBao = 1;
            int b_AnBao = -4;
            int c_AnBao = 4;
            double x_e_AnBao = 2;

            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            Assert.AreEqual(x_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item1);
            Assert.AreEqual(x_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item2);
        }

        //TC3: a_AnBao=1, b_AnBao=1, c_AnBao=1 , kq_e = "no real root", kq: pass
        [TestMethod]
        public void TC3_Bac2_VoNghiem_AnBao()
        {
            int a_AnBao = 1;
            int b_AnBao = 1;
            int c_AnBao = 1;
            string kq_e_AnBao = "no real root";

            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            Assert.AreEqual(kq_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item3);
        }

        //TC4: a_AnBao=1, b_AnBao=-5, c_AnBao=6 , x_e_AnBao =2, kq: fail
        [TestMethod]
        public void TC4_Bac2_NghiemKep_AnBao()
        {
            int a_AnBao = 1;
            int b_AnBao = -5;
            int c_AnBao = 6;
            double x_e_AnBao = 2;

            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            Assert.AreEqual(x_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item1);
            Assert.AreEqual(x_e_AnBao, d_AnBao.Giai_bac2_AnBao().Item2);
        }


        //Các test case có dữ liệu đầu vào lấy từ file

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData_Bac2_5col_AnBao.csv", "TestData_Bac2_5col_AnBao#csv",
            DataAccessMethod.Sequential)]
        //Test case với dữ liệu test 5 cột trong file csv 
        //6 dữ liệu đầu vào, KQ: 5 pass, 1 fail
        [TestMethod]
        public void TC5_Bac2_csv5col_AnBao()     
        {
            //Lấy các giá trị cho biến từ file csv
            int a_AnBao = int.Parse(TestContext.DataRow[0].ToString());
            int b_AnBao = int.Parse(TestContext.DataRow[1].ToString());
            int c_AnBao = int.Parse(TestContext.DataRow[2].ToString());
            
            // object là kiểu cha của tất cả datatype
            object x1_expected_AnBao;
            object value_1_AnBao = TestContext.DataRow[3];
            

            //Kiểm tra xem giá trị được lấy có chuyển về kiểu double được hay không
            // nếu được thì nhận giá trị double không thì lấy giá trị chuỗi
            if (double.TryParse(value_1_AnBao.ToString(), out double paresedValue))
            {
                x1_expected_AnBao = paresedValue;
            }
            else
            {
                x1_expected_AnBao = "no real root";

            }

            // object là kiểu cha của tất cả datatype
            object x2_expected_AnBao;
            object value_2_AnBao = TestContext.DataRow[4];

            //Kiểm tra xem giá trị được lấy có chuyển về kiểu double được hay không
            // nếu được thì nhận giá trị double không thì lấy giá trị chuỗi
            if (double.TryParse(value_2_AnBao.ToString(), out double Value))
            {
                x2_expected_AnBao = Value;
            }
            else
            {
                x2_expected_AnBao = "no real root";
            }

            //Tạo 1 đối tượng Bac2_class_AnBao
            Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            //Lưu giá trị trả về từ d_AnBao.Giai_bac2_AnBao() vào các biến 
            double x1_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item1;
            double x2_actual_AnBao = d_AnBao.Giai_bac2_AnBao().Item2;
            string kq_AnBao = d_AnBao.Giai_bac2_AnBao().Item3;

            //Xét điều kiện: nếu x1_expected_AnBao và x2_expected_AnBao là kiểu double
            if (x1_expected_AnBao is double && x2_expected_AnBao is double)
            {
                //So sánh nghiệm mong đợi với nghiệm thực tế
                Assert.AreEqual(x1_expected_AnBao, x1_actual_AnBao);
                Assert.AreEqual(x2_expected_AnBao, x2_actual_AnBao);

            }
            //Điều kiện: nếu x1_expected_AnBao và x2_expected_AnBao không phải kiểu double
            else
            {
                //So sánh kết quả mong đợi với kết quả thực tế
                Assert.AreEqual(x1_expected_AnBao.ToString(), kq_AnBao);
            }
        }

        [TestMethod]
        //Test case với dữ liệu test 5 cột trong file excel
        public void TC6_Bac2_excel5col_AnBao()  
        {
            // clone repo về nhớ chỉnh đường dẫn đến file
            string path = "G:\\Kiem thu pm\\DataExcel_Bac2_AnBao.xlsx";
            //Tạo một đối tượng Excel Application.
            Excel.Application excel = new Excel.Application();           
            Excel.Workbook wb_bac2_AnBao;
            Excel.Worksheet ws_bac2_AnBao;

            //Mở Workbook từ file Excel có đường dẫn trong path
            wb_bac2_AnBao = excel.Workbooks.Open(path);
            //Lấy Sheet đầu tiên để làm việc.
            ws_bac2_AnBao = wb_bac2_AnBao.Worksheets[1];

            // Chọn vùng dữ liệu trong file excel (phải đúng kích thước truyền vào)
            Range cell_AnBao = ws_bac2_AnBao.Range["A1:E6"];
            //Lưu dữ liệu vào đối tượng mảng 2 chiều
            object[,] table_AnBao = (object[,])cell_AnBao.Value;

            //Lặp qua từng dòng dữ liệu để thực hiện kiểm thử
            for (int i = 2; i <= table_AnBao.GetLength(0); i++)
            {
                //Đọc dữ liệu từ các cột trong bảng table_AnBao
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

                //Xét điều kiện: nếu x1_exp_AnBao và x2_exp_AnBao là kiểu double
                if (x1_exp_AnBao is double && x2_exp_AnBao is double)
                {
                    // Ghi log ra Test Explorer
                    TestContext.WriteLine($"   Expected: x1={x1_exp_AnBao}, x2={x2_exp_AnBao}");
                    TestContext.WriteLine($"   Actual: x1={x1_actual_AnBao}, x2={x2_actual_AnBao}");

                    try
                    {
                        //So sánh nghiệm mong đợi với nghiệm thực tế
                        Assert.AreEqual(x1_exp_AnBao, x1_actual_AnBao);
                        Assert.AreEqual(x2_exp_AnBao, x2_actual_AnBao);
                        TestContext.WriteLine(" => Passed!");
                    }
                    catch (AssertFailedException e)
                    {
                        TestContext.WriteLine($" => Failed! Error: {e.Message}");

                    }
                }
                //Điều kiện: nếu x1_exp_AnBao và x2_expe_AnBao không phải kiểu double
                else
                {
                    TestContext.WriteLine($"   Expected: {x1_exp_AnBao.ToString()}");
                    TestContext.WriteLine($"   Actual: {kq_AnBao}");
                    try
                    {
                        //So sánh kết quả mong đợi với kết quả thực tế
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
            //Đóng file excel
            wb_bac2_AnBao.Close(false);
            excel.Quit();

            ws_bac2_AnBao = null;
            wb_bac2_AnBao = null;
            excel = null;
        }

    }
}
