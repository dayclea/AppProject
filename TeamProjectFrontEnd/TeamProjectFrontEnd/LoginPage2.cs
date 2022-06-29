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

        // 로그인 성공시 솔루션 페이지로 이동
        private void button1_Click(object sender, EventArgs e)
        {
            SolutionPage solPage = new SolutionPage();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();
        }

        // 회원가입 페이지 
        private void label4_Click(object sender, EventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Tag = this;
            signUpPage.Show();
        }

        // 관리자 페이지
        private void label5_Click(object sender, EventArgs e)
        {
            ManagerPage managerPage = new ManagerPage();
            managerPage.Tag = this;
            managerPage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolutionPage2 newpage = new SolutionPage2();
            newpage.Tag = this;
            newpage.Show();
            this.Hide();
        }
    }
}
