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

            Bac2_class_AnBao x = new Bac2_class_AnBao(a, b, c);
            txt_ketqua_bac2_AnBao.Text = x.Giai_bac2_AnBao().Item3;
        }

    }
}
