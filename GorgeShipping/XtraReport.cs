using System;
using DevExpress.XtraReports.UI;

namespace GorgeShipping
{
    public partial class XtraReport
    {
        public XtraReport()
        {
            InitializeComponent();
        }

        public void InitData (string Name,string AddressDetail, string District, string Province, string Code, string TelNumber)
        {
            pName.Value = Name;
            pAddr.Value = AddressDetail;
            pDistrict.Value = District;
            pProvince.Value = Province;
            pCode.Value = Code;
            pPhone.Value = TelNumber;
        }

        private void XtraReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
