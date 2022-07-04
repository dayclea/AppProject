using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace TeamProjectFrontEnd
{
    public partial class SignUpPage : Form
    {
        string server = "52.79.165.81"; //서버IP
        string database = "db_emp";     //데이터베이스명
        string table = "tbl_account";   //테이블명
        string uid = "teammate2";       //DB 접속계정
        string pwd = "teammate2";       //DB 접속PWD
        bool idCheck = false;           //계정 생성 입력 ID 정합성 체크 
        bool pwdCheck = false;          
        bool pwdRecheck = false;        //계정 생성 입력 PW 정합성 체크

        public SignUpPage()
        {
            InitializeComponent();
        }
        
        // ID 중복 체크
        private void idCheckBtn_Click(object sender, EventArgs e)
        {
            string inputId = idTBox.Text.ToString();
            
            //계정리스트 조회 (입력한 ID 기준)
            try
            {
                DataSet dsAccountId = new DataSet();
                string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", server, database, uid, pwd);
                
                using (MySqlConnection conn = new MySqlConnection(connectString))
                {
                    string query = string.Format("select account_id from {0} where account_id = '{1}.@tilon.com';", table, inputId);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dsAccountId, table);
                }
                if (Regex.IsMatch(inputId, @"[ㄱ-ㅎ가-힣]") == true)
                {
                    idLb.ForeColor = Color.Red;
                    idLb.Text = "한글 사용 불가능합니다. \n영문과 숫자만 사용해주시기 바랍니다.";
                    idCheck = false;
                }
                else if (Regex.IsMatch(inputId, @"[~!@#$%^&*()_\-=+[\]{};:<>,.\""\']") == true)
                {
                    idLb.ForeColor = Color.Red;
                    idLb.Text = "특수문자 사용 불가능합니다. \n영문과 숫자만 사용해주시기 바랍니다.";
                    idCheck = false;
                }
                else if (dsAccountId.Tables[0].Rows.Count == 0 && (inputId.Length >= 6 && inputId.Length <= 15))
                {
                    if (Regex.IsMatch(inputId, @"[ㄱ-ㅎ가-힣]") == false || Regex.IsMatch(inputId, @"[~!@#$%^&*()_\-=+[\]{};:<>,.\""\']") == false)   // 한글 입력 불가하도록 설정 
                    {
                        idLb.ForeColor = Color.Green;
                        idLb.Text = "사용 가능합니다.";
                        idCheck = true;
                    }
                }
                else
                {
                    idLb.ForeColor = Color.Red;
                    idLb.Text = "사용 불가능합니다.";
                    idCheck = false;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
        
        //PWD 구성 체크 (영문 + 숫자 조합)
        private void pwdTBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string inputId = idTBox.Text.ToString();
                string inputPwd = pwdTBox.Text.ToString();                
                if (inputPwd.Length == 0)
                {
                    pwdLb.ForeColor = SystemColors.ControlDarkDark;
                    pwdLb.Text = "8~20자 이내의 영문 + 숫자 조합";
                    pwdCheck = false;
                }
                else if (Regex.IsMatch(inputPwd, @"[a-zA-Z]") == false)
                {
                    pwdLb.ForeColor = Color.Red;
                    pwdLb.Text = "영문을 포함해야 합니다.";
                    pwdCheck = false;
                }
                else if (Regex.IsMatch(inputPwd, @"[0-9]") == false)
                {
                    pwdLb.ForeColor = Color.Red;
                    pwdLb.Text = "숫자를 포함해야 합니다.";
                    pwdCheck = false;
                }
                else if (inputPwd == inputId)
                {
                    pwdLb.ForeColor = Color.Red;
                    pwdLb.Text = "아이디와 비밀번호는 같을 수 없습니다.";
                    pwdCheck = false;
                }
                else if (Regex.IsMatch(inputPwd, @"[ㄱ-ㅎ가-힣]") == true)
                {
                    idLb.ForeColor = Color.Red;
                    idLb.Text = "한글 사용 불가능합니다. \n영문과 숫자만 사용해주시기 바랍니다.";
                    idCheck = false;
                }
                else if (Regex.IsMatch(inputPwd, @"[~!@#$%^&*()_\-=+[\]{};:<>,.\""\']") == true)
                {
                    idLb.ForeColor = Color.Red;
                    idLb.Text = "특수문자 사용 불가능합니다. \n영문과 숫자만 사용해주시기 바랍니다.";
                    idCheck = false;
                }
                else if ((inputPwd != inputId) && (inputPwd.Length >= 8) && (inputPwd.Length <= 20))
                {
                    if (Regex.IsMatch(inputPwd, @"[a-zA-Z]") == true)
                    {
                        if (Regex.IsMatch(inputPwd, @"[0-9]") == true)
                        {
                            pwdLb.ForeColor = Color.Green;
                            pwdLb.Text = "사용 가능합니다.";
                            pwdCheck = true;
                        }
                    }
                }
                else
                {
                    pwdLb.ForeColor = Color.Red;
                    pwdLb.Text = "사용 불가능합니다.";
                    pwdCheck = false;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine (exc);
            }
        }
        
        //PWD 재입력 확인
        private void pwdCheckedTBox_TextChanged(object sender, EventArgs e)
        {
            if (pwdTBox.Text == pwdCheckTBox.Text)
            {
                pwdCheckLb.ForeColor = Color.Green;
                pwdCheckLb.Text = "비밀번호가 일치합니다.";
                pwdRecheck = true;
                
            }
            else
            {
                pwdCheckLb.ForeColor = Color.Red;
                pwdCheckLb.Text = "비밀번호가 일치하지 않습니다.";
                pwdRecheck = false;
            }
        }

        // 입력 완료 후 계정 생성 시도
        private void finishBtn_Click(object sender, EventArgs e)
        {
            string inputEmpCode = empNoTBox.Text.ToString();    //입력한 사원번호
            string inputName = nameTBox.Text.ToString();        //입력한 이름
            string inputId = idTBox.Text.ToString();            //입력한 ID
            string inputPwd = pwdTBox.Text.ToString();          //입력한 PWD
            string inputRePwd = pwdCheckTBox.Text.ToString();   //입력한 rePWD
            string status = "0";                                //승인여부(미승인: 0  승인:1) 계정 신청시 0으로 고정
            try
            {
                DataSet dsEmpCode = new DataSet();
                string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", server, database, uid, pwd);

                using (MySqlConnection conn = new MySqlConnection(connectString))
                {
                    string query = string.Format("select empcode from {0} where empcode = '{1}';", table, inputEmpCode);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dsEmpCode, table);
                }
                if (inputEmpCode == "" || inputEmpCode == null)
                {
                    MessageBox.Show("사원번호가 입력되지 않았습니다.");
                }
                else if (inputName == "" || inputName == null)
                {
                    MessageBox.Show("이름이 입력되지 않았습니다.");
                }
                else if (inputId == "" || inputId == null)
                {
                    MessageBox.Show("아이디가 입력되지 않았습니다.");
                }
                else if (inputPwd == "" || inputPwd == null || inputRePwd == "" || inputRePwd == null)
                {
                    MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                }
                else if (idCheck == false)
                {
                    MessageBox.Show("아이디 중복체크를 주시기 바랍니다.");
                }
                else if (pwdCheck == false || pwdRecheck == false)
                {
                    MessageBox.Show("비밀번호가 적합한지 확인해주시기 바랍니다.");
                }
                else if (dsEmpCode.Tables[0].Rows.Count > 0)    //사원번호 중복이 있을 경우, 관리자 권한 필요
                {
                    MessageBox.Show("중복된 사원번호가 존재합니다. 관리자에게 문의하시기 바랍니다.");
                }
                else if (dsEmpCode.Tables[0].Rows.Count == 0)    //입력 완료 후 생성 신청시, 사원번호 중복체크
                {
                    if (idCheck == true && pwdCheck == true && pwdRecheck == true)  //정합성 체크가 모두 true일때만 신청 가능
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectString))
                        {
                            string insertQuery = string.Format("insert into {0} values ('{1}', '{2}', '{3}@tilon.com', '{4}', {5});",
                                                                table, inputEmpCode, inputName, inputId, inputPwd, status);
                            try
                            {
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("계정 생성 신청이 정상적으로 되었습니다.");
                                    //정상적인 신청 완료 후, 로그인 화면으로 재이동
                                    //if ()
                                    LoginPage2 loginPage2 = new LoginPage2();
                                    loginPage2.Tag = this;
                                    loginPage2.Show();
                                    this.Hide();
                                }
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine(exc);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("입력하신 사항을 다시 한번 확인해주시기 바랍니다.");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            
        }
    }
}
