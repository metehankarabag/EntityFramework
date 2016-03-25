using System;
using System.Linq;

namespace _16_DatabaseFirst
{
    /*16 Self Referencing Association with Database First
      Self Referencing: Foreign Key'in, bulunduğu tablonun Primary Key'ini kullanmasına denir. Bir veri tabanı Model'e çevrildiğinde Foreign Key 2 tabloda da bir Navigation Property oluşturur. Fakat bu Foreign Key kendine referans verdiği için bir Entity'de 2 Navigation Property'i olur. Sorun oluşturulan Navigation Property'lerin adının aynı olmasıdır. Hangi Property'inin Id sütunundan değer aldığını hangisinin Foreignk Key sütunundan değer aldığını anlamak için Property'lerin çoğulluğuna bakabiliriz.
      Bir veya 0 değer alabilen Id sütununu kullanır.(Yani bu Employee tablosundaki Navigation Property)
      Birden fazla değer alabilen Foreign Key sütununu kullanır.(Bu daha hayali referans tablosundaki Navigation Property)
      Not: Normal'de Foreign Key üstunu Id sütununda olmayan bir değeri alırsa, hata oluşur ve satırı ekleyemeyiz. Fakat bu Self Referanceing Table olduğu için bu oluyor. Bu yüzden Id sütununu kullanan Nagivation Property'i hiç değer alamayabiliyor.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            GridView1.DataSource = employeeDBContext.Employees.Select(
                                                            emp => new { EmployeeName = emp.EmployeeName, ManagerName = emp.Manager == null ? "Super Boss" : emp.Manager.EmployeeName }
                                                            ).ToList();
            GridView1.DataBind();
        }
    }
}