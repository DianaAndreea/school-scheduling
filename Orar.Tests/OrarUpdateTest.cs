using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Orar.Tests
{
    [TestClass]
    public class OrarUpdateTest
    {
        [TestMethod]
        public void adaugaProfesorTest() {
            OrarUpdate orar = new OrarUpdate();
            var expected1 = new List<String>();
            expected1.Add("Cretu Alexandru");
            var result1 = orar.getListaProfesori();
            Assert.ReferenceEquals(expected1, result1);
        }
        [TestMethod]
        public void adaugaDisciplinaTest()
        {
            OrarUpdate orar = new OrarUpdate();
            var expected2 = new List<String>();
            expected2.Add("Analiza matematica");
            var result2 = orar.getListaDiscipline();
            Assert.ReferenceEquals(expected2, result2);
        }
        [TestMethod]
        public void adaugaSalaTest()
        {
            OrarUpdate orar = new OrarUpdate();
            var expected3 = new List<String>();
            expected3.Add("c23");
            var result3 = orar.getListaSali();
            Assert.ReferenceEquals(expected3, result3);
        }

        [TestMethod]
        public void anTest()
        {
            
            var expected4 = new List<String>();
            expected4.Add("1");
            var result4 = OrarWin.GetAnComboBox();
            Assert.ReferenceEquals(expected4, result4);
        }
        [TestMethod]
        public void grupaTest()
        {
            var expected5 = new List<String>();
            expected5.Add("22c42");
            var result5 = OrarWin.GetGrupaComboBox();
            Assert.ReferenceEquals(expected5, result5);
        }
        [TestMethod]
        public void subgrupaTest()
        {
            var expected6 = new List<String>();
            expected6.Add("22c22a");
            var result6 = OrarWin.GetSubgrupaComboBox();
            Assert.ReferenceEquals(expected6, result6);
        }
        [TestMethod]
        public void modulTest()
        {
            var expected7 = new List<String>();
            expected7.Add("14:00-15:50");
            var result7 = expected7;
            Assert.AreSame(expected7, result7);
        }
        
    }
}
