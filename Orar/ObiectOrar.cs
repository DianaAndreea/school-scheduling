using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{
    class ObiectOrar
    {


        public string Ora { get; set; }
        public string Luni { get; set; }
        public string Marti { get; set; }
        public string Miercuri { get; set; }
        public string Joi { get; set; }
        public string Vineri { get; set; }

        public ObiectOrar() { }


        public ObiectOrar(String ora, String l, String m, String mm, String j, String v)
        {
            this.Ora = ora;
            this.Luni = l;
            this.Marti = m;
            this.Miercuri = mm;
            this.Joi = j;
            this.Vineri = v;
        }
    }

}
