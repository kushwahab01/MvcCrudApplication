using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class BookCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public BookCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Book> GetAllBook()
        {
            List<Book> Booklist = new List<Book>();
            string qry = "select * from Book where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book b = new Book();
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Bname = dr["Bname"].ToString();
                    b.Auther = dr["Auther"].ToString();
                    b.Price = Convert.ToDouble(dr["Price"]);
                    b.Publish = Convert.ToDateTime(dr["Publish"]);
                    b.IsActive = Convert.ToInt32(dr["IsActive"]);
                    Booklist.Add(b);
                }
            }
            con.Close();
            return Booklist;

        }
        public Book GetBookById(int Id)
        {
            Book b = new Book();
            string qry = "select * from Book where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Bname = dr["Bname"].ToString();
                    b.Auther = dr["Auther"].ToString();
                    b.Price = Convert.ToDouble(dr["Price"]);
                    b.Publish = Convert.ToDateTime(dr["Publish"]);
                    b.IsActive = Convert.ToInt32(dr["IsActive"]);
                }
            }
            con.Close();
            return b;
        }

        public int AddBook(Book b)
        {
            int result = 0;
            b.IsActive = 1;
            string qry = "insert into Book values(@Bname,@Auther,@Price,@Publish,@IsActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Bname", b.Bname);
            cmd.Parameters.AddWithValue("@Auther", b.Auther);
            cmd.Parameters.AddWithValue("@Price", b.Price);
            cmd.Parameters.AddWithValue("@Publish", b.Publish);
            cmd.Parameters.AddWithValue("@IsActive", b.IsActive);         
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateBook(Book b)
        {
            int result = 0;
            b.IsActive = 1;
            string qry = "update Book set Bname=@Bname,Auther=@Auther,Price=@Price,Publish=@Publish,IsActive=IsActive where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", b.Id);
            cmd.Parameters.AddWithValue("@Bname", b.Bname);
            cmd.Parameters.AddWithValue("@Auther", b.Auther);
            cmd.Parameters.AddWithValue("@Price", b.Price);
            cmd.Parameters.AddWithValue("@Publish", b.Publish);
            cmd.Parameters.AddWithValue("@IsActive", b.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteBook(int Id)
        {
            int result = 0;
            string qry = "delete from Book where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
