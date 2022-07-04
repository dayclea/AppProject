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
        public SolutionPage(String solution_code/*, int insertOrEdit_Key*/)
        {
            InitializeComponent();
            colset(dataGridView1, solution_code);

            this.dataGridView1.MouseHover += dataGridView1_MouseHover;
        }

        //edit버튼에서 실행될시
        public SolutionPage(String solution_code, String release_date/*, int insertOrEdit_Key*/)
        {
            InitializeComponent();
            colset2(dataGridView1, solution_code, release_date);
        }

        private void checkBoxHide_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();

            String solution_code = (dataGridView1.SelectedCells[0].Value).ToString();
            String release_date = (dataGridView1.SelectedCells[1].Value).ToString();
            String manager = (dataGridView1.SelectedCells[2].Value).ToString();
            String update_version = (dataGridView1.SelectedCells[3].Value).ToString();
            String description = (dataGridView1.SelectedCells[4].Value).ToString();

            /*if (SeOrEd_Key.Tag) {*/
            string sql = string.Format("Update db_solutions.tbl_update Set () where solution_code = {0} and release_date = {1};",
                                        solution_code, release_date, manager, update_version, description);
            /* }*/


        }
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
            subTitleColumn.HeaderText = "솔루션명";
            subTitleColumn.Name = "솔루션명";
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

            // 수정할 수 있도록 컬럼 추가
            string[] row0 = { solution_code, SolutionCodeCheck(solution_code), "", "", "", "" };
            dataGridView1.Rows.Add(row0);

            // 솔루션명 부분 일단 잠금... 번호 바꿀때마다 솔루션명 변경하는 이벤트 만들어야할듯?
            dataGridView1.Columns["솔루션명"].ReadOnly = true;

        }
        public void colset2(DataGridView dataGridView1, String solution_code, String release_date)
        {
            // 화면의 컬럼 출력
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            DataSet ds;
            ds = dbLib.GetSolutionSelectedToEdit(solution_code, release_date);

            dataGridView1.DataSource = ds.Tables[0];


        }
        // ToolTip 표시
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if ((e.ColumnIndex == this.dataGridView1.Columns["솔루션명"].Index)
                && e.Value != null)
            {
                DataGridViewCell cell =
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            cell.ToolTipText = "Dstation";

            }*/
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            dbLib.ConnectionTest();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            /*SolutionPage2 solPage = new SolutionPage2();
            solPage.Tag = this;
            solPage.Show();*/
            this.Hide();
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttip = new ToolTip();

            ttip.SetToolTip(this.dataGridView1, "Main 버튼 입니다.");
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
    }
}
