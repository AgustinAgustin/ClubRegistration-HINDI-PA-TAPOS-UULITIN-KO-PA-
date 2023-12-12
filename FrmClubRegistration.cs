using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfMembers();
        }

        private long StudentId;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            long StudentId = Convert.ToInt64(TBStudentID.Text);
            string LastName = TBLastName.Text;
            string FirstName = TBFirstName.Text;
            string MiddleName = TBMiddleName.Text;
            int Age = Convert.ToInt32(TBAge.Text);
            string Gender = CBGender.Text;
            string Program = CBPrograms.Text;
            int ID = RegistrationID();
            clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName,MiddleName,LastName, Age, Gender, Program);
            RefreshListOfMembers();
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
        }
        public void RefreshListOfMembers() {
            clubRegistrationQuery.DisplayList();
            DataGridView.DataSource = clubRegistrationQuery.bindingSource;
        }
        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {   
            ClubRegistrationQuery club = new ClubRegistrationQuery();
            RefreshListOfMembers();
        }
        public int RegistrationID() {
            count++;
            return count;
        }
    }
}
