using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Bookstore
{
    public partial class autoriForm : Form
    {
        public autoriForm()
        {
            InitializeComponent();
        }

        DataTable dataTable = new DataTable();
        DataTable copyDataTable = new DataTable();

        private void autoriForm_Load(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            string query = "SELECT numeAutor, dataAutor, genAutor FROM Autori";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }

        public void exportExcel(string pathFile)
        {
            // Copy dataTable
            copyDataTable = dataTable.Copy();

            // Add header to new row
            DataRow row = copyDataTable.NewRow();
            DataColumnCollection columns1 = copyDataTable.Columns;
            for (int i = 0; i < columns1.Count; i++)
            {
                row[i] = columns1[i].ColumnName;
            }

            // Add new row to first position
            copyDataTable.Rows.InsertAt(row, 0);

            // DataTable to Excel
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];
            Excel.Range excelCellrange;

            var columns = copyDataTable.Columns.Count;
            var rows = copyDataTable.Rows.Count;

            Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];

            object[,] data = new object[rows, columns];

            for (int rowNumber = 0; rowNumber < rows; rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                {
                    data[rowNumber, columnNumber] = copyDataTable.Rows[rowNumber][columnNumber].ToString();
                }
            }

            range.Value = data;

            // Style first row to bold
            worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

            // Resize the columns  
            excelCellrange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[copyDataTable.Rows.Count, copyDataTable.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();
            Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            workbook.SaveAs(@pathFile);
            workbook.Close();

            Marshal.ReleaseComObject(application);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Salveaza fisierul XML in locul specificat de utilizator
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string myPath = saveFileDialog.FileName;
                string extension = Path.GetExtension(myPath);
                switch (extension)
                {
                    case ".txt":
                        //do something here 
                        break;
                    case ".xlsx":
                        exportExcel(myPath);
                        break;
                }
                MessageBox.Show("Fișierul a fost salvat cu succes!", "Salvare reușită", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
