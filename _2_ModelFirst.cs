using System;

namespace _2_ModelFirst
{
    /*ModelFist
      İşe Model'den başladığımız için Model'i veri tabanına göre oluşturamayız. Bu yüzden Ado.net Entity Data Model aracını kullanarak boş bir Model oluşturmamız gerekir. Entity Framewok Model'i oluşturan Class'ları otomatik olarak yazar ve bu boş bir veri tabanını temsil eder. Model'e Entity'ler ekleyerek veri tabanına tablolar gekleyebiliriz. Model'den gerekli Sql Script'ini almak için ise pencereye sağ tıklayıp Generate Database From Model'i seçip gerekli bilgileri girmemiz yeterlidir.
      Açılan boş Model sayfasına Entity eklemek için pencerede sağtıklıyıp Add -> Entity'i seçebiliriz oluşturmamız için açılan pencerede 3 şey belirlememiz gerekiyor. 1. Entity adı(Tablo adı), 2. Entity'i DbContext Class'ında kullanmak için oluşturulacak Entity Set Property'sinin adı, 3. Tablonun Primarty Key sütunun adı. Bu işi yaptıktan sonra Eklenen Entity'inin Property'leri vs.. eklemeliyiz. Yani oluşturulacak tabloya ait nesneleri oluturmalıyız.  Enitiy'e sağ tıklayıp Add'e tıkladığımızda 3 farklı tür Property'i olduğunu görürüz. 1. Scalar Property: Tablo sütunlarını temsil eden Property'leri oluşturur. 2. Complext Property 3. Navigation Property: Türü, üyesi olduğu Entity'i oluşturan Class'ın türünden farklı olan Property'lerdir. Entity'ler arasında Foreign Key'i ilişkisi oluşturmayı istiyorsak, pencerenin boş bir yerine sağ tıklayıp >Add > Association'a tıklamalıyız. 
      Açılan Pencerede
      Multiplicity: ForeignKey'in nasıl oluşturulacağını belirler. Buradaki değere bakara Foreign Key'in hangi Entity'e ekleneceğini anlayabiliriz.
      Navigation Property: Bu CheckBox Entity'lere, Forign Key'i kullanarak, karşı Entity'den değer alan Navigation Property'ler ekler.
      En altdaki CheckBox ise Foreign Key'in ekleneceği Entity'e Property eklemek için kullanılır.
      
      Not: Entity'e eklediğimiz Property'lere sağ tıklayıp Properties penceresinden Property ayarlarını yapabiliriz. Bu penceredeki StoreGenerate Property'si, Entity Property'sinin veri tabanında Identity sütun olup olmadığını belirler.
      Not: Oluşturulan Sql Script'inde, eklenen Foreign Key Property'sine non-clustered Index uygulanmış. Yani Bu sütunun değerleri farklı bir tablo aracılığı ile kullanılıyor.
     */
    public partial class WebForm1 : System.Web.UI.Page { protected void Page_Load(object sender, EventArgs e) { } }
}