using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Student> GetAllStudent()
        {
            List<Student> slist = new List<Student>();
            string qry = "select * from Student where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student s = new Student();
                    s.Id = Convert.ToInt32(dr["Id"]);
                    s.Sname = dr["Sname"].ToString();
                    s.Marks = Convert.ToDouble(dr["Marks"]);
                    s.City = dr["City"].ToString();
                    s.Cname = dr["Cname"].ToString();
                    s.IsActive = Convert.ToInt32(dr["IsActive"]);

                  slist.Add(s);
                }
            }
            con.Close();
            return slist;

        }
        public Student GetStudentById(int Id)
        {
            Student s = new Student();
            string qry = "select * from Student where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    s.Id = Convert.ToInt32(dr["Id"]);
                    s.Sname = dr["Sname"].ToString();
                    s.Marks = Convert.ToDouble(dr["Marks"]);
                    s.City = dr["City"].ToString();
                    s.Cname = dr["Cname"].ToString();
                    s.IsActive = Convert.ToInt32(dr["IsActive"]);
                }
            }
            con.Close();
            return s;
        }

        public int AddStudent(Student s)
        {
            int result = 0;
           int IsActive = 1;
            string qry = "insert into Student values(@Sname,@Marks,@City,@Cname,@IsActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sname", s.Sname);
            cmd.Parameters.AddWithValue("@Marks", s.Marks);
            cmd.Parameters.AddWithValue("@City", s.City);
            cmd.Parameters.AddWithValue("@Cname", s.Cname);
            cmd.Parameters.AddWithValue("@IsActive", s.IsActive);
                     
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateStudent(Student s)
        {
            int result = 0;
            s.IsActive = 1;
            string qry = "update Student set Sname=@Sname,Marks=@Marks,City=@City,Cname=@Cname,IsActive=@IsActive where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", s.Id);
            cmd.Parameters.AddWithValue("@Sname", s.Sname);
            cmd.Parameters.AddWithValue("@Marks", s.Marks);
            cmd.Parameters.AddWithValue("@City", s.City);
            cmd.Parameters.AddWithValue("@Cname", s.Cname);
            cmd.Parameters.AddWithValue("@IsActive", s.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int Id)
        {
            int result = 0;
            string qry = "delete from Student where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
