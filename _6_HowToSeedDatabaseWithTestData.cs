using System;

namespace _6_HowToSeedDatabaseWithTestData
{
    /*How To Seed Database With Test Data
      Model değiştiğinde yeni oluşturulacak veri tabanının boş oluşturulmasını istemiyorsak, DropCreateDatabaseIfModelChanges Class'ından türeyen bir Class oluşturup, bu Class'da oluşturulacak tabloya veri ekledikten sonra Class'ı SetInitializer() methoduna parametre olarak verebiliriz. DropCreateDatabaseIfModelChanges Class'ı IDatabaseInitializer<TContext> Interface'inden türediği için bu Interface'in  void dönen Seed(TContext) methodunu uygulama yazmak zorundadır. Bu method tüm işi yapab methoddur. Biz sadece method parametresinde kullanılan Context Class'ının oluşturacağı tablolara veri ekleyeceğiz. Yani DbContext Class'ında tabloları oluşturan DBSet<T> Property'leri olduğu için bu Property'lere değer döndermeliyiz.
      Not: aşağıdaki kodda dikkat etmemiz gereken Employee Class'ının DepartmentId Foreign Key Property'sine değer girmememiz Entity Framework bu işi otomatik olarak yapıyor.
      public class EmployeeDBContextSeeder : DropCreateDatabaseIfModelChanges<EmployeeDBContext>
      {
         protected override void Seed(EmployeeDBContext context)
         {
               Department department1 = new Department() --> Department nesnesi oluşturduk. Employee nesnesi de oluşturabiliridik.
               {
                   Name = "IT",
                   Location = "New York",
                   Employees = new List<Employee>()
                   {
                       new Employee(){FirstName = "Mark", LastName = "Hastings", Gender = "Male", Salary = 60000, JobTitle = "Developer"},
                   } 
               };
               
               context.Departments.Add(department1); --> oluşturduğumuz nesneyi DbContext Class'ının Departments Property'sine ekledik. 
               base.Seed(context); --> asıl isi yapan base Class'ın methoduna örneği vererek çalıştırdık.
         } 
      }
      Not: Oluşturduğumuz Class'ın nereden tetiklendiğini çözemedim.
     
     */
    public partial class WebForm1 : System.Web.UI.Page { protected void Page_Load(object sender, EventArgs e) { } }
}