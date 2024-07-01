using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Аукцион.Class;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            ListBox listBox = new ListBox();
            НовыйЛист новыйЛист = new НовыйЛист();
            новыйЛист.LoadFullRowsFromDatabase4(listBox);
        }

        [TestMethod]
        public void TestMethod1()
        {
            TextBox textBox = new TextBox();
            textBox.Text = "test";
            ListBox listBox = new ListBox();
            НовыйЛист новыйЛист = new НовыйЛист();
            новыйЛист.You(listBox,textBox);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ComboBox listBox = new ComboBox();
            НовыйЛист новыйЛист = new НовыйЛист();
            новыйЛист.AdminUser(listBox);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TextBox textBox = new TextBox();
            textBox.Text = "test";
            ListBox listBox = new ListBox();
            Уведом новыйЛист = new Уведом();
            новыйЛист.LoadFullRowsFromDatabase4(listBox, textBox);
        }

        [TestMethod]
        public void TestMethod4()
        {
            ListBox listBox = new ListBox();
            Уведом новыйЛист = new Уведом();
            новыйЛист.LoadFullRows(listBox);
        }
    }
}
