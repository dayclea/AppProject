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
    public partial class LoginPage2 : Form
    {
        public LoginPage2()
        {
            InitializeComponent();

            // 틸론 로고 이미지 배경 투명화(png)
            pictureBox2.BackColor = Color.Transparent;
            // 부모 배경 설정
            pictureBox2.Parent = pictureBox1;
        }


        // 일반회원 로그인
        private void button1_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("아이디를 입력해주세요.");
            }
            else if (!string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
            }
            else
            {
                bool loginResult = dbLib.SelectDB(textBox2.Text, textBox1.Text);
                if (loginResult)
                {
                    SolutionPage solPage = new SolutionPage();
                    this.Hide();
                    solPage.ShowDialog();
                    this.Close();
                }

            }
        }

        // 회원가입 페이지 
        private void label4_Click(object sender, EventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            this.Hide();
            signUpPage.ShowDialog();
            this.Close();
        }

        // 관리자 페이지
        private void label5_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            dbLib.ConnectionTest();
            Console.WriteLine("hello"); // 일단 여기까진 진입 완


            // 관리자 아이디일때(admin) -> 실행
            if (textBox2.Text == "admin" && !string.IsNullOrEmpty(textBox1.Text))
            {
                bool mLogin = dbLib.mLoginDB(textBox1.Text);

                if (mLogin)
                {
                    ManagerPage managerPage = new ManagerPage();
                    this.Hide();
                    managerPage.ShowDialog();
                    this.Close();
                }
            }
            // 관리자 아이디가 아닐때
            else if (textBox2.Text != "admin" && !string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("관리자 계정이 아닙니다.");
            }
            // 아이디를 입력하지 않았을때
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("아이디를 입력해주세요.");
            }
            // 아이디는 입력했으나, 비밀번호를 입력하지 않았을때 
            else if (!string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SolutionPage2 newpage = new SolutionPage2();
            this.Hide();
            newpage.ShowDialog();
            this.Close();*/


            SolutionPage2 solPage = new SolutionPage2();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();

            /////////////////////////

           /* this.Visible = false; // 현재 폼 안보이게 하기
            SolutionPage solPage = new SolutionPage(); // 새 폼 객체 생성
            solPage.Owner = this; // 새 폼의 오너를 현재 폼으로
            solPage.Show(); // 전환할 폼 보여 주 기 

            /////////////////////////

            SolutionPage solPage = new SolutionPage();
            this.Hide();
            solPage.ShowDialog();
            this.Close();*/

        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Cancel)
                e.Cancel = true;
        }
        private void btnExit_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
