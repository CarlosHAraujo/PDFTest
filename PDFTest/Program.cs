using System;
using System.Collections;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;

namespace PDFTest
{
    public static class FieldNames
    {
        public static string WebSite = "website";
        public static string PdfSubmission = "pdf_submission";
        public static string SimpleSpc = "simple_spc";
        public static string FirstName = "q3_name[first]";
        public static string LastName = "q3_name[last]";
        public static string Email = "q4_email";
        public static string AddressLine1 = "q5_address[addr_line1]";
        public static string AddressLine2 = "q5_address[addr_line2]";
        public static string AddressCity = "q5_address[city]";
        public static string AddressState = "q5_address[state]";
        public static string AddressPostal = "q5_address[postal]";
        public static string PhoneArea = "q6_phoneNumber[area]";
        public static string Phone = "q6_phoneNumber[phone]";
        public static string Date = "q7_date";
        public static string TimeHour = "q8_time[hourSelect]";
        public static string TimeMinute = "q8_time[minuteSelect]";
        public static string TimeAmPm = "q8_time[ampm]";
        public static string ThisIs = "q9_thisIs";
        public static string ThisIs10 = "q10_thisIs10";
        public static string ThisIsOption1 = "q11_thisIs11[Type option 1]";
        public static string ThisIsOption2 = "q11_thisIs11[Type option 2]";
        public static string ThisIsOption3 = "q11_thisIs11[Type option 3]";
        public static string ThisIsOption4 = "q11_thisIs11[Type option 4]";
        public static string Submit = "Submit";
    }


    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string template = $"{currentPath}\\teste.pdf";
            string finalArchive = $"{currentPath}\\final.pdf";


            //using (var finalFile = new FileStream(finalArchive, FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    var reader = new PdfReader(template);

            //    var copy = new PdfCopyFields(finalFile, PdfWriter.VERSION_1_4);
            //    copy.AddDocument(reader);
            //    copy.Close();
            //}
























            using (var stream = new FileStream(finalArchive, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var reader = new PdfReader(template);

                var stamper = new PdfStamper(reader, stream);

                var fields = stamper.AcroFields;

                fields.SetField(FieldNames.AddressCity, "Sete Lagoas");

                //var item = fields.GetFieldItem(FieldNames.AddressCity);
                //item.values = new ArrayList() { "Sete Lagoas" };
                //fields.Fields[FieldNames.AddressCity] = item;

                stamper.FormFlattening = true;

                stamper.AcroFields.GenerateAppearances = true;
                
                reader.Close();
                stamper.Close();
            }

















            //if (form.Elements.ContainsKey("/NeedAppearances"))
            //{
            //    form.Elements["/NeedAppearances"] = new PdfBoolean(true);
            //}
            //else
            //{
            //    form.Elements.Add("/NeedAppearances", new PdfBoolean(true));
            //}

            //var timeHour = form.Fields
            //timeHour.SelectedIndex = 5;
            //timeHour.ReadOnly = true;
            ////timeHour.SelectedIndex = 1;
            ////timeHour.ReadOnly = true;

            //var timeMinute = (PdfComboBoxField)form.Fields[FieldNames.TimeMinute.Item1];
            //timeMinute.SelectedIndex = 1;
            ////timeMinute.ReadOnly = true;

            //var timeAmPm = (PdfComboBoxField)form.Fields[FieldNames.TimeAmPm.Item1];
            //timeAmPm.SelectedIndex = 1;
            ////timeAmPm.ReadOnly = true;

            //var field = (PdfTextField)form.Fields["q3_name[first]"];
            //field.Value = new PdfSharp.Pdf.PdfString("Carlos");
            //field.ReadOnly = true;

            //document.Save($"{currentPath}\\teste2.pdf");

            Console.ReadKey();
        }
    }
}
