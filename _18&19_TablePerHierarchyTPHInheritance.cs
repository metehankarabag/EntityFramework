using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _18_DatabaseFirst
{
    /*18 Table Per Hierarchy TPH Inheritance with DataBase First
      Veri tabanında tek bir tablo var. Bu tabloyu kullanan bir den fazla Entity oluşturuyoruz.(Table Splitting). Bu Entity'lerden birini base Entity olarak diğerini/lerini türeyen Entity olarak belirlediğimizde TPH oluşturmuş oluyoruz. Türeyen Entity'leri oluştururken yapacağımız tek değişikiş Base Type'a bir Entity'i vermekdir. Base Type olarak kullanılacak Entity'i belirlediğimizde Entity'e Id sütunu eklememiz engellenir. Çünkü base Type'ın Id sütununu kullanılacak. Entity'i oluşturduğumuzda Entity'ler arasındaki Inheritance'i belirleyen bir ok oluşur. Oluşturduğumuz Entity'nin adının altında Base Entity'i adını görebiliriz. Bu Entity'e base Entity'den gerekli Property'leri attıktan sonra Model'e Validate uyguladığımızda, türeyen Entity'ler hiç bir tabloyu kullanmadığını söyleyen hatalar alırız. Validate işlemini tekrar denediğimizde tekrar hatalırız. Birden fazla türeyen Entity oluşturmamızın nedeni bazı sütun bilgilerinin bazı satırlarda görünmesini engellemek. Her satırda tüm sütun bilgileri görüntülenecekse Entity'i bölmemizin bir anlamı yok. (Sanırım hatanın nedeni bu.) Bu yüzden bizden bir türeyen Entity'i kullanılırken diğerinin kullanılmasını engellemek için türeyen Entity'lere Conditional Mapping yapmamızı istiyor. Geçen derslerde görmüştük Conditional Mapping tablo ile birlikte her zaman çalışan koşuldur. Bir Property'inin hem Scalar Property'i hemde Conditional Property'i olarak kullanılamayacağını bildiğimiz için Base Entity'den de bu sütunu silmemiz gerekiyor. Tablodan alınan sütun değeri türeyen Entity'ler ile birlekte kullanılır ve satır için bir Entity elenir.
      Not: Base Type'ın bir örneğinin oluşturulması mantıklı olmadığı için Entity'inin Properties penceresini kullanarak Entity'i oluşturan Class'ı Abstract Class yapıyoruz.   
     */
     //19. Ders -> Code Fist'de özel bir şey yok. Base Entity'i oluşturan Class'dan türeten Class'lar oluşturduktan sonra oluşturduğumuz DbContext Class'ında DbSet<BaseType> türünde bir Property'i eklediğimizde tablo oluşturulur. Dikkatimi çeken Conditional Property'i Entity Framework'ün otomatik olarak eklemesidir.
    
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
                dr["ID"] = employee.ID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                if (employee is PermanentEmployee)
                {
                    dr["AnuualSalary"] = ((PermanentEmployee)employee).AnuualSalary;
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