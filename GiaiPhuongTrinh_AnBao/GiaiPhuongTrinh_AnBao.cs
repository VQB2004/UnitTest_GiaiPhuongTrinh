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
    public partial class GiaiPhuongTrinh_AnBao: Form
    {
        public GiaiPhuongTrinh_AnBao()
        {
            InitializeComponent();
        }

        private void btn_giai_bac1_AnBao_Click(object sender, EventArgs e)
        {
            int a_AnBao = int.Parse(txt_a_bac1_AnBao.Text);
            int b_AnBao = int.Parse(txt_b_bac1_AnBao.Text);
            Bac1_class_AnBao c_AnBao = new Bac1_class_AnBao(a_AnBao, b_AnBao);
            if (c_AnBao.Giai_bac1_AnBao().Item2 == "")
                txt_ketqua_bac1_AnBao.Text = c_AnBao.Giai_bac1_AnBao().Item1.ToString();
            else
                txt_ketqua_bac1_AnBao.Text = c_AnBao.Giai_bac1_AnBao().Item2.ToString();


        }

        private void btn_giai_bac2_AnBao_Click(object sender, EventArgs e)
        {
            int a_AnBao = int.Parse(txt_a_bac2_AnBao.Text);
            int b_AnBao = int.Parse(txt_b_bac2_AnBao.Text);
            int c_AnBao = int.Parse(txt_c_bac2_AnBao.Text);
            int delta_AnBao = b_AnBao * b_AnBao - 4 * a_AnBao * c_AnBao;
            Bac2_class_AnBao x_AnBao = new Bac2_class_AnBao(a_AnBao, b_AnBao, c_AnBao);
            if(a_AnBao == 0)
            {
                txt_ketqua_bac2_AnBao.Text = x_AnBao.Giai_bac2_AnBao().Item3;
            }    
            else if(delta_AnBao > 0)
            {
                txt_ketqua_bac2_AnBao.Text = "x1 = " + Math.Round(x_AnBao.Giai_bac2_AnBao().Item1, 2) + " và x2 = " + Math.Round(x_AnBao.Giai_bac2_AnBao().Item2, 2);
            }
            else if (delta_AnBao == 0)
            {
                txt_ketqua_bac2_AnBao.Text = "x = "+ Math.Round(x_AnBao.Giai_bac2_AnBao().Item1, 2);
            }
            else
            {
                txt_ketqua_bac2_AnBao.Text = x_AnBao.Giai_bac2_AnBao().Item3;
            }
        }

    }
}
