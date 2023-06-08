using MaterialSkin;
using MaterialSkin.Controls;
using NCalc;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : MaterialForm
    {
        private List<MaterialRaisedButton> _btnNumbers;

        public CalculatorForm()
        {
            InitializeComponent();
            InitDefaultDesign();
            InitBtnNumbers();
        }

        private void InitDefaultDesign()
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void InitBtnNumbers()
        {
            _btnNumbers = new List<MaterialRaisedButton>()
            {
                oneNumberBtn,
                twoNumberBtn,
                threeNumberBtn,
                fourNumberBtn,
                fiveNumberBtn,
                sixNumberBtn,
                sevenNumberBtn,
                eigthNumberBtn,
                nineNumberBtn,
                zeroNumberBtn,
                plusBtn,
                divideBtn,
                minusBtn,
                multiplyBtn,
                commaBtn,
                percentBtn
            };

            _btnNumbers.ForEach(btn => btn.Click += (sender, e) =>
            {
                if (output.Text.Length != 0 && output.Text[0] == '0')
                    output.Text = string.Empty;
                output.Text += btn.Text;
            });
        }

        private void sqrBtn_Click(object sender, EventArgs e) 
            => output.Text = $"Pow({output.Text}, 2)";

        private void fractionBtn_Click(object sender, EventArgs e)
            => output.Text = $"1 / {output.Text}";

        private void sqrtButton_Click(object sender, EventArgs e)
            => output.Text = $"Sqrt({output.Text})";

        private void cosBtn_Click(object sender, EventArgs e)
            => output.Text = $"Cos({output.Text})";

        private void sinBtn_Click(object sender, EventArgs e)
            => output.Text = $"Sin({output.Text})";

        private void tanBtn_Click(object sender, EventArgs e)
            => output.Text = $"Tan({output.Text})";

        private void logBtn_Click(object sender, EventArgs e)
            => output.Text = $"Log10({output.Text})";

        private void log2Btn_Click(object sender, EventArgs e)
            => output.Text = $"Log(2, {output.Text})";

        private void absBtn_Click(object sender, EventArgs e)
            => output.Text = $"Abs({output.Text})";

        private void expPowBtn_Click(object sender, EventArgs e)
            => output.Text = $"Exp({output.Text})";

        private void lastExpressions_SelectedIndexChanged(object sender, EventArgs e)
            => output.Text = lastExpressions.SelectedItem.ToString();

        private void clearInputBtn_Click(object sender, System.EventArgs e) 
            => output.Text = string.Empty;

        private void deleteSymbolBtn_Click(object sender, EventArgs e)
        {
            if (output.Text.Length == 0) return;
            output.Text = output.Text.Remove(output.Text.Length - 1);
        }

        private void equalsBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                var expression = new Expression(output.Text);
                var lastExpressionForList = output.Text;
                output.Text = expression.Evaluate().ToString();
                lastExpressionForList += "=" + output.Text;

                lastExpressions.Items.Add(lastExpressionForList);
            }
            catch (Exception ex)
            {
                output.Text = "Ошибка в выражении";
            }
        }
    }
}
