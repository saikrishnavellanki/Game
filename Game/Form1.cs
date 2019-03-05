using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Stack<int> numberStack = new Stack<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            BindNumbersSplitGrid();

        }

        private void BindNumbersSplitGrid()
        {
            try
            {
                DataTable dtSplit = new DataTable();
                DataRow drSplit = dtSplit.NewRow();

                for (int i = 1; i <= 37; i++)
                {
                    dtSplit.Columns.Add("N" + i).Caption = i.ToString();
                }

                drSplit["N1"] = 5;
                drSplit["N2"] = 24;
                drSplit["N3"] = 16;
                drSplit["N4"] = 33;
                drSplit["N5"] = 1;
                drSplit["N6"] = 20;
                drSplit["N7"] = 14;
                drSplit["N8"] = 31;
                drSplit["N9"] = 9;
                drSplit["N10"] = 22;
                drSplit["N11"] = 18;
                drSplit["N12"] = 29;
                drSplit["N13"] = 7;
                drSplit["N14"] = 28;
                drSplit["N15"] = 12;
                drSplit["N16"] = 35;
                drSplit["N17"] = 3;
                drSplit["N18"] = 26;

                drSplit["N19"] = 0;
                drSplit["N20"] = 32;
                drSplit["N21"] = 15;
                drSplit["N22"] = 19;
                drSplit["N23"] = 4;
                drSplit["N24"] = 21;
                drSplit["N25"] = 2;
                drSplit["N26"] = 25;
                drSplit["N27"] = 17;
                drSplit["N28"] = 34;
                drSplit["N29"] = 6;
                drSplit["N30"] = 27;
                drSplit["N31"] = 13;
                drSplit["N32"] = 36;
                drSplit["N33"] = 11;
                drSplit["N34"] = 30;
                drSplit["N35"] = 8;
                drSplit["N36"] = 23;
                drSplit["N37"] = 10;

                dtSplit.Rows.Add(drSplit.ItemArray);

                dataGridFixed.DataSource = dtSplit;

                dataGridFixed.Rows[0].Cells[0].Selected = false;
                dataGridFixed.Rows[0].Cells[18].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {

                    int enteredNumber = int.Parse(textBox1.Text);

                    if (enteredNumber >= 0 && enteredNumber <= 36)
                    {
                        resultGrid.Visible = true;

                        //Get Numbers
                        numbersGrid.DataSource = GetNumbers(enteredNumber);

                        //Get Neighbours
                        resultGrid.DataSource = GetNeighbours(enteredNumber);

                        //Grayout number in GridFixed numbers
                        if (enteredNumber == 0)
                            BindNumbersSplitGrid();
                        else
                            GrayoutFixedNumberGrid(enteredNumber);
                    }
                    else
                    {
                        //resultGrid.Visible = false;

                        MessageBox.Show("Number should be in between 0 and 36.");
                    }

                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public DataTable GetNumbers(int n)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NUMBERS");

            try
            {
                numberStack.Push(n);

                foreach (var item in numberStack)
                {
                    dt.Rows.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public DataTable GetNeighbours(int n)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NEIGHBOURS");

            try
            {
                switch (n)
                {
                    case 0:
                        {
                            dt.Rows.Add(26);
                            dt.Rows.Add(32);
                            break;
                        }
                    case 1:
                        {
                            dt.Rows.Add(20);
                            dt.Rows.Add(33);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "11";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 2:
                        {
                            dt.Rows.Add(21);
                            dt.Rows.Add(25);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "11";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "20";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "29";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 3:
                        {
                            dt.Rows.Add(26);
                            dt.Rows.Add(35);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "12";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "21";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "30";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "13";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "31";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 4:
                        {
                            dt.Rows.Add(19);
                            dt.Rows.Add(21);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();


                            dr["EXTRA"] = "13";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "22";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "31";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "14";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "22";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 5:
                        {
                            dt.Rows.Add(10);
                            dt.Rows.Add(24);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "14";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "23";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "32";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "15";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 6:
                        {
                            dt.Rows.Add(27);
                            dt.Rows.Add(34);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "15";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "24";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "33";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "16";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "23";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "32";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 7:
                        {
                            dt.Rows.Add(28);
                            dt.Rows.Add(29);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "16";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "25";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "34";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "17";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 8:
                        {
                            dt.Rows.Add(23);
                            dt.Rows.Add(30);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "17";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "26";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "35";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "18";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "24";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "28";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 9:
                        {
                            dt.Rows.Add(22);
                            dt.Rows.Add(31);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "18";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "27";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "36";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "19";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "33";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 10:
                        {
                            dt.Rows.Add(5);
                            dt.Rows.Add(23);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "10";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "20";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "30";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "19";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "25";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "28";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 11:
                        {
                            dt.Rows.Add(30);
                            dt.Rows.Add(36);

                            break;
                        }
                    case 12:
                        {
                            dt.Rows.Add(28);
                            dt.Rows.Add(35);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "26";
                            dt.Rows.Add(dr.ItemArray);

                            dr["EXTRA"] = "34";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 13:
                        {
                            dt.Rows.Add(27);
                            dt.Rows.Add(36);
                            break;
                        }
                    case 14:
                        {
                            dt.Rows.Add(20);
                            dt.Rows.Add(31);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "27";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 15:
                        {
                            dt.Rows.Add(19);
                            dt.Rows.Add(32);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "35";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 16:
                        {
                            dt.Rows.Add(24);
                            dt.Rows.Add(33);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "28";

                            dt.Rows.Add(dr.ItemArray);
                            break;
                        }
                    case 17:
                        {
                            dt.Rows.Add(25);
                            dt.Rows.Add(34);
                            break;
                        }
                    case 18:
                        {
                            dt.Rows.Add(22);
                            dt.Rows.Add(29);

                            //Bind Extra numbers
                            dt.Columns.Add("EXTRA");
                            DataRow dr = dt.NewRow();

                            dr["EXTRA"] = "29";
                            dt.Rows.Add(dr.ItemArray);
                            dr["EXTRA"] = "36";
                            dt.Rows.Add(dr.ItemArray);

                            break;
                        }
                    case 19:
                        {
                            dt.Rows.Add(4);
                            dt.Rows.Add(15);
                            break;
                        }
                    case 20:
                        {
                            dt.Rows.Add(1);
                            dt.Rows.Add(14);
                            break;
                        }
                    case 21:
                        {
                            dt.Rows.Add(2);
                            dt.Rows.Add(4);
                            break;
                        }
                    case 22:
                        {
                            dt.Rows.Add(9);
                            dt.Rows.Add(18);
                            break;
                        }
                    case 23:
                        {
                            dt.Rows.Add(8);
                            dt.Rows.Add(10);
                            break;
                        }
                    case 24:
                        {
                            dt.Rows.Add(5);
                            dt.Rows.Add(16);
                            break;
                        }
                    case 25:
                        {
                            dt.Rows.Add(2);
                            dt.Rows.Add(17);
                            break;
                        }
                    case 26:
                        {
                            dt.Rows.Add(0);
                            dt.Rows.Add(3);
                            break;
                        }
                    case 27:
                        {
                            dt.Rows.Add(6);
                            dt.Rows.Add(13);
                            break;
                        }
                    case 28:
                        {
                            dt.Rows.Add(7);
                            dt.Rows.Add(12);
                            break;
                        }
                    case 29:
                        {
                            dt.Rows.Add(7);
                            dt.Rows.Add(18);
                            break;
                        }
                    case 30:
                        {
                            dt.Rows.Add(8);
                            dt.Rows.Add(11);
                            break;
                        }
                    case 31:
                        {
                            dt.Rows.Add(9);
                            dt.Rows.Add(14);
                            break;
                        }
                    case 32:
                        {
                            dt.Rows.Add(0);
                            dt.Rows.Add(15);
                            break;
                        }
                    case 33:
                        {
                            dt.Rows.Add(1);
                            dt.Rows.Add(16);
                            break;
                        }
                    case 34:
                        {
                            dt.Rows.Add(6);
                            dt.Rows.Add(17);
                            break;
                        }
                    case 35:
                        {
                            dt.Rows.Add(3);
                            dt.Rows.Add(12);
                            break;
                        }
                    case 36:
                        {
                            dt.Rows.Add(11);
                            dt.Rows.Add(13);
                            break;
                        }
                }

                //SUM & DIFFERENCE OF LAST TWO NUMBERS
                if (numberStack.Count > 1)
                {
                    int firstNumber = numberStack.ElementAt(0);
                    int secondNumber = numberStack.ElementAt(1);


                    //SUM OF LAST TWO NUMBERS
                    int resultFirstSecondAdd = firstNumber + secondNumber;

                    dt.Columns.Add("SUM OF FIRST AND SECOND NUMBERS");
                    DataRow drSum = dt.NewRow();
                    drSum["SUM OF FIRST AND SECOND NUMBERS"] = resultFirstSecondAdd;

                    if (resultFirstSecondAdd <= 36)
                        dt.Rows.Add(drSum.ItemArray);

                    //DIFFERENCE OF LAST TWO NUMBERS
                    int resultFirstSecondDiffernce = firstNumber > secondNumber ? firstNumber - secondNumber : secondNumber - firstNumber;

                    dt.Columns.Add("DIFFERENCE OF FIRST AND SECOND NUMBERS");
                    DataRow drDifference = dt.NewRow();
                    drDifference["DIFFERENCE OF FIRST AND SECOND NUMBERS"] = resultFirstSecondDiffernce;

                    if (resultFirstSecondDiffernce <= 36)
                        dt.Rows.Add(drDifference.ItemArray);


                    //SUM & DIFFERENCE OF LAST TWO NUMBERS LEAVING LATEST
                    if (numberStack.Count > 2)
                    {
                        int thirdNumber = numberStack.ElementAt(2);

                        //SUM OF LAST TWO NUMBERS LEAVING LATEST
                        int resultSecondThirdAdd = firstNumber + thirdNumber;

                        dt.Columns.Add("SUM OF FIRST AND THIRD NUMBERS");
                        DataRow drLeavingTopSum = dt.NewRow();
                        drLeavingTopSum["SUM OF FIRST AND THIRD NUMBERS"] = resultSecondThirdAdd;

                        if (resultSecondThirdAdd <= 36)
                            dt.Rows.Add(drLeavingTopSum.ItemArray);

                        //DIFFERENCE OF LAST TWO NUMBERS LEAVING LATEST
                        int resultSecondThirdDiffernce = firstNumber > thirdNumber ? firstNumber - thirdNumber : thirdNumber - firstNumber;

                        dt.Columns.Add("DIFFERENCE OF FIRST AND THIRD NUMBERS");
                        DataRow drLeavingTopDifference = dt.NewRow();
                        drLeavingTopDifference["DIFFERENCE OF FIRST AND THIRD NUMBERS"] = resultSecondThirdDiffernce;

                        if (resultSecondThirdDiffernce <= 36)
                            dt.Rows.Add(drLeavingTopDifference.ItemArray);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public void GrayoutFixedNumberGrid(int n)
        {
            try
            {
                foreach (DataGridViewRow dr in dataGridFixed.Rows)
                {
                    for (int i = 0; i < 37; i++)
                    {
                        if (dr.Cells[i].Value != null)
                        {
                            if (int.Parse(dr.Cells[i].Value.ToString()) == n)
                            {
                                dr.Cells[i].Style.ForeColor = Color.Green;
                                dr.Cells[i].Style.BackColor = Color.Yellow;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                numberStack = new Stack<int>();
                resultGrid.DataSource = new DataTable();
                numbersGrid.DataSource = new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
