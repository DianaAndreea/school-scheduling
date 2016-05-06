using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{
    class Modul
    {
        private int codModul;
        private DateTime ora;
        private int codDisciplina;

        public int CodModul
        {
            get { return codModul; }
            set { codModul = value; }
        }
        public DateTime Ora
        {
            get { return ora; }
            set { ora = value; }
        }
        public int CodDisciplina
        {
            get { return codDisciplina; }
            set { codDisciplina = value; }
        }


        public void Insert(int codModul, DateTime ora, int codDisciplina)
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
