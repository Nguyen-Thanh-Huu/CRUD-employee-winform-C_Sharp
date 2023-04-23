using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeWinform
{
    public partial class Form1 : Form
    {
        Employee employee = new Employee();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = employee.GetEmployees();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            employee.id = txtId.Text;
            employee.name = txtName.Text;
            employee.age = txtAge.Text;
            employee.contact = txtContact.Text;
            employee.gender = txtGender.Text;

            var insertEm = employee.InsertEmployee(employee);

            dataGridView1.DataSource = employee.GetEmployees();

            if (insertEm)
            {
                ClearForm();
                MessageBox.Show("Insert employee success !");
            }
            else
            {
                MessageBox.Show("Insert employee fails .. !");

            }
        }


        public void ClearForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtContact.Text = "";
            txtGender.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            employee.id = txtId.Text;
            employee.name = txtName.Text;
            employee.age = txtAge.Text;
            employee.contact = txtContact.Text;
            employee.gender = txtGender.Text;
            txtId.ReadOnly = false;

            var insertEm = employee.UpdateEmployee(employee);

            dataGridView1.DataSource = employee.GetEmployees();

            if (insertEm)
            {
                ClearForm();
                MessageBox.Show("Update employee success !");
            }
            else
            {
                MessageBox.Show("Update employee fails .. !");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng đã click vào dòng hay chưa
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString(); // Giả sử ô đầu tiên trong dòng chứa giá trị cần hiển thị
                txtName.Text = row.Cells[1].Value.ToString(); // Giả sử ô đầu tiên trong dòng chứa giá trị cần hiển thị
                txtAge.Text = row.Cells[2].Value.ToString(); // Giả sử ô đầu tiên trong dòng chứa giá trị cần hiển thị
                txtContact.Text = row.Cells[3].Value.ToString(); // Giả sử ô đầu tiên trong dòng chứa giá trị cần hiển thị
                txtGender.Text = row.Cells[4].Value.ToString(); // Giả sử ô đầu tiên trong dòng chứa giá trị cần hiển thị

                txtId.ReadOnly = true;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employee.id = txtId.Text;
            // Call DeleteEmployee method to delete the selected employee from database
            var success = employee.DeleteEmployee(employee);
            // Refresh the grid to show the updated employee details
            dataGridView1.DataSource = employee.GetEmployees();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                ClearForm();
                MessageBox.Show("Delete employee success !!");
            }
            else
                MessageBox.Show("Fails! Please try again...");
        }
    }
}
