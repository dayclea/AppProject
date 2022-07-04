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
            this.Hide();
            solPage.ShowDialog();
            this.Close();
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
            ManagerPage managerPage = new ManagerPage();
            this.Hide();
            managerPage.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolutionPage2 newpage = new SolutionPage2();
            this.Hide();
            newpage.ShowDialog();
            this.Close();


            /*SolutionPage2 solPage = new SolutionPage2();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();*/

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
       /* private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Cancel)
                e.Cancel = true;
        }*/
        private void btnExit_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
