using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace TeamProjectFrontEnd
{
    public partial class ManagerPage : Form
    {
        // 슬라이딩 메뉴의 폭
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 50;
        // 슬라이딩 메뉴 펼쳐지는 / 접히는 속도
        const int STEP_SLIDING = 10;
        // 슬라이딩 메뉴 최소 크기
        int _posSliding = 200;

        public ManagerPage()
        {
            InitializeComponent();
        }
        Screen.ManagerScreen mScreen = new Screen.ManagerScreen();

        
        private void ManagerPage_Load(object sender, EventArgs e)
        {
            mainPanel.Controls.Add(mScreen);
        }

        private void checkBoxHide_CheckedChanged(object sender, EventArgs e)
        {
            // 슬라이딩 메뉴 접혔을때
            if (checkBoxHide.Checked == true)
            {
                button1.Text = "";

                checkBoxHide.Text = ">";
            }
            //슬라이딩 메뉴 펼쳤을때
            else
            {
                button1.Text = "관리자 페이지";
                button1.BackgroundImage = null;
   
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

        // 메뉴 클릭시 클릭된 메뉴 색상 변경
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSalmon;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            SolutionPage2 solPage = new SolutionPage2();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();
        }
    }

}
