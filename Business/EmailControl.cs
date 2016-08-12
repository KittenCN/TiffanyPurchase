using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Net.Mail.SmtpClient;
using System.Net.Mail;
using BHair.Business.Table;
using BHair.Business.BaseData;
using System.Data;
using System.Data.OleDb;

namespace BHair.Business
{
    public class EmailControl
    {
        public static Users users = new Users();
        public static Business.BaseData.SetupConfig config = new BaseData.SetupConfig();
        public static string strTableName = "MailTrans";
        /// <summary>
        /// 以163邮箱发送邮件
        /// </summary>
        /// <param name="Subject">标题</param>
        /// <param name="Body">正文</param>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>发送成功</returns>
        public static bool SendEmail(string Subject, string Body, string TargetAddress)
        {
            string id = config.EmailID;
            string pwd = config.EmailPwd;
            string address = config.EmailAddress;
            string smtp = config.EmailSMTP;

            bool isSuccess = false;//是否成功发送

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Host = smtp;//使用163的SMTP服务器发送邮件
            //client.UseDefaultCredentials = true;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.Credentials = new System.Net.NetworkCredential(id, pwd);//163的SMTP服务器需要用163邮箱的用户名和密码作认证，如果没有需要去163申请个,
            //System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            //Message.From = new System.Net.Mail.MailAddress(address);//这里需要注意，163似乎有规定发信人的邮箱地址必须是163的，而且发信人的邮箱用户名必须和上面SMTP服务器认证时的用户名相同
            ////因为上面用的用户名abc作SMTP服务器认证，所以这里发信人的邮箱地址也应该写为abc@163.com
            ////Message.To.Add("123456@gmail.com");//将邮件发送给Gmail
            ////Message.To.Add("12345@qq.com");//将邮件发送给QQ邮箱
            if (TargetAddress != "")
            {
                try
                {
                    //Message.To.Add(TargetAddress);
                    //Message.Subject = Subject;
                    //Message.Body = Body;
                    //Message.SubjectEncoding = System.Text.Encoding.UTF8;
                    //Message.BodyEncoding = System.Text.Encoding.UTF8;
                    //Message.Priority = System.Net.Mail.MailPriority.High;
                    //Message.IsBodyHtml = true;

                    //users.UsersDT = users.SelectAllUsers("");
                    //client.Send(Message);
                    string strSQL2 = "insert into MailTrans(MailSubject,MailBody,MailTargetAddress,Flag) ";
                    strSQL2 = strSQL2 + " Values('" + Subject + "','" + Body + "','" + TargetAddress + "',0) ";
                    AccessHelper ah2 = new AccessHelper();
                    OleDbCommand comm2 = new OleDbCommand(strSQL2, ah2.Conn);
                    comm2.ExecuteNonQuery();
                    isSuccess = true;
                }
                catch (Exception ex1)
                {
                    if (ex1.HResult.ToString() == "-2147217865")
                    {
                        try
                        {
                            AccessHelper ah = new AccessHelper();
                            string strInSQL = "create table MailTrans(id autoincrement,MailSubject longtext,MailBody longtext,MailTargetAddress longtext,Flag int)";
                            OleDbCommand comm = new OleDbCommand(strInSQL, ah.Conn);
                            comm.ExecuteNonQuery();
                            string strSQL2 = "insert into MailTrans(MailSubject,MailBody,MailTargetAddress,Flag) ";
                            strSQL2 = strSQL2 + " Values('" + Subject + "','" + Body + "','" + TargetAddress + "',0) ";
                            AccessHelper ah2 = new AccessHelper();
                            OleDbCommand comm2 = new OleDbCommand(strSQL2, ah2.Conn);
                            comm2.ExecuteNonQuery();
                            isSuccess = true;
                        }
                        catch (Exception ex2)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 申请后发给经理
        /// </summary>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>成功</returns>
        public static bool ToApplicantSubmit2(string TransNo, string ApplicantsID, string ApplicantsName, string ApplicantsDate)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：收到内购申请");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", TransNo, ApplicantsName, ApplicantsDate);
            DataTable applications = users.SelectUsersByUID(ApplicantsID);
            DataTable ManagerInfo = users.SelectUsersByUID(applications.Rows[0]["ManagerID"].ToString());
            if (applications.Rows.Count > 0)
            {
                foreach (DataRow dr in ManagerInfo.Rows)
                {
                    if (applications.Rows[0]["ManagerID"].ToString() == dr["UID"].ToString())
                    {
                        SendEmail(Subject, Body, dr["Email"].ToString());
                        return isSuccess;
                    }
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 经理审批后发给商品部
        /// </summary>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>成功</returns>
        public static bool ToApplicantSubmit(ApplicationInfo ai)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：收到内购申请");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.TransNo, ai.ApplicantsName, ai.ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                if (dr["Character"].ToString() == "1")
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }

            return isSuccess;
        }


        /// <summary>
        /// 商品部审批后发给申请员工
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool ToEmployeeConfirm(ApplicationInfo ai)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：申请单已审核");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.TransNo, ai.ApplicantsName, ai.ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                if (dr["UID"].ToString() == ai.Applicants)
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 店面确认购买后发给商品部
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool ToFinalConfirm(ApplicationInfo ai)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：有一个内购申请已确认购买");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.TransNo, ai.ApplicantsName, ai.ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                if (dr["Character"].ToString() == "1")
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 店面确认购买后发给申请员工
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool SaleSuccess(ApplicationInfo ai)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：有一个内购申请已确认购买");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.TransNo, ai.ApplicantsName, ai.ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                if (dr["UID"].ToString() == ai.Applicants)
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 申请未审批超时提醒
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool ApplicationAlert(string TransNo, string ApplicantsName, string ApplicantsDate)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：有一个内购申请未审批");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", TransNo, ApplicantsName, ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                if (dr["Character"].ToString() == "1")
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 异常状态
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool AlertException(string TransNo, string ApplicantsName, string ApplicantsDate)
        {
            bool isSuccess = false;
            string Subject = string.Format("员工内购系统：轮询提醒异常");
            string Body = string.Format("内购申请详情：\r\n交易号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", TransNo, ApplicantsName, ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)

                SendEmail(Subject, Body, "candy.lv@longint.net");

            return isSuccess;
        }

    }


}
