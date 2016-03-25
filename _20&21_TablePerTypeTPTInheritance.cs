using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _20_DatabaseFirst
{
    /*20 Table Per Type TPT Inheritance with DataBase First
      Geçen derste Entity'i Splitting ile tüm Entity'leri tek tablo ile kullandığımız için tablo tüm Entity'lerin verilerini tutabilecek bir tablo olmalıdır. Fakat bunun 2 dezavantajı var. türeyen bir Entity'i diğer entity'inin sütunlarını kullanamaz fakat o sütunları için Null value tutmak zorundadır. Bu veri tabanını şişirir. Tablo bazı satırları için gereksiz sütunlar barındırdığından denormailzed Table oluşturmuş oluruz.
     
     TPT'de her tablo bir Entity oluşturur. Veri tabanında tablolar arasındaki ilşkiyi Foreign Key kullanarak yapıyoruz. Bu yüzden varsayılan olarak Entity'ler arasındaki Inheritance ile değil Foreign Key ile kuruluyor. Foreign KEy Assosiation'ları sildikten sonra Interihance ilişkisini kurabilriz. Entity'ler arasında Inherihance kullandığımız için türeyen Entity'lerdeki Foreign Key sütunlarını silebiliriz.
     */
    /*21. Table Per Type TPT Inheritance with Code First
      Oluşturmayı istediğimiz Entity'ler için bir Class oluşturup Class'lar arasında Inheritance oluşturuyoruz ve DbContext Class'ına generic Type' olarak Base Class'ı kullanan DbSet<t> türünde bir Property'i ekliyoruz. Aynı işi 19. Derst TPH'de yaptığımızda veri tabanında tek tablo oluşturuldu. Her Class'ın bir tablo oluşturmasını istiyorsak, yapmamız gereken tek şey Class'lara Table Attribute'unu uygulayıp farklı isimler vermekdir.
      Not: Table Attribute ile taptığımız işin aynısını OnModelCreating() methodunda her Class için bir Entity<t>() methodunu uyguladıktan sonra ToTable() methodu ile oluşturulacak Entity'lerin farklı tablolar oluşturmasını sağlayabiliriz.
      Not:  OnModelCreating() methoduna override uygulayarak yaptığımız bu işe FluentAPI deniyor sanırım.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();

            switch (RadioButtonList1.SelectedValue)
            {
                case "Permanent":
                    GridView1.DataSource = employeeDBContext.Employees.OfType<PermanentEmployee>().ToList();
                    GridView1.DataBind();
                    break;

                case "Contract":
                    GridView1.DataSource = employeeDBContext.Employees.OfType<ContractEmployee>().ToList();
                    GridView1.DataBind();
                    break;

                default:
                    GridView1.DataSource = ConvertEmployeesForDisplay(employeeDBContext.Employees.ToList());
                    GridView1.DataBind();
                    break;
            }
        }

        private DataTable ConvertEmployeesForDisplay(List<Employee> employees)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("AnuualSalary");
            dt.Columns.Add("HourlyPay");
            dt.Columns.Add("HoursWorked");
            dt.Columns.Add("Type");

            foreach (Employee employee in employees)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                if (employee is PermanentEmployee)
                {
                    dr["AnuualSalary"] = ((PermanentEmployee)employee).AnnualSalary;
                    dr["Type"] = "Permanent";
                }
                else
                {
                    dr["HourlyPay"] = ((ContractEmployee)employee).HourlyPay;
                    dr["HoursWorked"] = ((ContractEmployee)employee).HoursWorked;
                    dr["Type"] = "Contract";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}