using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace MariaDbConn
{
    public class MariaDbLib
    {

        // 접속테스트
        public bool ConnectionTest()
        {
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1",
                                                 "tilon_project", "root", "kopo");
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
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1",
                                                 "tilon_project", "root", "kopo");
            string sql = "select * from tbl_update";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
            }
        }

        //INSERT처리
        public void InsertDB(String[] Querystring)
        {
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1",
                                                 "tilon_project", "root", "kopo");
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
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1",
                                                 "tilon_project", "root", "kopo");
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
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1",
                                                 "tilon_project", "root", "kopo");
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
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1",
                                                 "tilon_project", "root", "kopo");
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