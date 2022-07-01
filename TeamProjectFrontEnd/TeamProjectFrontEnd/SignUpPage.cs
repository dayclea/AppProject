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
    public partial class SignUpPage : Form
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        

        private void finishBtn_Click(object sender, EventArgs e)
        {
      
            try
            {
                // 이미 가입되어 있는 이름입니다
                // 이미 가입되어 있는 사원번호입니다 
                // 이미 가입되어 있는 이메일입니다 등 추가하면 좋을듯 -> 디비와 연결하여..
                // 이미 등록된 아이디입니다... (아이디 / 비번 기준)
                if (pwdTBox.Text != pwdCheckedTBox.Text)
                {
                    label9.Text = "비밀번호가 일치하지 않습니다.";
                }
                else
                {
                    MessageBox.Show("가입 신청이 완료 되었습니다");
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("아이디 / 사원번호 / 이메일 등 기타 중복");
            }
        }

    }
}
