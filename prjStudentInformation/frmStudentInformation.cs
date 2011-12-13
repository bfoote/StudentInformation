using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentInformation.OB;

namespace prjStudentInformation
{
    public partial class frmStudentInformation : Form
    {
        CStudents oStudents;
        public frmStudentInformation()
        {
            InitializeComponent();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            CStudent oStudent = new CStudent();
            txtSpeak.Text = oStudent.Speak(txtSpeak.Text, false);
            oStudent = null;
        }


        private void btnPopulate_Click(object sender, EventArgs e)
        {
            CStudent oStudent = new CStudent();

            txtId.Text = Guid.NewGuid().ToString();
            txtFirstName.Text = "Homer";
            txtLastName.Text = "Simpson";
            txtStudentID.Text = "123456789";
            txtAddr1.Text = "123 Main St.";
            txtAddr2.Text = "Apt. #4";
            txtCity.Text = "Springfield";
            cboState.Text = "IL";
            txtZIP.Text = "34566";
            txtProgram.Text = "Programmer/Analyst";
            txtGPA.Text = "3.45";
        }

        private void btnAddToCollection_Click(object sender, EventArgs e)
        {
            CStudent oStudent = new CStudent();
            Guid oGuid;
            Guid.TryParse(txtId.Text, out oGuid);

            oStudent.Id = oGuid;
            oStudent.StudentId = txtStudentID.Text;
            oStudent.Program = txtProgram.Text;
            oStudent.FirstName = txtFirstName.Text;
            oStudent.LastName = txtLastName.Text;
            oStudent.Address1.City = txtCity.Text;
            oStudent.Address1.State = cboState.Text;
            oStudent.Address1.ZIP = txtZIP.Text;
            oStudent.Address1.StAddress = txtAddr1.Text;

            oStudent.GPA = float.Parse(txtGPA.Text);
            oStudents.Add(oStudent);
            
            this.Text = oStudents.Count().ToString();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oStudents.Students;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oStudents.Save();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oStudents.Students;
        }

        private void frmStudentInformation_Load(object sender, EventArgs e)
        {
            oStudents = new CStudents();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            oStudents = new CStudents();
            oStudents.Load();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oStudents.Students;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            oStudents = new CStudents();
            oStudents.LoadXML();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oStudents.Students;
        }

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            oStudents.SaveXML();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oStudents.Students;
        }

    }
}
