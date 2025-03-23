using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPhuongTrinh_AnBao
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_giai_bac1_AnBao_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txt_a_bac1_AnBao.Text);
            int b = int.Parse(txt_b_bac1_AnBao.Text);
            Bac1_class_AnBao c = new Bac1_class_AnBao(a, b);
            if (c.Giai_bac1_AnBao().Item2 == "")
                txt_ketqua_bac1_AnBao.Text = c.Giai_bac1_AnBao().Item1.ToString();
            else
                txt_ketqua_bac1_AnBao.Text = c.Giai_bac1_AnBao().Item2.ToString();


        }

        private void btn_giai_bac2_AnBao_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txt_a_bac2_AnBao.Text);
            int b = int.Parse(txt_b_bac2_AnBao.Text);
            int c = int.Parse(txt_c_bac2_AnBao.Text);

            if(a==0)
            {
                txt_ketqua_bac2_AnBao.Text = "Không là phương trình bậc 2";
            }  
            else
            {
                Bac2_class_AnBao d_AnBao = new Bac2_class_AnBao(a, b, c);

                int delta = b * b - 4 * a * c;

                if (delta > 0)
                {
                    double x1 = Math.Round(d_AnBao.Giai_bac2_AnBao().Item1,2);
                    double x2 = Math.Round(d_AnBao.Giai_bac2_AnBao().Item2,2);
                   
                    txt_ketqua_bac2_AnBao.Text = "x1: " + x1 + "; x2: " + x2 ;
                }
                else if (delta == 0)
                {
                    double x = Math.Round(d_AnBao.Giai_bac2_AnBao().Item1);
                    txt_ketqua_bac2_AnBao.Text = "Nghiệm kép: " + x;
                }
                else
                {
                    
                    txt_ketqua_bac2_AnBao.Text = "Phương trình vô nghiệm!";
                }
            }    
        }
    }
}
