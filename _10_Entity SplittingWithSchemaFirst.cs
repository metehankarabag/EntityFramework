using System;

namespace _10_SchemaFirst
{
    /*10. Ders Entity Splitting
      Entity Splitting, bir Entity'nin birden fazla kullanmasıdır. Entity'leri tek bir Entity altında birleştirdiğimizde Entity Splitting yapmış oluruz. Bir Entity'deki Property'leri başka bir Entity'e attığımızda, değişiklikleri kaydederken bir uyarı çıkar bunu kapatıyoruz. Çünkü kabul edersek, taşınan Property'ler eski Entity'i oluşturan Class'dan silinir. Property'leri taşıdık fakat Entity bu Property'lerin hangi Class ile ilişkili olduğunu bilmediği için bu Property'leri taşıyan tabloya Mapping yapmalıyız. Property'lerin eklendiği Entity'e sağ tıklayıp, table Mapping'i seçtiğimizde açılan pencereyi kullanarak, Entity'inin herhangi bir tabloyla ilişkilendirilmemiş Property'lerini diğer Entity ile ilişkilendirebliriz. Bunun için yapmamaız gereken şey <Add a Table or View>'e tıklayıp kullanılacak Class'ı seçmek.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void DetailsView1_ItemInserted(object sender, System.Web.UI.WebControls.DetailsViewInsertedEventArgs e) { GridView1.DataBind(); }
    }
}