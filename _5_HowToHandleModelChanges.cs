using System;

namespace _5_HowToHandleModelChanges
{
    /*How To Handle Model Changes
      Entity FrameWork oluşturduğu her oluşturduğu veri tabanı için _MigrationHistory adında bir tablo ekler ve bu tabloyu veri tabanını olutursan DbContext Class'ını tanımlamak için kullanır. _MigrationHistory tablosunun 4 sütunu var. ContextKey sütunundaki değer oluşturduğumuz DbContext Class'ının tam adıdır. Entity'i Framework bu değeri veri tabanını oluşturmak için kullandığı DbContext Class'ını tanımlamak için kullanır. Bu yüzden Entity Framework aynı veri tabanı üzerinde çalışan, başka bir DbContext Class'ı kullanırsa, hata oluruş. Tablonun Model sütunundaki değer ise oluşturulan Model'in HashValue değeridir. Model Class'larında değişiklik olursa, kullanılan Hash değeri değişeceği için çalışma zamanında hata alırız.
      Model Class'ı değiştiğinde Entity FrameWork'ün ne yapacağını belirlemek, Entity FrameWork ile gelen Database Class'ının SetInitializer() Static methodunu kullanabiliriz. Method, Method'da kullanılan DbContext Class'ın ilk veri tabanı bağlantısında çalışır. Bu method parametre olarak IDatabaseInitializer<TContext> örneği istiyor. Bu Interface'den türeyen 3 Class var. Bu Class'lar veri tabanı oluşturulma stratejisini belirler. Varsayılan olarak CreateDataBaseIfNotExists<TContext> Class'ı kullanılır. Bunu DropCreateDatabaseIfModelChanges<TContext> ile değiştiriğimizde, Model her değiştiğinde Tablo silinip boş bir veri tabanı oluşturulur. 
      
      1. Not: Veri tabanını tablolarını CodeFirst ile oluşturmadıysak, kodlar üzerinde değişiklik yaparsak, tablonun silinemediğini gösteren bir hata alırız.
      Model compatibility cannot be checked because the database does not contain model metadata. Model compatibility can only be checked for databases created using Code First or Code First Migrations. 
      2. Not: DataBase kullanımdayken veri tabanı silinemeyeceği için silmeyi deneresek hata alırız. 
      Cannot drop database "varitabaniadi" because it is currenly in use. Veri tabanı silinirse içindeki verilerde kaybolur.
     */
    public partial class WebForm1 : System.Web.UI.Page { protected void Page_Load(object sender, EventArgs e) { } }
}