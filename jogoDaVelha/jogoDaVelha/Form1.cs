using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoDaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;

        bool turno = true, jogoFinal = false; //quando for true é a vez do X

        String[] txtBtnTabuleiro = new string[9];

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";

            rodadas = 0;
            jogoFinal = false;
            for(int i = 0; i < 9; i++)
            {
                txtBtnTabuleiro[i] = "";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //botao de referencia

            int buttonIndex = btn.TabIndex; //pega o index do botao

            if (btn.Text == "" && jogoFinal == false)
            {

                if (turno)
                {
                    btn.Text = "x";
                    txtBtnTabuleiro[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno; //faz a troca do turno do jogador
                    checar_vitoria(1); //player 1
                }
                else
                {
                    btn.Text = "o";
                    txtBtnTabuleiro[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    checar_vitoria(2); //player 2
                }//fim estrutura if
            }
        } //fim btn_Click

        private void vencedor(int playerVencedor)
        {
            jogoFinal = true;

            if(playerVencedor == 1)
            {
                Xplayer++;
                lbl_xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou!");
                turno = true; //se ganhar começa a prox
            }
            else
            {
                Oplayer++;
                lbl_Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou!");
                turno = false; //se ganhar começa a prox
            }
        } //fim vencedor

        private void checar_vitoria(int checaPlayer)
        {
            String flag = "";

            if (checaPlayer == 1)
            {
                flag = "x";
            }
            else
            {
                flag = "o";
            }//fim da flag

            //verificando horizontal
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (flag == txtBtnTabuleiro[horizontal])
                {
                    if (txtBtnTabuleiro[horizontal] == txtBtnTabuleiro[horizontal + 1] &&
                        txtBtnTabuleiro[horizontal] == txtBtnTabuleiro[horizontal + 2])
                    {
                        vencedor(checaPlayer);
                        return;
                    }
                }
            } //fim verificando horizontal

            //verificando vertical
            for (int verical = 0; verical < 3; verical++)
            {
                if (flag == txtBtnTabuleiro[verical])
                {
                    if (txtBtnTabuleiro[verical] == txtBtnTabuleiro[verical + 3] &&
                        txtBtnTabuleiro[verical] == txtBtnTabuleiro[verical + 6])
                    {
                        vencedor(checaPlayer);
                        return;
                    }
                }
            } //fim verificando vertical

            //verificando diagonal
            if (flag == txtBtnTabuleiro[0])
            {
                if (txtBtnTabuleiro[0] == txtBtnTabuleiro[4] &&
                    txtBtnTabuleiro[0] == txtBtnTabuleiro[8])
                {
                    vencedor(checaPlayer);
                    return;
                }
            } //fim verificando diagonal principal

            if (flag == txtBtnTabuleiro[2])
            {
                if (txtBtnTabuleiro[2] == txtBtnTabuleiro[4] &&
                    txtBtnTabuleiro[2] == txtBtnTabuleiro[6])
                {
                    vencedor(checaPlayer);
                    return;
                }
            } //fim verificando diagonal secundaria

            //caso empate
            if(rodadas == 9 && jogoFinal == false)
            {
                empatesPontos++;
                lbl_empate.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("A partida empatou.");
                jogoFinal = true;
                return;
            } //fim caso empate

        } //fim checar_vitoria

    } //fim partial class 

}
