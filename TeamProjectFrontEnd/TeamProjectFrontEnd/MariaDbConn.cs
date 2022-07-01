using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

using System.Windows.Forms;

namespace MariaDbConn
{
    public class MariaDbLib
    {
        string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "52.79.165.81",
                                                 "db_emp", "teammate2", "teammate2");

        // 접속테스트
        public bool ConnectionTest()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectString))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //데이터조회
        public void SelectDB()
        {

            string sql = "select * from tbl_update";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
            }
        }

        // 로그인 
        public bool SelectDB(string userId, string userPw)
        {
            // 아이디가 존재한다면 -> 그 행을 다 받아와서 비번 일치 여부와 승인여부 체크
            string sql = "SELECT account_id, account_psw, login_status FROM tbl_account WHERE account_id = '" + userId + "';";
            string _id = "";
            string _pw = "";
            string _loginStatus = "";


            using (MySqlConnection conn = new MySqlConnection(connectString))
            {

                try
                {
                    conn.Open();
                    Console.WriteLine("연결 되었습니다");
                    MySqlCommand cmdId = new MySqlCommand(sql, conn);
                    MySqlDataReader dr = cmdId.ExecuteReader();


                    while (dr.Read() == true)
                    {
                        _id = dr[0].ToString();
                        _pw = dr[1].ToString();
                        _loginStatus = dr[2].ToString();
                        Console.WriteLine(_id);
                        Console.WriteLine(_pw);
                        Console.WriteLine(_loginStatus);
                    }

                    // 존재하지 않는 아이디라면 -> 이러면 위에서 걍 다 null null null로 받아오는건가?
                    if (string.IsNullOrEmpty(_id))
                    {
                        MessageBox.Show("아이디 또는 패스워드를 확인해주세요.");
                        return false;
                    }
                    // 존재하는 아이디이지만, 비번이 불일치라면,
                    else if (!string.IsNullOrEmpty(_id) && _pw != userPw)
                    {
                        MessageBox.Show("아이디 또는 패스워드를 확인해주세요.");
                        return false;
                    }
                    // 디비에 존재하나 아직 미승인인 아이디 미승인 : 0 승인 : 1
                    else if (!string.IsNullOrEmpty(_id) && _loginStatus == "0")
                    {
                        MessageBox.Show("승인되지 않은 아이디입니다.\n관리자에게 문의해주세요.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    //dr.Close();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        // 관리자 로그인
        public bool mLoginDB(string mPw)
        {
            // 관리자 아이디일때만 접근 가능하므로 걍 쿼리에 아이디 박아둠
            string sql = "select account_id, account_psw from tbl_account where account_id = 'admin'";
            string _pw = "";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        _pw = dr["account_psw"].ToString();
                        //dr.Close();
                    }
                    if (_pw != mPw)
                    {
                        MessageBox.Show("비밀번호가 일치하지 않습니다.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    conn.Close();
                }


            }
        }




        //INSERT처리
        public void InsertDB(String[] Querystring)
        {
            string sql = String.Format("Insert Into tilon_project.tbl_update (solution_code,release_date,manager,update_version,description) values ('{0}','{1}','{2}','{3}','{4}');"
                , Querystring[0], Querystring[1], Querystring[2], Querystring[3], Querystring[4]);
            /*string sql = "Insert Into tbl_update (solution_code,release_date,manager,update_version,description) values ("+Querystring[0]+","+Querystring[1]+","+Querystring[2]+","+Querystring[3]+","+Querystring[4]+");";*/

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("인서트 성공");
                    }
                    else
                    {
                        Console.WriteLine("인서트 실패");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }

        //UPDATE처리
        public void UpdateDB()
        {

            string sql = "Update tbl_update Set name ='홍길동2' where id = 1";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Console.WriteLine(cmd.ExecuteNonQuery());
            }
        }

        //DELETE처리
        public void DeleteDB()
        {

            string sql = "Delete From tbl_update where id = '1'";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //데이터조회
        public DataSet GetUser(int solution_code)
        {

            string sql = "select * from tbl_update where 1=1 and solution_code = " + solution_code;
            DataSet ds = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
            }
            return ds;
        }
    }
}