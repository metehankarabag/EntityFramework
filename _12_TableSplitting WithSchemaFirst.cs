using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _12_SchemaFirst
{
    /*12 Table Splitting with Schema First
      Table spliting bir tablonun birden fazla Entity'de oluşturmasıdır. Table Splitting, Lazy Loading için kullanılır. Yani tablonun verisi çok olan bazı sütunlarının sadece gerekiğinde yüklenmesini için kullanılır. Yani Entity her kullanıldığına, çoğu kez işe yaramayan fakat ağır veriler taşıyan Property'leri entity'den ayırmak için kullanılır. Veri tabanında bir tablomuz varsa, bir Entity oluşturulur. Bir Entity daha ekleyip Property'leri Entity'lere dağattıktan sonra oluşturduğumuz Entity'ye Table Mapping uygulayıp diğer Entity'i oluşturan Class'ı veriyoruz. Böylece bir Class 2 Entity'de kullanılmış oluyor. Tablolar arasındaki ilişkiyi oluşturmak için ise Entity'ler arasında Foreign Key Assosiation oluşturmamız gerekir. 
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
                                        new DataColumn("Gender")
                                   };

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
                                     new DataColumn("LandLine") 
                                   };
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
            if (checkBoxIncludeContactDetails.Checked) GridView1.DataSource = GetEmployeeDataIncludingContactDetails();
            else                                       GridView1.DataSource = GetEmployeeData();

            GridView1.DataBind();
        }

    }
}