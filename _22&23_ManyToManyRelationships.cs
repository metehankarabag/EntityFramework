using System;
using System.Linq;

namespace _22_DatabaseFirst
{
    /*22 Many to Many Relationship with Database First
      Foreign Key kullanarak 2 tablo arasında ilişki kurabiliriz. Fakat referance tablonun Id sütununu kullanmak zorunda olduğumuz için Foreign Key'i barından tablo karşı tablodan sadece bir satır alabilir. Bu yüzden aracı bir tablo kullanıyoruz. Aracı tablo Foreign Key'leri barındıran tablodur. Yani bu tablonun kullanacağı referans tablolar gerçek tablolar olur. X tablosu aracı tablodan bir çok satırı alabilir ve bu satırlarda bulunan diğer sütun değerlerini kullanabilir. Bu sütunların her değeri B tablosundan bir satır alır. Yani X tablosu aracı tablodan aldığı her satır için B tablosundan bir satır alacağı için Many to Many relationship kurulmuş olur.(A ile B yer değiştirebilir.)
      Aracı tablonun sadece Foreign Key'lerde kullandığı sütunları içerir. Bu yüzden varsayılan olarak Entity Framework bu tablonun Entity'sin oluşturmak yerine Many to Many Relationship oluşturur. Foreign Key bağlantısına sağ tıklayıp Table Mappıng'e baktığımızda, bağlantının 3. tabloya yönlendirildiğini görürürüz.
     */
    /*23 Many to Many Relationship with CodeFirst
      Class'lara Navigation Property eklediğimizde Entity Framework otomatik olarka Foreign Key oluşturur. Yapmamız gereken tek şey tüm Class'lara List<t>,IEnumerable<t>... türünde Navigation Property'ler eklemek. Entity Framework bu ForeignKey'ler için bir tablo oluşturur. Fakat oluşturulan tablonun sütun isimlerini kontrol edemiyoruz. 
      Bu yüzden Dbcontext Class'ında ONMODELCREATING() methodunda oluşturulacak Foreign Key'leri düzenlemeliyiz. Bunun için Entity<A_Entity>().HasMany(x => x.A_NavigationProp).WithMany(x => x.B_NavigationProp).Map(); kodunu kullanmalıyız. Map() metodu için de ToTable(), MapLeftKey() ve MapRightKey() methodlarını kullanmalıyız. LeftKey() methoduna ilk kullandığımız Entity'den bir sütunun adını vermeliyiz. RightKey() diğer entity'den bir sütun adını vermeliyiz.
      
      Not: Bir Tablo'daki bir üyenin Navigation Property'sine değer eklemeyi denediğimizde hataalırız. Çünkü varsayılan olarak Nagivation Property(diğer tablo) verisi yüklenmez. Bunu düzelmek için tablo verisini geçmek için kullandığımız veriden hemen sonra Include() methodunu kullanıp, methoda parametre olarak diğer tablonun adını vermeliyiz.  Students.Include("Courses"). Bu işi yaptıktan sonra ilk tablodaki bir üyenin navigation Property'si değerleri yüklendiği için hata almayız.
      
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentDBContext StudentDBContext = new StudentDBContext();

            GridView1.DataSource = (from student in StudentDBContext.Students// Öğrenci tablosundaki öğrencileri aldık.
                                   from course in student.Courses// Bir örğencinin tüm kurslarını alık
                                   select new
                                   {
                                       StudentName = student.StudentName, // Öğrencinin adı ile kurs adını alıp bir satır ekledik. Öğrenci aldığı her ders için yeni bir satıra eklenecek
                                       CourseName = course.CourseName
                                   }).ToList();
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentDBContext employeeDBContext = new StudentDBContext();
            Course WCFCourse = employeeDBContext.Courses.FirstOrDefault(x => x.CourseID == 4); // Bir kursu aldık.
            Student student = employeeDBContext.Students.FirstOrDefault(x => x.StudentID == 1); // Bir öğrenciyi aldık.
            
            student.Courses.Add(WCFCourse); // Örğencinin Courses Property'sine kursu ekledik.
            employeeDBContext.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StudentDBContext employeeDBContext = new StudentDBContext();
            Course SQLServerCourse = employeeDBContext.Courses.FirstOrDefault(x => x.CourseID == 3); // Bir kursu aldık
                                                       //Bir örğenciyi altık. Courses Property'sinden sildik. 
            employeeDBContext.Students.FirstOrDefault(x => x.StudentID == 2).Courses.Remove(SQLServerCourse);
            //Code First'de Students Property'sinden sonra Include("Courses") methodunu kullanmassak hata alırız.
            employeeDBContext.SaveChanges();
        }
    }
}