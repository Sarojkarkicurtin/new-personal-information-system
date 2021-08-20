using Newtonsoft.Json;
using personal_inforamtion_system_new.Controllers;
using personal_inforamtion_system_new.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personal_inforamtion_system_new.DB
{
    public class DbConn
    {
        private string connectionString = string.Empty;

        private SqlConnection sqlcon;

        public DbConn()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();

        }
        public void createConnection()
        {
            sqlcon = new SqlConnection(connectionString);

        }

        public void SaveData(Models.PersonalInfo data, out string message)
        {
            try
            {
                createConnection();
                SqlCommand cmd = new SqlCommand("USP_Personal_Info", sqlcon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string jsondata = JsonConvert.SerializeObject(data.Addresslist);
                string edujson = JsonConvert.SerializeObject(data.Educationlist);
                cmd.Parameters.AddWithValue("@salutation", data.Salutation);
                cmd.Parameters.AddWithValue("@firstname", data.firstName);
                cmd.Parameters.AddWithValue("@lastName", data.LastName);
                cmd.Parameters.AddWithValue("@Email", data.Email);
                cmd.Parameters.AddWithValue("@Age", data.Age);
                cmd.Parameters.AddWithValue("@phonenumber ", data.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender ", data.Gender);
                cmd.Parameters.AddWithValue("@Nationality ", data.Nationality);
                cmd.Parameters.AddWithValue("@Add_Json", jsondata);
                cmd.Parameters.AddWithValue("@ADD_JSON1", edujson);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                message = "Success";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }



        }
        public void SaveallupdtaeData(Models.PersonalInfo data, out string message)
        {
            try
            {
                createConnection();
                SqlCommand cmd = new SqlCommand("updatePersonal_Info", sqlcon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string jsondata = JsonConvert.SerializeObject(data.Addresslist);
                string edujson = JsonConvert.SerializeObject(data.Educationlist);
                cmd.Parameters.AddWithValue("@personal_id", data.pid);
                cmd.Parameters.AddWithValue("@salutation", data.Salutation);
                cmd.Parameters.AddWithValue("@firstname", data.firstName);
                cmd.Parameters.AddWithValue("@lastName", data.LastName);
                cmd.Parameters.AddWithValue("@Email", data.Email);
                cmd.Parameters.AddWithValue("@Age", data.Age);
                cmd.Parameters.AddWithValue("@phonenumber ", data.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender ", data.Gender);
                cmd.Parameters.AddWithValue("@Nationality ", data.Nationality);
                cmd.Parameters.AddWithValue("@Add_Json", jsondata);
                cmd.Parameters.AddWithValue("@ADD_JSON1", edujson);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                message = "Success";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }



        }

        public List<detail> GetData()
        {
            List<detail> PersonalList = new List<detail>();
            string CS = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM personinfo", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var detail = new detail();

                    detail.Id = int.Parse(rdr["personal_id"].ToString());
                    detail.Salutation = rdr["Salutation"].ToString();
                    detail.firstName = rdr["firstName"].ToString();
                    detail.LastName = rdr["LastName"].ToString();
                    detail.Age = rdr["Age"].ToString();
                    detail.PhoneNumber = rdr["PhoneNumber"].ToString();
                    detail.Email = rdr["Email"].ToString();
                    detail.Gender = rdr["Gender"].ToString();
                    detail.Nationality = rdr["Nationality"].ToString();

                    PersonalList.Add(detail);
                }
                //return View(PersonalList);
                return PersonalList;
            }
        }
        public void Deletedata(int? id, out string message)
        {
            try
            {
                createConnection();
                SqlCommand cmd = new SqlCommand("deletepersoninfo", sqlcon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@peronal_id", id);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                message = "Success";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

        }


        public PersonalInfo Editmydata(int? id)
        {
            PersonalInfo personalInfo = new PersonalInfo();
            List<Education> EduList = new List<Education>();
            List<Address> AddList = new List<Address>();
            string CS = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Editpersonalinfo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@personal_id", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        personalInfo.pid =Convert.ToInt32(rdr["personal_id"]);
                        personalInfo.Salutation = rdr["Salutation"].ToString();
                        personalInfo.firstName = rdr["firstName"].ToString();
                        personalInfo.LastName = rdr["LastName"].ToString();
                        personalInfo.Age = rdr["Age"].ToString();
                        personalInfo.PhoneNumber = rdr["PhoneNumber"].ToString();
                        personalInfo.Email = rdr["Email"].ToString();
                        personalInfo.Gender = rdr["Gender"].ToString();
                        personalInfo.Nationality = rdr["Nationality"].ToString();

                    }
                }
                if (rdr.NextResult())
                {
                    while (rdr.Read())
                    {
                        EduList.Add(new Education { chosenEdu = rdr["chosenEdu"].ToString() });

                    }
                    personalInfo.Educationlist = EduList;
                }
                if (rdr.NextResult())
                {
                    while (rdr.Read())
                    {
                        AddList.Add(new Address
                        {
                            AddressType = rdr["AddressType"].ToString(),
                            Province = rdr["Province"].ToString(),
                            City = rdr["City"].ToString(),
                            Ward = rdr["Ward"].ToString(),
                            Tole = rdr["Tole"].ToString()
                        });

                        personalInfo.Addresslist = AddList;
                    }
                }


            }
            return personalInfo;
        }


    }


}

   