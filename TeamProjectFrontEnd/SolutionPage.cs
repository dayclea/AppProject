using System;
using System.Data;
using System.Windows.Forms;


namespace TeamProjectFrontEnd
{
    public partial class SolutionPage : Form
    {

        /*public SolutionPage()
        {
            InitializeComponent();
            colset(dataGridView1);
        }*/

        // insert버튼 실행 시
        public SolutionPage(String solution_code)
        {
            InitializeComponent();
            colset(dataGridView1, solution_code);
        }

        //edit버튼에서 실행될시
        public SolutionPage(String solution_code, String release_date)
        {
            InitializeComponent();
            colset2(dataGridView1, solution_code, release_date);
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {

            dataGridView1.SelectAll();

            if (dataGridView1.SelectedCells[0].Value == null || dataGridView1.SelectedCells[2].Value == null || dataGridView1.SelectedCells[3].Value == null || dataGridView1.SelectedCells[4].Value == null)
            {
                MessageBox.Show("값을 입력해 주세요.", "Error");
                return;
            }

            // String solution_code = (dataGridView1.SelectedCells[0].Value).ToString();
            // String release_date = (dataGridView1.SelectedCells[2].Value).ToString();
            // String manager = (dataGridView1.SelectedCells[3].Value).ToString();
            // String update_version = (dataGridView1.SelectedCells[4].Value).ToString();
            // String description = (dataGridView1.SelectedCells[5].Value).ToString();
            // String[] Querystring = { solution_code, release_date, manager, update_version };

            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();

            if (BtnEdit.Text.Equals("추가"))
            {
                string sql = String.Format("Insert Into db_solutions.tbl_update (solution_code,release_date,manager,update_version,description) values ('{0}','{1}','{2}','{3}','{4}');"
                                            , dataGridView1.SelectedCells[0].Value, dataGridView1.SelectedCells[2].Value, dataGridView1.SelectedCells[3].Value, dataGridView1.SelectedCells[4].Value, dataGridView1.SelectedCells[5].Value);

                dbLib.InsertDB(sql);
            }
            else if (BtnEdit.Text.Equals("수정"))
            {
                string sql = string.Format("update db_solutions.tbl_update Set manager = '{0}', update_version = '{1}', description = '{2}' where solution_code = '{3}' and release_date = '{4}';",
                                        dataGridView1.SelectedCells[3].Value, dataGridView1.SelectedCells[4].Value, dataGridView1.SelectedCells[5].Value, dataGridView1.SelectedCells[0].Value, dataGridView1.SelectedCells[2].Value);
                Console.WriteLine(sql);
                dbLib.UpdateDB(sql);

            };

            SolutionPage2 solPage = new SolutionPage2(button1.Text);

            this.Hide();
            solPage.ShowDialog();
            this.Close();

        }


        // 수정 화면 
        public void colset2(DataGridView dataGridView1, String solution_code, String release_date)
        {
            // 화면의 컬럼 출력
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolutionSelectedToEdit(solution_code, release_date);

            dataGridView1.DataSource = ds.Tables[0];

            BtnEdit.Text = "수정";

            dataGridView1.Columns["솔루션 번호"].ReadOnly = true;
            dataGridView1.Columns["솔루션 명"].ReadOnly = true;
            dataGridView1.Columns["수정/배포일자"].ReadOnly = true;

            String solName = SolutionCodeCheck(solution_code);
            button1.Text = solName;

            dataGridView1.Rows[0].Cells[0].ToolTipText = "이 셀은 변경할수 없습니다.";
            dataGridView1.Rows[0].Cells[1].ToolTipText = "이 셀은 변경할수 없습니다.";
            dataGridView1.Rows[0].Cells[2].ToolTipText = "이 셀은 변경할수 없습니다.";

        }

        // 추가 화면
        public void colset(DataGridView dataGridView1, String solution_code)
        {
            // 화면의 컬럼 출력
            DataGridViewTextBoxColumn titleColumn =
                new DataGridViewTextBoxColumn();
            titleColumn.HeaderText = "솔루션 번호";
            titleColumn.Name = "솔루션 번호";
            titleColumn.Width = 120;
            titleColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            titleColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn subTitleColumn =
                new DataGridViewTextBoxColumn();
            subTitleColumn.HeaderText = "솔루션 명";
            subTitleColumn.Name = "솔루션 명";
            subTitleColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewTextBoxColumn summaryColumn =
                new DataGridViewTextBoxColumn();
            summaryColumn.HeaderText = "수정/배포일자";
            summaryColumn.Name = "수정/배포일자";
            summaryColumn.Width = 120;
            summaryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            summaryColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            summaryColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn contentColumn =
                new DataGridViewTextBoxColumn();
            contentColumn.HeaderText = "담당자";
            contentColumn.Name = "담당자";
            contentColumn.Width = 80;
            contentColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            contentColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            contentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn amountColumn =
                new DataGridViewTextBoxColumn();
            amountColumn.HeaderText = "version";
            amountColumn.Name = "version";
            amountColumn.Width = 60;
            amountColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            amountColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            amountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn descColumn =
                new DataGridViewTextBoxColumn();
            descColumn.HeaderText = "업데이트개요";
            descColumn.Name = "업데이트개요";
            descColumn.Width = 120;
            descColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            descColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            descColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn[] {
            titleColumn, subTitleColumn,
            summaryColumn, contentColumn, amountColumn, descColumn });

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            String solName = SolutionCodeCheck(solution_code);

            // 수정할 수 있도록 컬럼 추가
            string[] row0 = { solution_code, solName };
            dataGridView1.Rows.Add(row0);

            // 솔루션명 부분 일단 잠금... 번호 바꿀때마다 솔루션명 변경하는 이벤트 만들어야할듯?
            dataGridView1.Columns["솔루션 명"].ReadOnly = true;
            dataGridView1.Columns["솔루션 번호"].ReadOnly = true;

            BtnEdit.Text = "추가";
            button1.Text = solName;


            dataGridView1.Rows[0].Cells[0].ToolTipText = "이 셀은 변경할수 없습니다.";
            dataGridView1.Rows[0].Cells[1].ToolTipText = "이 셀은 변경할수 없습니다.";

        }




        private void button2_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            dbLib.ConnectionTest();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SolutionPage2 solPage = new SolutionPage2(SolutionName.Text);
            this.Hide();
            solPage.ShowDialog();
            this.Close();
        }


        // 솔루션 코드 체크
        private String SolutionCodeCheck(String solution_code)
        {
            String SolName;

            if (solution_code.Equals("VDI001"))
            {
                SolName = "Dstation";
            }
            else if (solution_code.Equals("VDI002"))
            {
                SolName = "Astation";
            }
            else if (solution_code.Equals("VDI003"))
            {
                SolName = "CenterFace";
            }
            else if (solution_code.Equals("VDI011"))
            {
                SolName = "Dcanvas";
            }
            else if (solution_code.Equals("VDI012"))
            {
                SolName = "elcloud";
            }
            else if (solution_code.Equals("VDI021"))
            {
                SolName = "Mstation";
            }
            else if (solution_code.Equals("VDI022"))
            {
                SolName = "CenterChain";
            }
            else if (solution_code.Equals("VDI031"))
            {
                SolName = "Vstation";
            }
            else if (solution_code.Equals("VDI032"))
            {
                SolName = "K-구름";
            }
            else
            {
                return "ERROR";
            }
            return SolName;
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Cells[0].ToolTipText = "이 셀은 변경할수 없습니다.";
            dataGridView1.Rows[0].Cells[1].ToolTipText = "이 셀은 변경할수 없습니다.";
            if (BtnEdit.Text.Equals("수정"))
            {
                dataGridView1.Rows[0].Cells[2].ToolTipText = "이 셀은 변경할수 없습니다.";
            }


        }
    }
}
