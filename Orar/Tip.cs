
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{

    
    public class Tip
    {


        private int codTip;
        private int an;
        private int grupa;
        private int subgrupa;



        public int CodTip
        {
            get { return codTip; }
            set { codTip = value; }
        }
        public int An
        {
            get { return an; }
            set { an = value; }
        }
        public int Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        public int Subgrupa
        {
            get { return subgrupa; }
            set { subgrupa = value; }
        }

        public void Insert(int codTip, int an, int grupa, int subGrupa)
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    
    }
}
