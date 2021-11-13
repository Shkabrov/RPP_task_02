using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using RPP_task_02;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RichTextBox sourceRTB = new RichTextBox();
            sourceRTB.LoadFile("test1.rtf");

            RichTextBox testRTB = new RichTextBox();
            testRTB.LoadFile("original1.rtf");

            TextBox testTB = new TextBox();
            testTB.Text = "файл";

            RTBMod.FindWord(testRTB, testTB);

            //sourceRTB.SaveFile("originalShow1.rtf", RichTextBoxStreamType.RichText);

            //testRTB.SaveFile("testShow1.rtf", RichTextBoxStreamType.RichText);

            Assert.AreEqual(sourceRTB.Rtf, testRTB.Rtf);
        }

        [TestMethod]
        public void TestMethod2()
        {
            RichTextBox sourceRTB = new RichTextBox();
            sourceRTB.LoadFile("test2.rtf");

            RichTextBox testRTB = new RichTextBox();
            testRTB.LoadFile("original2.rtf");

            TextBox testTB1 = new TextBox();
            testTB1.Text = "файл";

            TextBox testTB2 = new TextBox();
            testTB2.Text = "код";

            RTBMod.ReplaceWord(testRTB, testTB1, testTB2);

            //sourceRTB.SaveFile("originalShow2.rtf", RichTextBoxStreamType.RichText);

            //testRTB.SaveFile("testShow2.rtf", RichTextBoxStreamType.RichText);

            Assert.AreEqual(sourceRTB.Text, testRTB.Text);
        }
    }
}
