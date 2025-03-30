using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiPhuongTrinh_AnBao
{
    // public class
    public class Bac2_class_AnBao
    {
        private int a_AnBao, b_AnBao, c_AnBao;
        public Bac2_class_AnBao(int a_AnBao, int b_AnBao, int c_AnBao)
        {
            this.a_AnBao = a_AnBao;
            this.b_AnBao = b_AnBao;
            this.c_AnBao = c_AnBao;
        }
        
        public (double,double,string) Giai_bac2_AnBao()
        {
            double x1_AnBao = 0;
            double x2_AnBao = 0;
            string kq_AnBao = "";
            int delta_AnBao = b_AnBao * b_AnBao - 4 * a_AnBao * c_AnBao;
            if(a_AnBao == 0)
            {
                kq_AnBao = "no real root";
            }
            else
            {
                if (delta_AnBao > 0)
                {
                    x1_AnBao = (-b_AnBao + Math.Sqrt(delta_AnBao)) / (2 * a_AnBao);
                    x2_AnBao = (-b_AnBao - Math.Sqrt(delta_AnBao)) / (2 * a_AnBao);
                    kq_AnBao = "Two distinct roots";
                }
                else if (delta_AnBao == 0)
                {
                    x1_AnBao = -b_AnBao / (2 * a_AnBao);
                    x2_AnBao = -b_AnBao / (2 * a_AnBao);
                    kq_AnBao = "repeated root";
                }
                else
                {
                    kq_AnBao = "no real root";
                }
            }
            
            return (x1_AnBao, x2_AnBao, kq_AnBao);
        }
    }
}
