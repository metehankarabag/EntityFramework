using System;
using System.Linq;

namespace _24_DatabaseFirst
{
    /*24 Entity for BridgeTable in Many to Many relationship with Database First
      2 Entity arasında Many to Many Relationship oluşturmak için veri tabanına bir Bridge Table eklememiz gerekir. Bridge table sadece Foreign Key'ler için gerekli sütunları içeriyorsa, Entity Framework bu tablonun bir Entity'ini oluşturmaz. Fakat Bu tablo Foreign Key de kullanılmayan bir sütun barındırıyorsa, Entity bu tabloyu oluşturarak diğer Entity'lere one to many relationship oluşturur. Yani artık navigation Property'ler bu aracı Entity'nin türünde oluşturulur.  
      Geçen derste bir örneciyi bir kursa eklemek için öğrenci nesnesinin Navigation Property'sini kullanarak kurs nesnesini eklememiz gerekiyordu. Çünkü Navigation Property'nin türü Course'du. Bu derste ise aynı işi yapmak için eşleşmenin yapıldığı tabloyu kullanabiliriz. Ara tabloya eklediğimiz her satır bir öğrenciye bir kurs ekler. Yani Ekleme işini bir Entity'e (tabloya) direk olarak yapacağız. Tabloyu temsil eden Property'e ulaşıp AddObject() methodunu uygulamalıyız. Aynı şekilde DeleteObject() methodunuda uygulayabiliriz.
     */
    /*25. Ders Entity for BridgeTable in Many to Many relationship with Code First
      Birdge Table'ında oluşturulmasını istediğimiz için 3 Class oluşturmamız gerekiyor. Esas tablolara Navigation Property'lerin türü çoğul(IList<t>) ayarlarsak, oluşturulacak Foreign Key bu tabloyu Referance tablo olarak kullanır. Yani Primary Key'in olduğu tablo olarak kullanır. Bridge Table'da Key Attribute'unu kullanarak 2 tane Foreing Key sütunu belirlemeliyiz. Bu sütunların sırası önemli olduğu için Column Attribute'unun Order Property'sini de kullanmalıyız.
     
      Not: [] içinde virgül ile birden fazla Attribute'u yazabiliyormuşuz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentDBContext studentDBContext = new StudentDBContext();

            GridView1.DataSource = (from student in studentDBContext.Students
                                    from studentCourse in student.StudentCourses
                                    select new
                                    {
                                        StudentName = student.StudentName,
                                        CourseName = studentCourse.Course.CourseName,
                                        EnrolledDate = studentCourse.EnrolledDate
                                    }).ToList();

            // The above query can also be written as shown below
            //GridView1.DataSource = (from course in StudentDBContext.Courses --
            //                        from studentCourse in course.StudentCourses
            //                        select new
            //                        {
            //                            StudentName = studentCourse.Student.StudentName,
            //                            CourseName = course.CourseName,
            //                            EnrolledDate = studentCourse.EnrolledDate
            //                        }).ToList();

            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentDBContext StudentDBContext = new StudentDBContext();
            StudentDBContext.StudentCourses.AddObject (new StudentCourse { StudentID = 1, CourseID = 4, EnrolledDate = DateTime.Now });
            StudentDBContext.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StudentDBContext StudentDBContext = new StudentDBContext();
            StudentCourse studentCourseToRemove = StudentDBContext.StudentCourses.FirstOrDefault(x => x.StudentID == 2 && x.CourseID == 3);
            StudentDBContext.StudentCourses.DeleteObject(studentCourseToRemove);
            StudentDBContext.SaveChanges();
        }
    }
}