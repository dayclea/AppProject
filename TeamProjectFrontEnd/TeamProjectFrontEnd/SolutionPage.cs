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
    public partial class SolutionPage : Form
    {

        // 슬라이딩 메뉴의 폭
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 50;
        // 슬라이딩 메뉴 펼쳐지는 / 접히는 속도
        const int STEP_SLIDING = 10;
        // 슬라이딩 메뉴 최소 크기
        int _posSliding = 200;

        public SolutionPage()
        {
            InitializeComponent();
        }

        // 슬라이딩 메뉴
        private void checkBoxHide_CheckedChanged(object sender, EventArgs e)
        {
            // 슬라이딩 메뉴 접혔을때
            if (checkBoxHide.Checked == true)
            {
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";

                checkBoxHide.Text = ">";
            }
            //슬라이딩 메뉴 펼쳤을때
            else
            {
                button1.Text = "Dstation";
                button1.BackgroundImage = null;
                button2.Text = "Astation";
                button2.BackgroundImage = null;
                button3.Text = "CenterFace";
                button3.BackgroundImage = null;
                button4.Text = "Dcanvas";
                button4.BackgroundImage = null;
                button5.Text = "elcloud";
                button5.BackgroundImage = null;
                button6.Text = "Mstation";
                button6.BackgroundImage = null;
                button7.Text = "CenterChain";
                button7.BackgroundImage = null;
                button8.Text = "Vstation";
                button8.BackgroundImage = null;
                button9.Text = "K-구름";
                button9.BackgroundImage = null;

                checkBoxHide.Text = "<";
            }
            // 타이머 실행
            timerSliding.Start();
        }

        // 슬라이딩 메뉴 타이머
        private void timerSliding_Tick(object sender, EventArgs e)
        {
            if(checkBoxHide.Checked == true)
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

        // form이 로드될때 판넬 미리 선언한다.
        #region
        Screen.SolutionScreen solScren1 = new Screen.SolutionScreen();
        Screen.tmp tmp = new Screen.tmp();
        #endregion

        // 솔루션 페이지 로드되면 -> 가장 기본으로 깔려있을 cs파일 지정
        private void SolutionPage_Load(object sender, EventArgs e)
        {
            mainPanel.Controls.Add(tmp);
        }

        // 버튼 클릭시 가져올 cs파일..
        private void button1_Click(object sender, EventArgs e)
        {
            // 먼저 판넬을 꼭..! 비워주고 가져와야 함
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(solScren1);
        }


    }
}
