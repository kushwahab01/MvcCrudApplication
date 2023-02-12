using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class ProductCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public ProductCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Product> GetAllProduct()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);               
                    p.Company = dr["Company"].ToString();            
                   
                    p.IsActive = Convert.ToInt32(dr["IsActive"]);
                    p.Cid = Convert.ToInt32(dr["Cid"]);
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;

        }
        public Product GetProductById(int Id)
        {
            Product p = new Product();
            string qry = "select * from Product where Pid=@Pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Pid", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.Company = dr["Company"].ToString();

                    p.IsActive = Convert.ToInt32(dr["IsActive"]);
                    p.Cid = Convert.ToInt32(dr["Cid"]);
                }
            }
            con.Close();
            return p;
        }

        public int AddProduct(Product p)
        {
            int result = 0;
            p.IsActive = 1;
            string qry = "insert into Product values(@Pname,@Price,@Company,@IsActive,@Cid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Pname", p.Pname);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Company", p.Company);        
            cmd.Parameters.AddWithValue("@IsActive", p.IsActive);
            cmd.Parameters.AddWithValue("@Cid", p.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateProduct(Product p)
        {
            int result = 0;
            p.IsActive = 1;
            string qry = "update Product set Pname=@Pname,Price=@Price,Company=@Company,IsActive=@IsActive,Cid=@Cid where Pid=@Pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Pid", p.Pid);
            cmd.Parameters.AddWithValue("@Pname", p.Pname);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Company", p.Company);
            cmd.Parameters.AddWithValue("@IsActive", p.IsActive);
            cmd.Parameters.AddWithValue("@Cid", p.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int Id)
        {
            int result = 0;
            string qry = "delete from Product where Pid=@Pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Pid", Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
