﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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


        private void button15_Click(object sender, EventArgs e)
        {
            groupBox1.Name = "Dstation";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            //ds = dbLib.GetUser("VDI001");

            //dataGridView1.DataSource = ds.Tables[0];
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            //ds = dbLib.GetUser("VDI002");

            //dataGridView1.DataSource = ds.Tables[0];
        }

        // 클릭 이벤트
        private void btnData_Click(object sender, EventArgs e)
        {

            SolutionPage solPage = new SolutionPage();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();

            /*// 데이터가 없는 경우 return
            if (this.dataGridView1.RowCount == 0)
                return;

            // 현재 Row를 가져온다.
            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            // TextBox에 그리드 데이터를 넣는다.
            String[] Querystring = new string[5];
            Querystring[0] = row["solution_code"].ToString();
            Querystring[1] = row["release_date"].ToString();
            Querystring[2] = row["manager"].ToString();
            Querystring[3] = row["update_version"].ToString();
            Querystring[4] = row["description"].ToString();

            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            dbLib.InsertDB(Querystring);*/

          
        }

        private void TestBtn19_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            dbLib.ConnectionTest();
        }

        // 종료 이벤트시 알림창
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
    }
}