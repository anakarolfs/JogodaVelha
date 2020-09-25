using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oJogoDaVelha
{
    public partial class Form1 : Form
    {
        int xpontos = 0, opontos = 0, empates = 0, rodadas = 0;
        bool turno = true, jogoFinal= false; // true - X _ false - O
        string[] texto = new string[9];

        private void button14_Click(object sender, EventArgs e)
        {
            button9.Text = "";
            button8.Text = "";
            button7.Text = "";
            button6.Text = "";
            button5.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";

            rodadas = 0;
            jogoFinal = false;
            for(int i = 0; i <9; i++)
            {
                texto[i] = "";           
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            xpontos = 0;
            label6.Text = Convert.ToString(xpontos);
            opontos = 0;
            label5.Text = Convert.ToString(opontos);
            empates = 0;
            label4.Text = Convert.ToString(empates);

            button9.Text = "";
            button8.Text = "";
            button7.Text = "";
            button6.Text = "";
            button5.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";

            rodadas = 0;
            jogoFinal = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogoFinal == false)
            {
                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    check(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    check(2);
                }
            }
        }  // botão

        void vencedor (int playerWin)
        {
            jogoFinal = true;
             if (playerWin == 1)
            {
                xpontos++;
                label6.Text =Convert.ToString(xpontos);
                MessageBox.Show("Jogador X Venceu!");
                turno = true;
            }else
            {
                opontos++;
                label5.Text = Convert.ToString(opontos);
                MessageBox.Show("Jogador O Venceu!");
                turno = false;
            }
        }

        void check(int checkPlayer) // 1 = X _ 2 = O
        {
            string suport;

            if (checkPlayer == 1)
            {
                suport = "X";
            } else
            {
                suport = "O";
            } // suport

            for (int horizontal = 0; horizontal < 8; horizontal+=3)
            {
                if(suport == texto[horizontal])
                {
                    if(texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                        {
                        vencedor(checkPlayer);
                        return;
                    } //horizontal
                }
            }// loop horizontal

            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suport == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        vencedor(checkPlayer);
                        return;
                    } //vertical
                }
            }// loop vertical

            if (texto[0] == suport)
                {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    vencedor(checkPlayer);
                    return;
                } //diagonal Prcipal
            }//diagonal 

            if (texto[2] == suport)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    vencedor(checkPlayer);
                    return;
                } //diagonal Secundaria
            }//diagonal 

            if(rodadas == 9 && jogoFinal == false)
            {
                empates++;
                label4.Text = Convert.ToString(empates);
                MessageBox.Show("Empate!");
                jogoFinal = true;
                return;

            }
        }


    }
}
