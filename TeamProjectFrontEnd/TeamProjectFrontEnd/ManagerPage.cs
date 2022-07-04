using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MariaDbConn;


using MySql.Data.MySqlClient;
using System.Data;


namespace TeamProjectFrontEnd
{
    public partial class ManagerPage : Form
    {
        // 슬라이딩 메뉴의 폭
        //const int MAX_SLIDING_WIDTH = 200;
        //const int MIN_SLIDING_WIDTH = 50;
        // 슬라이딩 메뉴 펼쳐지는 / 접히는 속도
        //const int STEP_SLIDING = 10;
        // 슬라이딩 메뉴 최소 크기
        //int _posSliding = 200;
        string empcodeSelect = "";


        public ManagerPage()
        {
            InitializeComponent();

            refreshList();

        }

        private void checkBoxHide_CheckedChanged(object sender, EventArgs e)
        { }

        private void timerSliding_Tick(object sender, EventArgs e)
        { }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        { }


        //메인화면으로 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            //SolutionPage solPage = new SolutionPage();
            //this.Hide();
            //solPage.ShowDialog();
            //this.Close();
        }


        //새로고침
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("abc");
            Console.WriteLine("1");

            refreshList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        { }


        //승인버튼
        private void button4_Click(object sender, EventArgs e)
        {
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "52.79.165.81", "db_emp", "teammate2", "teammate2");
            using (MySqlConnection conn = new MySqlConnection(connectString))

                try
                {
                    conn.Open();
                    //다중 승인 구현
                    DialogResult drb = MessageBox.Show("선택한 계정을 승인 하시겠습니까?", "확인메세지", MessageBoxButtons.OKCancel);
                    if (drb == DialogResult.OK)
                    {

                        if (listView1.SelectedItems.Count > 1)
                        {
                            empcodeSelect = listView1.SelectedItems[0].Text;
                            for (int i = 1; i < listView1.SelectedItems.Count - 1; i++)
                            {
                                empcodeSelect = empcodeSelect + "\",\"" + listView1.SelectedItems[i].Text;
                            }
                            empcodeSelect = empcodeSelect + "\",\"" + listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text;

                            Console.WriteLine(empcodeSelect);

                            MySqlCommand msc = new MySqlCommand("UPDATE tbl_account SET login_status = 1 WHERE 1=1 AND empcode IN  (\"" + empcodeSelect + "\");", conn);
                            empcodeSelect = "";
                            msc.CommandType = CommandType.Text;
                            MySqlDataReader r = msc.ExecuteReader();
                            r.Close();
                            msc.ExecuteNonQuery();
                            MessageBox.Show("승인완료");

                        }
                        //단일 선택일 경우
                        else if (listView1.SelectedItems.Count == 1)
                        {
                            //SelectedItems[0].SubItems[4] == login_status
                            Console.WriteLine(listView1.SelectedItems.Count);
                            Console.WriteLine(listView1.SelectedItems[0].SubItems[4].Text);
                            if (Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text) == 0)
                            {
                                empcodeSelect = listView1.SelectedItems[0].Text;
                                MySqlCommand msc = new MySqlCommand("UPDATE tbl_account SET login_status = 1 WHERE 1=1 AND empcode IN  (\"" + empcodeSelect + "\");", conn);
                                empcodeSelect = "";
                                msc.CommandType = CommandType.Text;
                                MySqlDataReader r = msc.ExecuteReader();
                                r.Close();
                                msc.ExecuteNonQuery();
                                MessageBox.Show("승인완료");
                            }
                            else
                            {
                                MessageBox.Show("이미 승인된 계정입니다.");
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            refreshList();
        }

        //삭제버튼
        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                DialogResult dr = MessageBox.Show("선택한 계정을 삭제 하시겠습니까?", "확인메세지", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "52.79.165.81", "db_emp", "teammate2", "teammate2");
                    using (MySqlConnection conn = new MySqlConnection(connectString))

                        try
                        {
                            conn.Open();
                            //singular choice
                            if (listView1.SelectedItems.Count == 1)
                            {
                                MySqlCommand msc = new MySqlCommand("DELETE FROM tbl_account WHERE 1=1 AND empcode=\"" + listView1.SelectedItems[0].Text + "\";", conn);
                                msc.CommandType = CommandType.Text;
                                MySqlDataReader r = msc.ExecuteReader();
                                r.Close();
                                msc.ExecuteNonQuery();
                                MessageBox.Show("삭제완료");
                            }
                            //plural choice
                            else if (listView1.SelectedItems.Count > 1)
                            {
                                Console.WriteLine(listView1.SelectedItems.Count);
                                List<string> empcodeSelectList = new List<string>();
                                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                                {
                                    empcodeSelectList.Add(listView1.SelectedItems[i].Text);

                                }
                                empcodeSelect = empcodeSelectList[0];
                                for (int i = 1; i < listView1.SelectedItems.Count; i++)
                                {
                                    empcodeSelect = empcodeSelect + "\",\"" + empcodeSelectList[i];

                                }
                                Console.WriteLine(empcodeSelect);//ok

                                MySqlCommand msc = new MySqlCommand("DELETE FROM tbl_account WHERE 1=1 AND empcode IN (\"" + empcodeSelect + "\");", conn);
                                msc.CommandType = CommandType.Text;
                                MySqlDataReader r = msc.ExecuteReader();
                                r.Close();
                                msc.ExecuteNonQuery();
                                MessageBox.Show("삭제완료");

                            }

                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                }
            }
            else
            {
                //MessageBox.Show("선택해주세요");

            }
            refreshList();
        }


        private void refreshList()
        {
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "52.79.165.81",
                                       "db_emp", "teammate2", "teammate2");
            using (MySqlConnection conn = new MySqlConnection(connectString))
                try
                {
                    conn.Open();
                    //
                    MySqlCommand msc = new MySqlCommand("SELECT * FROM tbl_account", conn);
                    msc.CommandType = CommandType.Text;
                    MySqlDataReader r = msc.ExecuteReader();


                    listView1.Items.Clear();
                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            ListViewItem lvi = new ListViewItem(new string[]
                            {
                            r["empcode"].ToString(),
                            r["name"].ToString(),
                            r["account_id"].ToString(),
                            r["account_psw"].ToString(),
                            r["login_status"].ToString()
                            });

                            listView1.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        MessageBox.Show("no data to show");
                    }
                    r.Close();
                    msc.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

        }



        //프로그램 종료
        private void button6_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
            //    e.Cancel = true;

            DialogResult dialogResult = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {

            }

        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        { }


    }
}
