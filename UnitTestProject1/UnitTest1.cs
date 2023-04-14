using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;
using System.IO;
using System.Collections.Generic;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWriteFile()
        {
            PairGenerator pairGenerator = new PairGenerator();
            string text = pairGenerator.Text('�');
            string file = new string("text1.txt");
            file = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\", file);

            pairGenerator.WriteFile(file);
            Assert.IsTrue(File.Exists(file));
        }

        [TestMethod]
        public void TestNoFindandWriteFile()
        {
            PairGenerator pairGenerator = new PairGenerator();

            string file = new string("text4.txt");
            file = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\", file);
            Assert.IsFalse(File.Exists(file));

            pairGenerator.Text('�');
            pairGenerator.WriteFile(file);
            Assert.IsTrue(File.Exists(file));

        }

        [TestMethod]
        public void TestCount()
        {
            WordGenerator wordGenerator = new WordGenerator();
            string text = wordGenerator.Text();
            double count = wordGenerator.GetCount();
            Assert.AreEqual(146185127, count);

        }


        [TestMethod]
        public void TestLengthText()
        {
            PairGenerator pairGenerator = new PairGenerator();
            string text = pairGenerator.Text('�');
            Assert.IsTrue(text.Length == 1000);
        }


        [TestMethod]
        public void TestPairGenerator()
        {
            PairGenerator pairGenerator = new PairGenerator();
            string text = pairGenerator.Text('�');
            Assert.IsTrue(!text.Contains("��"));
            Assert.IsTrue(!text.Contains("��"));
            Assert.IsTrue(!text.Contains("��"));

        }


        [TestMethod]
        public void TestWordGenerator()
        {
            double eps = 0.1;
            WordGenerator wordGenerator = new WordGenerator();
            string text = wordGenerator.Text();
            SortedDictionary<string,double> result = wordGenerator.stat2;
            foreach (KeyValuePair<string, double> entry in result)
            {
                double temp = wordGenerator.stat[entry.Key]/(wordGenerator.GetCount());
                Assert.IsTrue(System.Math.Abs(entry.Value/1000 - temp)<=eps);
            }

        }


        [TestMethod]
        public void TestWordPair()
        {
            double eps = 0.1;
            PairWord pairWord = new PairWord();
            string text = pairWord.Text();
            SortedDictionary<string, double> result = pairWord.stat3;
            foreach (KeyValuePair<string, double> entry in result)
            {
                double temp = pairWord.stat[entry.Key] / pairWord.GetCount();
                Assert.IsTrue(System.Math.Abs(entry.Value / 1000 - temp) <= eps);
            }

        }


    }
}