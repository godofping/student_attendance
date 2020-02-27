using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Transactions
{
    public class Sms
    {

        public DataTable List()
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from sms where smsstatus = 'PENDING' order by smsid asc";
                return methods.executeQuery(cmd);
            }

        }

        public long Insert(EL.Transactions.Sms smsEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into  sms set attendanceid = @attendanceid, message = @message, studentcontactperson = @studentcontactperson, studentcontactpersonphonenumber = @studentcontactpersonphonenumber, smsstatus = @smsstatus";

                cmd.Parameters.AddWithValue("@attendanceid", smsEL.Attendanceid);
                cmd.Parameters.AddWithValue("@message", smsEL.Message);
                cmd.Parameters.AddWithValue("@studentcontactperson", smsEL.Studentcontactperson);
                cmd.Parameters.AddWithValue("@studentcontactpersonphonenumber", smsEL.Studentcontactpersonphonenumber);
                cmd.Parameters.AddWithValue("@smsstatus", smsEL.Smsstatus);
                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Transactions.Sms smsEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update sms set smsstatus = @smsstatus where smsid = @smsid";

                cmd.Parameters.AddWithValue("@smsid", smsEL.Smsid);
                cmd.Parameters.AddWithValue("@smsstatus", smsEL.Smsstatus);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
