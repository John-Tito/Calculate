using System;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Calculater : Form
    {
        private enum Operater
        {
            undefine = 0,
            multiply = 1,
            divide,
            plus,
            subtract
        };

        private string num1 = null;
        private string num2 = null;
        private string result = null;
        private Operater ope = Operater.undefine;

        public Calculater()
        {
            InitializeComponent();
        }


        private void Btn_num_Click(object sender, EventArgs e)
        {
            Button send = sender as Button;
            if (ope == Operater.undefine)
            {
                num1 += send.Text;
                rtbx_source1.AppendText(send.Text);
            }
            else
            {
                num2 += send.Text;
                rtbx_source2.AppendText(send.Text);
            }
        }

        private void Btn_clr_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Btn_op_equ_Click(object sender, EventArgs e)
        {
            double numA = Convert.ToUInt64(num1);
            double numB = Convert.ToUInt64(num2);
            switch (ope)
            {
                case Operater.multiply:
                    result = (numA * numB).ToString();
                    break;

                case Operater.divide:
                    if (numB == 0)
                    {
                        rtbx_result.Clear();
                        rtbx_result.AppendText("除数不能为零");
                        return;
                    }
                    else
                    {
                        result = (numA / numB).ToString();
                        break;
                    }


                case Operater.plus:
                    result = (numA + numB).ToString();
                    break;

                case Operater.subtract:
                    result = (numA - numB).ToString();
                    break;

                default:
                    rtbx_result.Clear();
                    rtbx_result.AppendText("检查运算符");
                    return;
            }
            rtbx_result.AppendText(result);
        }

        private void Btn_op_Click(object sender, EventArgs e)
        {
            Button send = sender as Button;
            rtbx_operate.Clear();
            switch (send.Text)
            {
                case "*":
                    ope = Operater.multiply;
                    break;

                case "/":
                    ope = Operater.divide;
                    break;

                case "+":
                    ope = Operater.plus;
                    break;

                case "-":
                    ope = Operater.subtract;
                    break;

                default:
                    ope = Operater.undefine;
                    break;
            }
            rtbx_operate.AppendText(send.Text);
        }

        private void Reset()
        {
            rtbx_source1.Clear();
            rtbx_source2.Clear();
            rtbx_operate.Clear();
            rtbx_result.Clear();
            num1 = null;
            num2 = null;
            result = null;
            ope = Operater.undefine;
        }

        private void Calculater_Load(object sender, EventArgs e)
        {

        }
    }
}