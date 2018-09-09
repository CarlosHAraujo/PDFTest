using PdfSharp.Pdf.AcroForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PDFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var document = PdfSharp.Pdf.IO.PdfReader.Open($"{currentPath}\\teste.pdf", PdfSharp.Pdf.IO.PdfDocumentOpenMode.Modify);

            var form = document.AcroForm;

            if (form.Elements.ContainsKey("/NeedAppearances"))
            {
                form.Elements["/NeedAppearances"] = new PdfSharp.Pdf.PdfBoolean(true);
            }
            else
            {
                form.Elements.Add("/NeedAppearances", new PdfSharp.Pdf.PdfBoolean(true));
            }

            var field = (PdfTextField)form.Fields["q3_name[first]"];
            field.Value = new PdfSharp.Pdf.PdfString("Carlos");
            field.ReadOnly = true;

            document.Save($"{currentPath}\\teste2.pdf");

            document.Close();

            Console.ReadKey();
        }
    }
}
