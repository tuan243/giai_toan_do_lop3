using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace toandolop3csharp
{
    public partial class Form1 : Form
    {
        string problem;
        //string solution;

        public Form1()
        {
            InitializeComponent();
        }

        void OneExpressionMath()
        {
            label1.Text = "Bài Giải:\n";
            string donvi = "";
            string doituong2;
            string operand1;
            string operand2;

            string[] sentences = problem.Split(',', '.','?');

            doituong2 = sentences[2].Substring(sentences[2].IndexOf("Hỏi") + 4, sentences[2].IndexOf("bao nhiêu") - sentences[2].IndexOf("Hỏi") - 5);
            donvi = sentences[2].Substring(sentences[2].IndexOf("bao nhiêu") + 10);
            operand1 = Regex.Match(sentences[0], @"\d+").Value;
            string temp = Regex.Match(sentences[1], @"[1-9]/[1-9]").Value;
            if (temp != "")
            {
                operand2 = temp[2].ToString();
            }
            else operand2 = Regex.Match(sentences[1], @"\d+").Value;

            label1.Text += String.Format("Số {0} của {1} là:\n", donvi, doituong2);

            int result = 0;
            if (Regex.Match(sentences[1], @"gấp|bằng").Value != "")
            {
                result = Convert.ToInt32(operand1) * Convert.ToInt32(operand2);
                label1.Text += String.Format("      {0} x {1} = {2} ({3})\n", operand1, operand2, result, donvi);
            }
            else if(Regex.Match(sentences[1],@"nhẹ|ít|ngắn|thấp").Value != "")
            {
                result = Convert.ToInt32(operand1) - Convert.ToInt32(operand2);
                label1.Text += String.Format("      {0} - {1} = {2} ({3})\n", operand1, operand2, result, donvi);
            }
            else if(Regex.Match(sentences[1],@"nặng|nhiều|dài|cao").Value != "")
            {
                result = Convert.ToInt32(operand1) + Convert.ToInt32(operand2);
                label1.Text += String.Format("      {0} + {1} = {2} ({3})\n", operand1, operand2, result, donvi);
            }
            else
            {
                result = Convert.ToInt32(operand1) / Convert.ToInt32(operand2);
                label1.Text += String.Format("      {0} : {1} = {2} ({3})\n", operand1, operand2, result, donvi);
            }
            label1.Text += String.Format("Đáp số: {0} {1}", result, donvi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            problem = textBox1.Text;
            OneExpressionMath();
        }
    }
}
