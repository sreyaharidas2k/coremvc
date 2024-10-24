
using System.Data;
using System.Data.SqlClient;

namespace coremvc.Models
{
    public class DBEmployee
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-N5FGT72\SQLEXPRESS;database=asp_core;integrated security=true");

        public string InsertDB(Employee empclsobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Insertemp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empname", empclsobj.ename);//get
                cmd.Parameters.AddWithValue("@empadd", empclsobj.eadd);
                cmd.Parameters.AddWithValue("@empsalary", empclsobj.esal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }

        public int LoginDB(Employee empclsobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", empclsobj.eid);//get
                cmd.Parameters.AddWithValue("@ena", empclsobj.ename);
                con.Open();
                string cid = cmd.ExecuteScalar().ToString();
                con.Close();
                int ccid = Convert.ToInt32(cid);
                return ccid;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
        public Employee Profileview(int id)
        {
            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_profile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);//get

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    getdata = new Employee
                    {
                        eid = Convert.ToInt32(dr["Emp_Id"]),//set
                        ename = dr["Emp_Name"].ToString(),
                        eadd = dr["Emp_Address"].ToString(),
                        esal = dr["Emp_Salary"].ToString(),
                    };
                }
                con.Close();

                return getdata;//("ok...");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

        public string UpdateDB(Employee empclsobj)
        {
            string retval = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", empclsobj.eid);//get
                cmd.Parameters.AddWithValue("@eadd", empclsobj.eadd);
                cmd.Parameters.AddWithValue("@esal", empclsobj.esal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                retval = "OK... Updated";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
            return (retval);
        }


        public List<Employee> SelectDB()
        {
            var list = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectall", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var o = new Employee
                    {
                        eid = Convert.ToInt32(dr["Emp_Id"]),
                        ename = dr["Emp_Name"].ToString(),
                        eadd = dr["Emp_Address"].ToString(),
                        esal = dr["Emp_Salary"].ToString()
                    };
                    list.Add(o);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

        public string DeleteDB(int id)
        {
            string retval = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);//get

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                retval = "OK... Deleted";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
            return (retval);
        }

        public Employee DetailsDB(int id)
        {

            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_profile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);//get

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    getdata = new Employee
                    {
                        eid = Convert.ToInt32(dr["Emp_Id"]),//set
                        ename = dr["Emp_Name"].ToString(),
                        eadd = dr["Emp_Address"].ToString(),
                        esal = dr["Emp_Salary"].ToString(),
                    };
                }
                con.Close();

                return getdata;//("ok...");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }

        }
    }
}


