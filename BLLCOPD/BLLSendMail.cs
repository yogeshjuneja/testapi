using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BLLCOPD
{
  public  class BLLSendMail
    {
        public void SendMail(string strMailTo, string strMailBody, string strSubject)
        {
            string MailFrom = "admin@abc.co.in";
            string Password = "aaa";
            Boolean EnableSsl = Convert.ToBoolean("true");
            string strSMTP = "smtp.gmail.com";
            using (MailMessage mail = new MailMessage())
            {
                string[] to = strMailTo.Split(',');
                if (to.Length > 0)
                {
                    for (int row = 0; row < to.Length; row++)
                    {
                        if (Regex.IsMatch(to[row].ToString(), @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                        {
                            mail.To.Add(new System.Net.Mail.MailAddress(to[row]));
                        }
                    }
                    // mail.Bcc.Add("cmsworkorder@gmail.com");
                    mail.IsBodyHtml = true;
                    mail.From = new System.Net.Mail.MailAddress(MailFrom);
                    mail.Subject = strSubject;
                    mail.Body = strMailBody;

                    SmtpClient smtpClnt = new SmtpClient(strSMTP, 587);
                    smtpClnt.UseDefaultCredentials = EnableSsl;
                    smtpClnt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClnt.EnableSsl = true;
                    smtpClnt.Credentials = new System.Net.NetworkCredential(MailFrom, Password);
                    smtpClnt.Timeout = int.MaxValue;
                    smtpClnt.Send(mail);
                }
            }
        }
        public void SendEmail(string msgTo, string msgCC, string msgBcc, string msgSubject, string msgBody)
        {
            bool SentFlag = false;
            MailMessage msg = new MailMessage();
            SmtpClient Client = new SmtpClient();
            try
            {
                msgTo = msgTo.Replace("\n", "");
                msgTo = msgTo.Replace(";", ",");
                msg.To.Add(msgTo);
                if (msgCC != "")
                {
                    msgCC = msgCC.Replace("\n", "");
                    msgCC = msgCC.Replace(";", ",");
                    msg.CC.Add(msgCC);
                }
                msg.Subject = msgSubject;
                msg.Body = msgBody;
                msg.Priority = MailPriority.Normal;
                msg.IsBodyHtml = true;
                msg.From = new MailAddress("automailer@emeditek.in");
                Client.Host = "192.168.1.201";
                Client.Port = 25;
                Client.UseDefaultCredentials = true;
                Client.Credentials = new NetworkCredential("automailer@emeditek.in", "Roj@4778$uv");
                try
                {
                    Client.Send(msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable)
                    {
                        System.Threading.Thread.Sleep(5000);
                        Client.Send(msg);
                        SentFlag = true;
                    }
                }
            }
            catch (FormatException ex)
            {
                SentFlag = false;
            }
            finally
            {
                msg.Dispose();
            }
            //return SentFlag;     

        }


        public void SMSSend(string strMobile, String strMsg, string strSender = "AAA")
        {
            WebClient client = new WebClient();
            string baseurl = "http://www.smsjust.com/blank/sms/user/urlsms.php?username=emeditek&pass=Emeditek@577&senderid=EMWLNS&dest_mobileno=" + strMobile + "&message=" + strMsg + "&response=Y";
                        
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }
    }
}
