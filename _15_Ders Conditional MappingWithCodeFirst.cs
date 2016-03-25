using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _15_CodeFirst
{
    /*15. Ders Conditional Mapping with Code First
      DBContext Class'ında Entity<t>() methoduna uyguladığımız Map() methodu veri tabanında bir tablo oluşturuyor. Bu tablo oluşturulurken bir sütunun sürekli kontrol edilmesini istiyoruz. Bu yüzden Maps() methodu içinde bir sütuna Required() methodunu uyguluyuz. Sütun beklediğimiz değerini belirlemek için HasValue() methodunu uyguluyoruz. Artık tablo oluşturulduğunda sadece belirlenen sütunun belirlenen değeri alan satırlarını görebiliriz. Maps() methodundan sonra da Property'nin oluşturulacak Entity'den çıkarılması için Ignore() methodunu uygulamamız gerekiyor.
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            GridView1.DataSource = employeeDBContext.Employees.ToList();//Tolist()'e çevirmesinin nedeni Null geldiğinde boş bir liste dönmesi.
            GridView1.DataBind();
        }
    }
}