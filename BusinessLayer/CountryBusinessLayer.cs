using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CountryBusinessLayer
    {
        #region GET Countries
        public IEnumerable<Country> Countries 
        { 
            get
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    List<Country> countries = new List<Country>();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("sp_tblCountry_getCountries", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Country country = new Country();
                            if (!(rdr["CountryIDP"] is DBNull))
                            {
                                country.Id = Convert.ToInt32(rdr["CountryIDP"]);
                            }
                            country.Name = rdr["CountryName"].ToString();
                            countries.Add(country);
                        }
                        conn.Close();
                    }
                    return countries;
                }
                catch(Exception ex)
                {
                    ex.Message.ToString();
                    return null;
                }
            }
        }
        #endregion GET Countries
    }
}
