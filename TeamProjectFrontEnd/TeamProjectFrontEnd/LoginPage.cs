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
    public partial class LoginPage : Form
    {
        string dbconn = ConfigurationManager.ConnectionStrings["mariadb"].ConnectionString;

        public LoginPage()
        {
            InitializeComponent();

            // 틸론 로고 이미지 배경 투명화(png)
            pictureBox2.BackColor = Color.Transparent;
            // 부모 배경 설정
            pictureBox2.Parent = pictureBox1;

            MySqlConnection conn = new MySqlConnection(dbconn);
            conn.Open();
            MessageBox.Show("DB연결성공"); // 연결확인용
            conn.Close();
        }



        // 로그인 버튼 클릭시 -> 솔루션 페이지로 이동
        private void button1_Click_1(object sender, EventArgs e)
        {
            // 로그인이 성공한다면 -> 
            SolutionPage2 solPage = new SolutionPage2();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();
        }

        // 회원가입 버튼 클릭시 -> 회원가입 페이지 뜸
        private void label4_Click(object sender, EventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Tag = this;
            signUpPage.Show();
        }

        // 관리자 페이지 버튼 클릭시 -> 관리자 페이지로 이동
        private void label5_Click(object sender, EventArgs e)
        {
            ManagerPage managerPage = new ManagerPage();
            managerPage.Tag = this;
            managerPage.Show();
            this.Hide();
        }
    }
}
