using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class CategoryCRUD
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public CategoryCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Category> CategoryList()
        {
            List<Category> clist = new List<Category>();
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.Cid = Convert.ToInt32(dr["Cid"]);
                    c.Cname = dr["Cname"].ToString();
                    clist.Add(c);
                }
            }
            con.Close();
            return clist;
        }
        public Category GetCategoryById(int id)
        {
            Category c = new Category();
            string qry = "select * from Category where Cid=@Cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Cid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    c.Cid = Convert.ToInt32(dr["Cid"]);
                    c.Cname = dr["Cname"].ToString();
                }
            }
            con.Close();
            return c;
        }
        public int AddCategory(Category c)
        {
            int result = 0;
            string qry = "insert into Category values(@Cname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Cname", c.Cname);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCategory(Category c)
        {
            int result = 0;
            string qry = "update Category set Cname=@Cname where Cid=@Cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Cid", c.Cid);
            cmd.Parameters.AddWithValue("@Cname", c.Cname);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            string qry = "delete from Category where Cid=@Cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Cid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
