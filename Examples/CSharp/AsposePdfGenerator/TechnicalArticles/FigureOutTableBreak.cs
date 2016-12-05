using System;
using System.IO;
using Aspose.Pdf;

namespace Aspose.Pdf.Examples.CSharp.AsposePdfGenerator.TechnicalArticles
{
    public class FigureOutTableBreak
    {
        public static void Run()
        {
            // ExStart:FigureOutTableBreak
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_AsposePdfGenerator_TechnicalArticles();

            // Instantiate an object PDF class
            Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
            // Add the section to PDF document sections collection
            Aspose.Pdf.Generator.Section section = pdf.Sections.Add();
            // Instantiate a table object
            Aspose.Pdf.Generator.Table table1 = new Aspose.Pdf.Generator.Table();
            table1.Margin.Top = 300;
            // Add the table in paragraphs collection of the desired section
            section.Paragraphs.Add(table1);
            // Set with column widths of the table
            table1.ColumnWidths = "100 100 100";
            // Set default cell border using BorderInfo object
            table1.DefaultCellBorder = new Aspose.Pdf.Generator.BorderInfo((int)Aspose.Pdf.Generator.BorderSide.All, 0.1F);
            // Set table border using another customized BorderInfo object
            table1.Border = new Aspose.Pdf.Generator.BorderInfo((int)Aspose.Pdf.Generator.BorderSide.All, 1F);
            // Create MarginInfo object and set its left, bottom, right and top margins
            Aspose.Pdf.Generator.MarginInfo margin = new Aspose.Pdf.Generator.MarginInfo();
            margin.Top = 5f;
            margin.Left = 5f;
            margin.Right = 5f;
            margin.Bottom = 5f;
            // Set the default cell padding to the MarginInfo object
            table1.DefaultCellPadding = margin;
            // If you increase the counter to 17, table will break 
            // Because it cannot be accommodated any more over this page
            for (int RowCounter = 0; RowCounter <= 16; RowCounter++)
            {
                // Create rows in the table and then cells in the rows
                Aspose.Pdf.Generator.Row row1 = table1.Rows.Add();
                row1.Cells.Add("col " + RowCounter.ToString() + ", 1");
                row1.Cells.Add("col " + RowCounter.ToString() + ", 2");
                row1.Cells.Add("col " + RowCounter.ToString() + ", 3");
            }
            // Get the Page Height information
            float PageHeight = pdf.PageSetup.PageHeight;
            // Get the total height information of Page Top & Bottom margin, table Top margin and table height.
            float TotalObjectsHeight = section.PageInfo.Margin.Top + section.PageInfo.Margin.Bottom + table1.Margin.Top + table1.GetHeight(pdf);

            // Display Page Height, Table Height, table Top margin and Page Top and Bottom margin information
            Console.WriteLine("PDF document Height = " + pdf.PageSetup.PageHeight.ToString() + "\nTop Margin Info = " + section.PageInfo.Margin.Top.ToString() + "\nBottom Margin Info = " + section.PageInfo.Margin.Bottom.ToString() + "\n\nTable-Top Margin Info = " + table1.Margin.Top.ToString() + "\nAverage Row Height = " + table1.Rows[0].GetHeight(pdf).ToString() + " \nTable height " + table1.GetHeight(pdf).ToString() + "\n ----------------------------------------" + "\nTotal Page Height =" + PageHeight.ToString() + "\nCummulative height including Table =" + TotalObjectsHeight.ToString());

            // Check if we deduct the sume of Page top margin + Page Bottom margin + Table Top margin and table height from Page height and its less
            // Than 10 (an average row can be greater than 10)
            if ((PageHeight - TotalObjectsHeight) <= 10)
                // If the value is less than 10, then display the message. 
                // Which shows that another row can not be placed and if we add new 
                // Row, table will break. It depends upon the row height value.
                Console.WriteLine("Page Height - Objects Height < 10, so table will break");
            // Save the pdf document
            pdf.Save(dataDir + "FigureOutTableBreak_out.pdf");
            // ExEnd:FigureOutTableBreak           
        }
    }
}