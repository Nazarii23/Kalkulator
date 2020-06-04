using System;
using Kalkulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestKalkulator
{
    [TestClass]
    public class UnitTestKalkulator
    {
        
        [TestMethod]
        public void CCTest()
        {
            MainWindow mw = new MainWindow();
            mw.Clear_Click(null, null);
            string expected = "0";

            Assert.AreEqual(expected, mw.textBlock.Text);
        }

        [TestMethod]
        public void SCCTest()
        {
            MainWindow mw = new MainWindow();
            mw.textBlock.Text = "Some text here";
            int expected = mw.textBlock.Text.Length - 1;
            mw.Single_Clear_Click(null, null);

            Assert.AreEqual(expected, mw.textBlock.Text.Length);
        }

        [TestMethod]
        public void SCCTest2()
        {
            MainWindow mw = new MainWindow();
            mw.textBlock.Text = "";
            string expected = "0";
            mw.Single_Clear_Click(null, null);

            Assert.AreEqual(expected, mw.textBlock.Text);
        }

        [TestMethod]
        public void ECTest()
        {
            MainWindow mw = new MainWindow();
            string expected = "";

            mw.Eaquals_Click(null, null);

            Assert.AreEqual(expected, mw.label.Content);
        }

        [TestMethod]
        public void ECTest2()
        {
            MainWindow mw = new MainWindow();
            bool expected = true;

            mw.operation = "+";
            mw.textBlock.Text = "5";
            mw.Eaquals_Click(null, null);

            Assert.AreEqual(expected, mw.enter_value);
        }
    }
}
