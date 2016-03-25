using System;

namespace _1_SchemaFirst
{
    /*What is Entity FrameWork
      Entity Framework ORM(Object Relation Mapping) Framework'dür. ORM Framework, hem veri tabanına göre Class'ları otomatik oluşturur hemde Class'lara göre veri tabanını oluşturmamaız için gerekli Sql Sorgularını hazırlar. Entity Framework 3 farklı şekilde kullanılabilir. 
      1. Schema First: Veri tabanının elle oluşturulmasıdır. Entity Framework otomatik olan Model'i ve Model'i oluşturan Class'ları oluturur.
      2. Model First:  Model'in elle oluşturulmasıdır. Entity Framework Model'i oluşturan Class'ları ve gereki Sql Script'ini otomatik olarak oluşturur.
      3. Code First:   Model'i oluşturan Class'ların elle oluşturulmasıdır. Entity FrameWork Model'i ve veri tabanını otomatik olarak oluşturur.
      
      Yani Entity Framework kullanarak, bir nesneyi iki farklı ortamda tanımlamış oluruz. C# ortamında oluşturulmuş Model ile veri tabanındaki tablo aynı yapıda olduğu için Model'i oluşturan Class'ları veri tabanında gönderilmek istenen verilerin uygunluğunu denetlemek için kullanabiliriz. Bu durum gereksiz yere veri tabanı ile bağlantı kurmamaızı engeller. Entity Framework'ü Nuget Packed Manager'dan indirerek uygulamaya ekleyebiliriz.
      
      1. Schema First: Oluşturduğumuz veri tabanını kullanarak Model'i oluştururuz. Model oluşturmak için Ado.net Entity Data Model nesnesini kullanmalıyız.(Wizar'ının nasıl kullanıldığını yazmıyorum). Model'i oluşturduktan sonra açılan pencerede görürenler tabloları temsileden Entity'lerdir. Model nesnesi 2 seviyeden oluşur. 1. DbContext Class'ı, bu Class veri tabanını temsil eder. Yani bu Class tüm üyeleri, veri tabanına nesnelerine çevirilir. 2. Tablo gibi nesnelerin tanımlandığı Class'lardır.
    */
    public partial class WebForm1 : System.Web.UI.Page { protected void Page_Load(object sender, EventArgs e) { } }
}