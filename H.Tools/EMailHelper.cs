using System;
using System.Net;
using System.Net.Mail;


namespace H.Saas.Tools
{
    public class MailIfo
    {
        public string senderAddress { get; set; }

        public string receiverAddess { get; set; }

        public string subject { get; set; }

        public string body { get; set; }

        public string smtpHost { get; set; }

        public int smtpPort { get; set; }
        public string smtpPassword { get; set; }

    }
    /// <summary>
    /// 发邮件模块
    /// Author:tonyepaper.cnblogs.com
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        public bool Send(MailIfo minfo)
        {
            MailMessage mailMessage = new MailMessage(minfo.senderAddress, minfo.receiverAddess);
            mailMessage.Subject = minfo.subject;
            mailMessage.Body = minfo.body;

            SmtpClient smtpClient = new SmtpClient(minfo.smtpHost, minfo.smtpPort);
            //使用SSL加密连线
            smtpClient.EnableSsl = true;
            NetworkCredential networkCredential = new NetworkCredential(minfo.senderAddress, minfo.smtpPassword);
            smtpClient.Credentials = networkCredential;
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
