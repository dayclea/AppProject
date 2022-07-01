using System;
using System.Windows.Forms;


namespace TeamProjectFrontEnd
{
    public partial class SolutionPage : Form
    {
       
        public SolutionPage(int editOrInsert)
        {
            InitializeComponent();
            colset(dataGridView1);
        }

        private void checkBoxHide_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }
        public void colset(DataGridView dataGridView1)
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
            string[] row0 = { "0", "솔루션명","2020-09-08","김김김","v.0.0.0","" };
            dataGridView1.Rows.Add(row0);

            // 솔루션명 부분 일단 잠금... 번호 바꿀때마다 솔루션명 변경하는 이벤트 만들어야할듯?
            dataGridView1.Columns["솔루션명"].ReadOnly = true;

        }

        // ToolTip 표시
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.dataGridView1.Columns["솔루션명"].Index)
                && e.Value != null)
            {
                DataGridViewCell cell =
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            cell.ToolTipText = "Dstation";

            }
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MariaDbConn.MariaDbLib dbLib = new MariaDbConn.MariaDbLib();
            dbLib.ConnectionTest();
        }
    }
}
