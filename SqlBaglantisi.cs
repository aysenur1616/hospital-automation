using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cleveland_Clinic_Project_1
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-7B0PC07\\SQLEXPRESS;Initial Catalog=ClevelandClinic;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
