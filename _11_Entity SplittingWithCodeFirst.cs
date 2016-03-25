using System;

namespace _11_CodeFirst
{
    /*11. Ders Entity Splitting
      OnModelCreating() methodu içinde DbModelBuilder Class'ının Entity<t>() methodu ile oluşturulan Entity'inin 2 tablo kullanmasını sağlamalıyız. Bu yüzden methoda generic Type olarak verdiğimiz Class'ın 2 tablo oluşturmasını sağlamalıyız. 
      Entity<t>() methodunun EntityTypeConfiguration<TEntityType> türünde bir nesne döndüğünü biliyoruz. Bu Class'ın üyesi olan 2 tane Maps() methodu var. Methodlar üyesi oldukları Class ile aynı tür nesne döndükleri için methodları arka arkaya uygulayabilriz. Maps() methodunu ne kadar uygularsak Entity'i o kadar çok tablo kullanır. Method parametre olarak EntityMappingConfiguration<TEntityType> Class'ının bir örneğini istiyor. Bu Class'ın üyesi olan Properties() methodları ve tablo adını belirlemek için ToTable() methodları var. Oluşturulacak tablonun adını ve oluşturduğumuz Class'dan hangi Property'leri barındıracağını bu methodları kullanarak ayarlayabiliriz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void DetailsView1_ItemInserted(object sender, System.Web.UI.WebControls.DetailsViewInsertedEventArgs e) { GridView1.DataBind(); }
    }
}