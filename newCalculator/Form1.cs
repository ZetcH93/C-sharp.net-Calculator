using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn9.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn6.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn3.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            InputBox.Text += btn0.Text;
        }

        private void btnSpecial_Click(object sender, EventArgs e)
        {
            InputBox.Text += btnSpecial.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InputBox.ResetText();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            InputBox.Text += btnPlus.Text;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            InputBox.Text += btnMinus.Text;
        }

    
        private void btnMulti_Click(object sender, EventArgs e)
        {
            InputBox.Text += btnMulti.Text;
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            InputBox.Text += btnDivision.Text;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            String inputValue = InputBox.Text;
            String numberOne = "";
            String numberTwo = "";
            char modifier = ' ';
            int trigger = 0;
            int size = inputValue.Length;
            int counter = 0;
            double result = 0.0;

            while (counter < size)
            {
                if(inputValue[counter] == '+' && trigger == 0)
                {
                    modifier = '+';
                    trigger = 1;
                }
                else if (inputValue[counter] == '-' && trigger == 0)
                {
                    modifier = '-';
                    trigger = 1;
                }
                else if (inputValue[counter] == '*' && trigger == 0)
                {
                    modifier = '*';
                    trigger = 1;
                }
                else if (inputValue[counter] == '/' && trigger == 0)
                {
                    modifier = '/';
                    trigger = 1;
                }
                else if (inputValue[counter] == '.' && trigger == 1)
                {
                    numberTwo += inputValue[counter];
                }
                else if (inputValue[counter] == '.' && trigger == 0)
                {
                    numberOne += inputValue[counter];
                }
                else if ((trigger == 1) && (checker(inputValue,counter)))
                {
                    numberTwo += inputValue[counter];
                }
                else if (trigger == 0 )
                {
                    numberOne += inputValue[counter];
                }
                else
                {

                    result = resultCalculator(modifier, numberTwo, numberOne, result);
                    modifier = inputValue[counter];
                    numberOne = "";
                    numberTwo = "";
                }
                counter++;
            }

      
            result = resultCalculator(modifier, numberTwo, numberOne, result);
     

            InputBox.Text = result.ToString();
        }

     

        public bool checker(string inputValue, int counter)
        {
            bool value = true;

            if (inputValue[counter] == '+')
            {
                value = false;
            }
            else if (inputValue[counter] == '-')
            {
                value = false;
            }
            else if (inputValue[counter] == '/')
            {
                value = false;
            }

            else if (inputValue[counter] == '*')
            {
                value = false;
            }
            else if (inputValue[counter] == '.')
            {
                value = false;
            }
         

            return value;
        }
        
        
        public double resultCalculator(char modifier, string numberTwo, string numberOne, double result)
        {
            double tempOne = 0.0;
            double tempTwo = 0.0;

            if (modifier == '+')
            {

                if (numberOne.Length > 0 && numberTwo.Length > 0)
                {
                    if (double.TryParse(numberTwo, out tempTwo))
                    {
                        if (double.TryParse(numberOne, out tempOne))
                        {
                            result += (tempOne + tempTwo);
                        }
                    }
                }
                else if (numberOne.Length > 0)
                {
                   if ((double.TryParse(numberOne, out tempOne)))
                        result += tempOne;
                }
                else if (numberTwo.Length > 0)
                {
                   if((double.TryParse(numberTwo, out tempTwo)))
                    result += tempTwo;
                }
         
            }

            else if (modifier == '-')
            {
                if (numberOne.Length > 0 && numberTwo.Length > 0)
                {
                    if (double.TryParse(numberTwo, out tempTwo))
                    {
                        if (double.TryParse(numberOne, out tempOne))
                        {
                            result += (tempOne - tempTwo);
                        }
                    }
                }
                else if (numberOne.Length > 0)
                {
                    if ((double.TryParse(numberOne, out tempOne)))
                        result -= tempOne;
                }
                else if (numberTwo.Length > 0)
                {
                    if ((double.TryParse(numberTwo, out tempTwo)))
                        result -= tempTwo;
                }
            }

            else if (modifier == '/')
            {
                if (numberOne.Length > 0 && numberTwo.Length > 0)
                {
                    if (double.TryParse(numberTwo, out tempTwo))
                    {
                        if (double.TryParse(numberOne, out tempOne))
                        {
                            result += (tempOne / tempTwo);
                        }
                    }
                }
                else if (numberOne.Length > 0)
                {
                    if ((double.TryParse(numberOne, out tempOne)))
                        result /= tempOne;
                }
                else if (numberTwo.Length > 0)
                {
                    if ((double.TryParse(numberTwo, out tempTwo)))
                        result /= tempTwo;
                }
            }

            else if (modifier == '*')
            {
                if (numberOne.Length > 0 && numberTwo.Length > 0)
                {
                    if (double.TryParse(numberTwo, out tempTwo))
                    {
                        if (double.TryParse(numberOne, out tempOne))
                        {
                            result += (tempOne * tempTwo);
                        }
                    }
                }
                else if (numberOne.Length > 0)
                {
                    if ((double.TryParse(numberOne, out tempOne)))
                        result *= tempOne;
                }
                else if (numberTwo.Length > 0)
                {
                    if ((double.TryParse(numberTwo, out tempTwo)))
                        result *= tempTwo;
                }
            };

            return result;
        }
    }

}
