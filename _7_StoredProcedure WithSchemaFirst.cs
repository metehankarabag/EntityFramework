using System;

namespace _7_SchemaFirst
{
    /*Stored Procedure with Schema First
      Ado.net Entity Data Model Wizard'ında tablo seçer veri tabanında oluşturduğumuz Stored Procedure'ları seçebiliriz. Eklenen Procedure'ler Entity'lerde göremeyiz. Çünkü Procedure'ler tabloya değil veri tabanına aittir. (Görüntülemek için pencereye sağ tıklayıp > Model Browser). DbContext nesnesi üzerinde bir işlem gerçekleştirip, Sql Profiler'i a baktığımızda, işlemi veri tabanında gerçekleştirmek için Parametirized Sql Statement olduğunu görürüz. Yani varsayılan olarak Stored Procedure kullanılmaz. Stored Procedure'ları kullanabilmemiz için .edmx uzantılı dosyada Mapping yapmalıyız. (Pencerede > sağ tıkla> StoredProcedute Mapping'i seç)
      Not: Profiler'da exec'den sonra [dbo] StoredProce adı yazıyorsa, bizim oluşturduğumuzu kullanmı demektir. sp_... yazıoyorsa build-in StoredProcedure kullanmıştır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        protected void DetailsView1_ItemInserted(object sender, System.Web.UI.WebControls.DetailsViewInsertedEventArgs e) { GridView1.DataBind(); }
    }
}