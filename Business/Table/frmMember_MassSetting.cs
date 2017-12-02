using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BHair.Business.Table
{
    public class frmMember_MassSetting
    {
        public static DataTable dt = null;
        public frmMember_MassSetting()
        { }

        public int intMassStore(string ID,string Store)
        {
            int intResult = 0;
            try
            {
                string strSQL = "update Users set Store='" + Store + "' where ID=" + ID + " ";
                AccessHelper ah = new AccessHelper();
                intResult = ah.ExecuteNonQuery(strSQL);
            }
            catch(Exception)
            {
                intResult = 0;
            }
            return intResult;
        }

        public int intMassFrozen(string ID, int AbleMode)
        {
            int intResult = 0;
            try
            {
                string strSQL = "update Users set IsAble=0,AbleMode=" + AbleMode + " where ID=" + ID + " ";
                AccessHelper ah = new AccessHelper();
                intResult = ah.ExecuteNonQuery(strSQL);
            }
            catch (Exception ex)
            {
                intResult = 0;
            }
            return intResult;
        }
    }
}
