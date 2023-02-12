using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class EmployeeCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Employee> GetAllEmployess()
        {
            List<Employee> emplist = new List<Employee>();
            string qry = "select * from Employee where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.EName = dr["Ename"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.City = dr["City"].ToString();
                   
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.IsActive = Convert.ToInt32(dr["IsActive"]);
                    emp.Deptid = Convert.ToInt32(dr["Deptid"]);
                    emplist.Add(emp);
                }
            }
            con.Close();
            return emplist;

        }
        public Employee GetEmployeeById(int Id)
        {
            Employee emp = new Employee();
            string qry = "select * from Employee where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.EName = dr["EName"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.IsActive = Convert.ToInt32(dr["IsActive"]);
                    emp.Deptid = Convert.ToInt32(dr["Deptid"]);
                }
            }
            con.Close();
            return emp;
        }

        public int AddEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "insert into Employee values(@EName,@Mobile,@Email,@City,@Gender,@Salary,@IsActive,@Deptid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EName", emp.EName);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
            cmd.Parameters.AddWithValue("@Deptid", emp.Deptid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "update Employee set EName=@EName,Mobile=@Mobile,Email=@Email,City=@City,Gender=@Gender,Salary=@Salary,IsActive=@IsActive,Deptid=@Deptid where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@EName", emp.EName);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
            cmd.Parameters.AddWithValue("@Deptid", emp.Deptid);
            con.Open();
             result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int Id)
        {
            int result = 0;
            string qry = "delete from Employee where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
