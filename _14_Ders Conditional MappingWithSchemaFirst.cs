using System;

namespace _14_DatabaseFirst
{
    /* 14. Ders Conditional Mapping with Database First
      Kalıcı filitreleme anlamına geliyor. Yani Entity her kullanıldığında bir Where Clause ile birlikte çalışacaksa, Conditional Mapping kullanılır. 
      SchemaFirst'de pencere'de sağ tık > mapping > Condition > sütun seç -> karşılaştırma operatörünü ve değerini seç. Kullanılan sütunu Entity'den silmek gerekiyor. Çünkü bir Entity'deki Property 2 kez Map yapılamıyor. Biri Entity'den silinmeli. Yani entity'e her zaman bir Where ile birlikte çalışır.
    */
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            GridView1.DataSource = employeeDBContext.Employees;
            GridView1.DataBind();
        }
    }
}