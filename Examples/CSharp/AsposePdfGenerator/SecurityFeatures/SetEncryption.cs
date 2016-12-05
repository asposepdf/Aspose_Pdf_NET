using System;
using System.IO;
using Aspose.Pdf;

namespace Aspose.Pdf.Examples.CSharp.AsposePdfGenerator.SecurityFeatures
{
    public class SetEncryption
    {
        public static void Run()
        {
            // ExStart:SetEncryption
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_AsposePdfGenerator_SecurityFeatures();

            // Instantiate Pdf instance by calling its empty constructor
            Aspose.Pdf.Generator.Pdf pdf1 = new Aspose.Pdf.Generator.Pdf();

            // Assign a security instance to Pdf object
            pdf1.Security = new Aspose.Pdf.Generator.Security();

            // Set encryption level to 128 bits
            pdf1.Security.Is128BitsEncrypted = true;

            // Add a section in the Pdf
            Aspose.Pdf.Generator.Section sec1 = pdf1.Sections.Add();

            // Create a text paragraph                           
            Aspose.Pdf.Generator.Text text1 = new Aspose.Pdf.Generator.Text(sec1,"this is text content");

            // Set the top maring of text paragraph to 30
            text1.Margin.Top = 30;

            // Add the text paragraph to the section
            sec1.Paragraphs.Add(text1);

            dataDir = dataDir + "SetEncryption_out.pdf";
            // Save the Pdf                           
            pdf1.Save(dataDir);
            // ExEnd:SetEncryption           
        }
    }
}