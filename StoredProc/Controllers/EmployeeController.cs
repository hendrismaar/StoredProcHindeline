using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoredProc.Data;
using StoredProc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config { get; }

        public EmployeeController
            (
            StoredProcDbContext context,
            IConfiguration config
            )
        {
            _context = context;
            _config = config;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employee
                .FromSqlRaw<Employee>("spSearchEmployees")
                .ToList();

            return result;
        }

        [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        /// <summary>
        /// SearchPageWithoutDynamicSQL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DynamicSQL(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (firstName != null)
                {
                    SqlParameter param_fn = new SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param_fn);
                }
                if (lastName != null)
                {
                    SqlParameter param_ln = new SqlParameter("@LastName", lastName);
                    cmd.Parameters.Add(param_ln);
                }
                if (gender != null)
                {
                    SqlParameter param_g = new SqlParameter("@Gender", gender);
                    cmd.Parameters.Add(param_g);
                }
                if (salary != 0)
                {
                    SqlParameter param_s = new SqlParameter("@Salary", salary);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SearchWithDynamics()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SearchWithDynamics(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Employees where 1 = 1");

                if (firstName != null)
                {
                    stringBuilder.Append(" AND FirstName=@FirstName");
                    SqlParameter param_fn = new SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param_fn);
                }
                if (lastName != null)
                {
                    stringBuilder.Append(" AND LastName=@LastName");
                    SqlParameter param_ln = new SqlParameter("@LastName", lastName);
                    cmd.Parameters.Add(param_ln);
                }
                if (gender != null)
                {
                    stringBuilder.Append(" AND Gender=@Gender");
                    SqlParameter param_g = new SqlParameter("@Gender", gender);
                    cmd.Parameters.Add(param_g);
                }
                if (salary != 0)
                {
                    stringBuilder.Append(" AND Salary=@Salary");
                    SqlParameter param_s = new SqlParameter("@Salary", salary);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult DynamicSQLInStoredProcedure()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult DynamicSQLInStoredProcedure(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployeesGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Employees where 1 = 1");

                if (firstName != null)
                {
                    stringBuilder.Append(" AND FirstName=@FirstName");
                    SqlParameter param_fn = new SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param_fn);
                }
                if (lastName != null)
                {
                    stringBuilder.Append(" AND LastName=@LastName");
                    SqlParameter param_ln = new SqlParameter("@LastName", lastName);
                    cmd.Parameters.Add(param_ln);
                }
                if (gender != null)
                {
                    stringBuilder.Append(" AND Gender=@Gender");
                    SqlParameter param_g = new SqlParameter("@Gender", gender);
                    cmd.Parameters.Add(param_g);
                }
                if (salary != 0)
                {
                    stringBuilder.Append(" AND Salary=@Salary");
                    SqlParameter param_s = new SqlParameter("@Salary", salary);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }



        [HttpGet]
        public IActionResult SearchReviewsWithDynamics()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchReviews";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Review> model = new List<Review>();
                while (sdr.Read())
                {
                    var details = new Review();
                    details.Title = sdr["Title"].ToString();
                    details.Description = sdr["Description"].ToString();
                    details.Author = sdr["Author"].ToString();
                    details.Rating = Convert.ToInt32(sdr["Rating"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SearchReviewsWithDynamics(string title, string description, string author, int rating)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchReviews";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Reviews where 1 = 1");

                if (title != null)
                {
                    stringBuilder.Append(" AND Title=@Title");
                    SqlParameter param_t = new SqlParameter("@Title", title);
                    cmd.Parameters.Add(param_t);
                }
                if (description != null)
                {
                    stringBuilder.Append(" AND Description=@Description");
                    SqlParameter param_d = new SqlParameter("@Description", description);
                    cmd.Parameters.Add(param_d);
                }
                if (author != null)
                {
                    stringBuilder.Append(" AND Author=@Author");
                    SqlParameter param_a = new SqlParameter("@Author", author);
                    cmd.Parameters.Add(param_a);
                }
                if (rating != 0)
                {
                    stringBuilder.Append(" AND Rating=@Rating");
                    SqlParameter param_r = new SqlParameter("@Rating", rating);
                    cmd.Parameters.Add(param_r);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Review> model = new List<Review>();
                while (sdr.Read())
                {
                    var details = new Review();
                    details.Title = sdr["Title"].ToString();
                    details.Description = sdr["Description"].ToString();
                    details.Author = sdr["Author"].ToString();
                    details.Rating = Convert.ToInt32(sdr["Rating"]);
                    model.Add(details);
                }
                return View(model);
            }
        }
    }
}
