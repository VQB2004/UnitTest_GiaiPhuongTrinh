using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiPhuongTrinh_AnBao
{
    // public class
    class Bac2_class_AnBao
    {
        private int a, b, c;
        public Bac2_class_AnBao(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        
        public (double,double,string) Giai_bac2_AnBao()
        {
            double x1 = 0;
            double x2 = 0;
            string kq = "";
            int delta = b * b - 4 * a * c;

            if (delta > 0)
            {
                x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            }
            else if (delta == 0)
            {
                x1=x2 = -b / (2 * a);
            }
            else
            {
                kq = "Vô nghiệm";
            }
            return (x1, x2,kq);
        }
    }
}
