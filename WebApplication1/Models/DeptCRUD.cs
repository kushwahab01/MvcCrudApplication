using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DeptCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public DeptCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Dept> DeptList()
        {
            List<Dept> deptlist = new List<Dept>();
            string qry = "select * from Dept";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Dept dept = new Dept();
                    dept.Deptid = Convert.ToInt32(dr["Deptid"]);
                    dept.DeptName = dr["DeptName"].ToString();
                    deptlist.Add(dept);
                }
            }
            con.Close();
            return deptlist;
        }
        public Dept GetDeptById(int id)
        {
            Dept dept = new Dept();
            string qry = "select * from Dept where Deptid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.Deptid = Convert.ToInt32(dr["Deptid"]);
                    dept.DeptName = dr["deptname"].ToString();
                }
            }
            con.Close();
            return dept;
        }
        public int AddDept(Dept dept)
        {
            int result = 0;
            string qry = "insert into Dept values(@deptname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptname", dept.DeptName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateDept(Dept dept)
        {
            int result = 0;
            string qry = "update Dept set DeptName=@DeptName where Deptid=@Deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Deptid", dept.Deptid);
            cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
           
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteDept(int id)
        {
            int result = 0;
            string qry = "delete from Dept where Deptid=@Deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
