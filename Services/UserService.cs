
using AspNetCore.Reporting;
using Domain.Report;
using Service_Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserInfo
    {

        public UserService()
        {

        }
        public async Task<byte[]> GenerateReport()
        {
            byte[] pdfBytes = null;
            List<UserDetailDTO> userDetailLst = new List<UserDetailDTO>
            {
                new UserDetailDTO
                {
                Name = "Mark",
                Address = "Abu Dhabi,UAE",
                MobileNo = "567676777",
                StreetAddress = "Murror Road",
                UserName = "Mark"

                }
            };
            
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var report = new AspNetCore.Reporting.LocalReport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reports/UserInformation.rdlc"));

            report.AddDataSource("UserDetailsDataSet", userDetailLst);

            try
            {
                pdfBytes = report.Execute(RenderType.Pdf).MainStream;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return await Task.Run(() => pdfBytes);
        }


    }
}
