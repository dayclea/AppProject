using System;
using System.Data;
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
                BtnAstation.Text = "";
                BtnCenterFace.Text = "";
                BtnDstation.Text = "";
                button5.Text = "";
                Btnelcloud.Text = "";
                BtnDcanvas.Text = "";
                button8.Text = "";
                BtnCenterChain.Text = "";
                BtnMstation.Text = "";
                button11.Text = "";
                BtnKCloud.Text = "";
                BtnVstation.Text = "";


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
                BtnDstation.Text = "Dstation";
                BtnDstation.BackgroundImage = null;
                BtnAstation.Text = "Astation";
                BtnAstation.BackgroundImage = null;
                BtnCenterFace.Text = "CenterFace";
                BtnCenterFace.BackgroundImage = null;


                button5.Text = "클라우드";
                button5.BackgroundImage = null;
                BtnDcanvas.Text = "Dcanvas";
                BtnDcanvas.BackgroundImage = null;
                Btnelcloud.Text = "elcloud";
                Btnelcloud.BackgroundImage = null;


                button8.Text = "블록체인";
                button8.BackgroundImage = null;
                BtnMstation.Text = "Mstation";
                BtnMstation.BackgroundImage = null;
                BtnCenterChain.Text = "CenterChain";
                BtnCenterChain.BackgroundImage = null;


                button11.Text = "제로디바이스";
                button11.BackgroundImage = null;
                BtnVstation.Text = "Vstation";
                BtnVstation.BackgroundImage = null;
                BtnKCloud.Text = "K-구름";
                BtnKCloud.BackgroundImage = null;


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


    

       

        // 종료 이벤트시 알림창
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void BtnDstation_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Dstation";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("VDI001");

            dataGridView1.DataSource = ds.Tables[0];

        }

        //목록 버튼 클릭 이벤트들 
        private void BtnAstation_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Astation";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("Astation");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnCenterFace_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "CenterFace";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("CenterFace");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnDcanvas_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Dcanvas";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("Dcanvas");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Btnelcloud_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "elcloud";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("elcloud");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnMstation_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Mstation";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("Mstation");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnCenterChain_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "CenterChain";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("CenterChain");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnVstation_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Vstation";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("Vstation");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnKCloud_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "K-구름";
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolution("K-구름");

            dataGridView1.DataSource = ds.Tables[0];
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;

        }

        // 추가버튼 클릭 이벤트
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            String solution_code = (dataGridView1.SelectedCells[0].Value).ToString();

            SolutionPage solPage = new SolutionPage(solution_code);
            solPage.Tag = this;
            solPage.ShowDialog();
        }

        // 수정버튼 클릭 이벤트
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count <= 1)
            {
                MessageBox.Show("수정할 데이터를 선택해주세요.", "Error");
                return;
            }
            else
            {
                String solution_code = (dataGridView1.SelectedCells[0].Value).ToString();
                String release_date = (dataGridView1.SelectedCells[2].Value).ToString();

                //수정할 데이터를 찾을거 들고 페이지 이동
                SolutionPage solPage = new SolutionPage(solution_code, release_date);
                solPage.Tag = this;
                solPage.ShowDialog();
            }

        
        }


        //삭제 버튼 클릭 이벤트
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count <= 1)
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요.", "Error");
                return;
            }
            else if (MessageBox.Show("삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            
            
            try
            {
                String solution_code = (dataGridView1.SelectedCells[0].Value).ToString();
                String release_date = (dataGridView1.SelectedCells[2].Value).ToString();

                Console.WriteLine(solution_code);
                Console.WriteLine(release_date);

                string sql = string.Format("DELETE FROM db_solutions.tbl_update WHERE 1=1 and (solution_code = '{0}' AND release_date = '{1}' );",
                                            solution_code, release_date);


                MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
                dbLib.DeleteDB(sql);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Error occurred");

            }

            // 삭제쿼리 실행 후 다시 데이터 불러오기
            MariaDbConn.MariaDbLib dbLib2 = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib2.GetSolution(groupBox1.Text);

            dataGridView1.DataSource = ds.Tables[0];
            
        }

        // 종료 버튼 클릭시
        private void button2_Click(object sender, EventArgs e)
        {
            /*SolutionPage2 newpage = new SolutionPage2();
            this.Hide();
            newpage.Show();
            this.Close();*/

            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();

        }
    }
}