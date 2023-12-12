using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace ClubRegistration
{
    internal class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlRead;

        private static string connectionString = "Data Source = NEXTTOMARKAGUST\\SQLEXPRESS; Initial Catalog = ClubDB; Integrated Security = True";
        public DataTable dataTable;
        public BindingSource bindingSource;

        public string _Firstname, _Lastname, _Middlename, _Gender, _Program;
        public int _Age;

        SqlConnection SC = new SqlConnection(connectionString);
        DataTable DT = new DataTable();
        BindingSource BS = new BindingSource();

        public bool DisplayList() {
            string ViewClubMembers = ("SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program * FROM ClubMembers");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(ViewClubMembers, SC);
            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            return true;
        }
        public bool RegisterStudent(int ID, long StudentId, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMembers VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentId;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentId;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            return true;
        }

    }
}
