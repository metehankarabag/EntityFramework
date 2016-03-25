﻿using System;

namespace _8_CodeFirst
{
    /*8 . Ders Stored Procedure with Code First
      Veri tabanını DbContext Class'ına göre oluşturduğu için veri tabanına Procedure nesnesi eklemeyi istiyorsak, bu Class'ı kullanmalıyız. Biz oluşturmasak bile Entity Framework varsayılan olarak Insert Update Delete, işlemleri için Procedure'ler oluşturur. DbContext nesnesi üzerinde bir işlem gerçekleştiğinde veri tabanında da aynı etkiyi yapan bir işlem gerçekleştir. Bu yüzden veri tabanı işlemlerini yazdığımız Class'a Insert(), Update() ve Delete() methodları ekledik. Methodların veri tabanını tetikleyebilmesi için methodlara DbContext Class'ının int dönen SaveChanges() methodunu eklemeliyiz. Varsayılan olarak Sql Server'da Parameterized Sql Sorguları kullanıldığını biliyoruz. Procedure'lerin kullanılmasını sağlamak için base DbContext Class üyesi olan DbModelBuilder türünde parametre bekleyen Virtual OnModelCreating() methodunu kullanabiliriz. 
      OnModelCreating() methoduna override uygulayıp yeni uygulama oluşturacağız. Method parametresinde kullanılan DbModelBuilder nesnesi, veri tabanını nasıl oluşturulacağını belirleyen Model'i oluşturur. DbModelBuilder Class'ının üyesi olan Entity<t>() method Generic Type olarak verdiğimiz Class'ı, Entity olarak ayarlar ve EntityTypeConfiguration<TEntityType> türünde bir nesne döner. Bu nesne adından da anlaşılabileceği gibi Entity ayarlarını yapabileceğimiz nesnedir. Bu Class'ın üyesi olan MapToStoredProcedures() methodunu Insert, Update, Delete işlemleri için kullanılacak Procedure'leri ilişkilendirebiliriz. Methodun 2 overload'ı var Parametresiz olanı kullandığımızda ilişkilenidirme işini Entity'i framework otomatik olarak yapar. Atrık Dml sorguları için bu Entity Framework'ün oluşturduğu Procedure'ler çalıştırılacak.
    */
    /*9. Ders 
      Geçen derste Entity Framework'ün oluşturduğu Procedure'leri kullandık. Veri tabanına Procedure eklemeyi istiyorsak, MapToStoredProcedures() methodunun parametreli overload'ını kullanabiliriz. Methodu parametre olarak Action<ModificationStoredProceduresConfiguration<TEntityType> Delegate'i bekliyor. Delegate içinde kullanılan Generic Class'ın Insert(),Update(),Delete() methodlarını kullanarak, Dml sorguları yerine kullanılacak Procedure'leri belirleyebiliriz. Bu Methodların türü de üyesi oldukları Type ile aynıdır. Fakat parametre olarak (Insert,Update,Delete)ModificationStoredProcedureConfiguration<TEntityType> Class'larından birini alır. Bu Class'ların üyeleri ile Stored Procedure parametrelerini belirleyebiliriz.
     */

    public partial class WebForm1 : System.Web.UI.Page { protected void Page_Load(object sender, EventArgs e) { } }
}