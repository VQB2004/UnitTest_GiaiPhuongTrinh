using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiPhuongTrinh_AnBao
{
    // nhớ để public class
   public class Bac1_class_AnBao
    {
        private int a_AnBao, b_AnBao;
        
        public Bac1_class_AnBao(int a_AnBao, int b_AnBao)
        {
            this.a_AnBao = a_AnBao;
            this.b_AnBao = b_AnBao;
        }
        public (double,string)Giai_bac1_AnBao()
        {
            double x_AnBao = 0;
            string kq_AnBao = "";

            if (a_AnBao == 0)
            {
                kq_AnBao = "No sol"; // vô nghiệm
            }
            else
            {
                x_AnBao = Math.Round(-(double)b_AnBao / (double)a_AnBao, 1);
            }
        

            return (x_AnBao, kq_AnBao);
        }
    }
}
