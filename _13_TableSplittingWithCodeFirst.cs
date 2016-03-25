using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _13_CodeFirst
{
    /*13 Table Splitting
      Entity Splitting'de bir Entity'e Maps() methodları uygulayarak, bir kaç tablo oluşturmasını sağladık. Bu sefer 2 Entity'e ToTable() methodunu kullanarak Aynı tablo ismini veriyoruz. Böylece Entity'i oluşturan Class'lar tek bir tablo oluşturuyor. Yani tek bir tablo 2 Entity'de kullanılmış oluyor. Entity'lerin birleştirilebilmesi için Foreign Key oluşturmamız gerekir. Bu yüzden Entity'lere HasKey() methodunu uygulayarak Primary Key üstunlarını belirlememiz gerekiyor. HasRequired() methodunu uygulayıp parametre olarak Navigation Property'i vermeliyiz. Bu methodu uyguladıktan sonra 2 şeceneğimiz var 1. WithRequiredPrincipal() 2. WithRequiredDepent().(Bunu yazmıyorum karışık oluyor.) 1. yi kullanırsak Foreign Key methdun kullandığı Entity'inin Primary sütunun kullanır.(Haliyle Foreign Key ilk kullanılan Entity'e eklenir.) 2. yi kullanırsak tersi.
      Not: Foreign Key'i belirlemediğimiz'de hata alıyoruz. Foreign Key Navigation Property'lerin türüne göre göre otomatik olarak oluşturulmuyor. Bunun nedeni ne?
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DataTable GetEmployeeData()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            List<Employee> employees = employeeDBContext.Employees.ToList();

            DataTable dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender")};

            dataTable.Columns.AddRange(columns);

            foreach (Employee employee in employees)
            {
                DataRow dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }

        private DataTable GetEmployeeDataIncludingContactDetails()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            List<Employee> employees = employeeDBContext.Employees.Include("EmployeeContactDetail").ToList();

            DataTable dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender"),
                                 new DataColumn("Email"),
                                 new DataColumn("Mobile"),
                                 new DataColumn("LandLine") };
            dataTable.Columns.AddRange(columns);

            foreach (Employee employee in employees)
            {
                DataRow dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;
                dr["Email"] = employee.EmployeeContactDetail.Email;
                dr["Mobile"] = employee.EmployeeContactDetail.Mobile;
                dr["LandLine"] = employee.EmployeeContactDetail.LandLine;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBoxIncludeContactDetails.Checked)
            {
                GridView1.DataSource = GetEmployeeDataIncludingContactDetails();
            }
            else
            {
                GridView1.DataSource = GetEmployeeData();
            }
            GridView1.DataBind();
        }
    }
}