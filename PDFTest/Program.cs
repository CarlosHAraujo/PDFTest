using PdfSharp.Pdf.AcroForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PdfSharp.Pdf;

namespace PDFTest
{
    public static class FieldNames
    {
        public static (string, Type) WebSite = ("website", typeof(PdfTextField));
        public static (string, Type) PdfSubmission = ("pdf_submission", typeof(PdfTextField));
        public static (string, Type) SimpleSpc = ("simple_spc", typeof(PdfTextField));
        public static (string, Type) FirstName = ("q3_name[first]", typeof(PdfTextField));
        public static (string, Type) LastName = ("q3_name[last]", typeof(PdfTextField));
        public static (string, Type) Email = ("q4_email", typeof(PdfTextField));
        public static (string, Type) AddressLine1 = ("q5_address[addr_line1]", typeof(PdfTextField));
        public static (string, Type) AddressLine2 = ("q5_address[addr_line2]", typeof(PdfTextField));
        public static (string, Type) AddressCity = ("q5_address[city]", typeof(PdfTextField));
        public static (string, Type) AddressState = ("q5_address[state]", typeof(PdfTextField));
        public static (string, Type) AddressPostal = ("q5_address[postal]", typeof(PdfTextField));
        public static (string, Type) PhoneArea = ("q6_phoneNumber[area]", typeof(PdfTextField));
        public static (string, Type) Phone = ("q6_phoneNumber[phone]", typeof(PdfTextField));
        public static (string, Type) Date = ("q7_date", typeof(PdfTextField));
        public static (string, Type) TimeHour = ("q8_time[hourSelect]", typeof(PdfComboBoxField));
        public static (string, Type) TimeMinute = ("q8_time[minuteSelect]", typeof(PdfComboBoxField));
        public static (string, Type) TimeAmPm = ("q8_time[ampm]", typeof(PdfComboBoxField));
        public static (string, Type) ThisIs = ("q9_thisIs", typeof(PdfComboBoxField));
        public static (string, Type) ThisIs10 = ("q10_thisIs10", typeof(PdfRadioButtonField));
        public static (string, Type) ThisIsOption1 = ("q11_thisIs11[Type option 1]", typeof(PdfCheckBoxField));
        public static (string, Type) ThisIsOption2 = ("q11_thisIs11[Type option 2]", typeof(PdfCheckBoxField));
        public static (string, Type) ThisIsOption3 = ("q11_thisIs11[Type option 3]", typeof(PdfCheckBoxField));
        public static (string, Type) ThisIsOption4 = ("q11_thisIs11[Type option 4]", typeof(PdfCheckBoxField));
        public static (string, Type) Submit = ("Submit", typeof(PdfPushButtonField));
    }


    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var document = PdfSharp.Pdf.IO.PdfReader.Open($"{currentPath}\\teste.pdf", PdfSharp.Pdf.IO.PdfDocumentOpenMode.Modify);

            var form = document.AcroForm;

            if (form.Elements.ContainsKey("/NeedAppearances"))
            {
                form.Elements["/NeedAppearances"] = new PdfBoolean(true);
            }
            else
            {
                form.Elements.Add("/NeedAppearances", new PdfBoolean(true));
            }

            var timeHour = (PdfComboBoxField)form.Fields[FieldNames.TimeHour.Item1];
            timeHour.SelectedIndex = 5;
            timeHour.ReadOnly = true;
            //timeHour.SelectedIndex = 1;
            //timeHour.ReadOnly = true;

            var timeMinute = (PdfComboBoxField)form.Fields[FieldNames.TimeMinute.Item1];
            timeMinute.SelectedIndex = 1;
            //timeMinute.ReadOnly = true;

            var timeAmPm = (PdfComboBoxField)form.Fields[FieldNames.TimeAmPm.Item1];
            timeAmPm.SelectedIndex = 1;
            //timeAmPm.ReadOnly = true;

            //var field = (PdfTextField)form.Fields["q3_name[first]"];
            //field.Value = new PdfSharp.Pdf.PdfString("Carlos");
            //field.ReadOnly = true;

            document.Save($"{currentPath}\\teste2.pdf");

            document.Close();

            Console.ReadKey();
        }

        private static void PrintFieldInfo(PdfAcroForm form, string key)
        {
            var addressCity = form.Fields[key];
            Console.WriteLine($"{key} typeof = {addressCity.GetType()}");
        }
    }
}
