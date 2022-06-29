using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProjectFrontEnd
{
    public partial class SolutionPage2 : Form
    {
        // 슬라이딩 메뉴의 폭
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 50;
        // 슬라이딩 메뉴 펼쳐지는 / 접히는 속도
        const int STEP_SLIDING = 10;
        // 슬라이딩 메뉴 최소 크기
        int _posSliding = 200;

        public SolutionPage2()
        {
            InitializeComponent();
        }

        private void checkBoxHide_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            panel1.Hide();
        }

        private void checkBoxHide_CheckedChanged_1(object sender, EventArgs e)
        {
            // 슬라이딩 메뉴 접혔을때
            if (checkBoxHide.Checked == true)
            {
                panel2.Hide();
                panel3.Hide();
                panel4.Hide();
                panel1.Hide();

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                button10.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";


                checkBoxHide.Text = ">";
            }
            //슬라이딩 메뉴 펼쳤을때
            else
            {
                panel2.Hide();
                panel3.Hide();
                panel4.Hide();
                panel1.Hide();

                button1.Text = "가상화";
                button1.BackgroundImage = null;
                button4.Text = "Dstation";
                button4.BackgroundImage = null;
                button2.Text = "Astation";
                button2.BackgroundImage = null;
                button3.Text = "CenterFace";
                button3.BackgroundImage = null;


                button5.Text = "클라우드";
                button5.BackgroundImage = null;
                button7.Text = "Dcanvas";
                button7.BackgroundImage = null;
                button6.Text = "elcloud";
                button6.BackgroundImage = null;


                button8.Text = "블록체인";
                button8.BackgroundImage = null;
                button10.Text = "Mstation";
                button10.BackgroundImage = null;
                button9.Text = "CenterChain";
                button9.BackgroundImage = null;


                button11.Text = "제로디바이스";
                button11.BackgroundImage = null;
                button13.Text = "Vstation";
                button13.BackgroundImage = null;
                button12.Text = "K-구름";
                button12.BackgroundImage = null;


                checkBoxHide.Text = "<";
            }
            // 타이머 실행
            timerSliding.Start();
        }

        private void timerSliding_Tick(object sender, EventArgs e)
        {
            if (checkBoxHide.Checked == true)
            {
                // 체크박스 체크되면 => 메뉴 접힘
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    timerSliding.Stop();
            }
            else
            {
                // 체크박스 체크x => 메뉴 열림
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    timerSliding.Stop();
            }
            panelSideMenu.Width = _posSliding;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel1.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            panel1.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel1.Show();
        }

        private void SolutionPage2_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel1.Hide();
        }
    }
}
