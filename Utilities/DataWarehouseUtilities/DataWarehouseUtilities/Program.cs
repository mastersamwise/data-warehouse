// See https://aka.ms/new-console-template for more information
using System;

namespace DataWarehouseUtilities
{
    public class Program
    {


        static void Main(string[] args)
        {
            string file1 = @"Resources/Pokemon.xlsx";
            string file2 = @"C:\Users\Nik\Git_Repos\data-warehouse\Utilities\DataWarehouseUtilities\DataWarehouseUtilities\Resources\Pokemon.xlsx";

            string EXCEL_FILE = file2;

            FileInfo directory = new FileInfo(EXCEL_FILE);

            Console.WriteLine("Hello World!\n");

            if (directory.IsReadOnly)
            {
                Console.WriteLine("File is readonly, changing to not be readonly \n\n");
                directory.IsReadOnly = false;
                Console.WriteLine("Is readonly: " + directory.IsReadOnly + " \n\n");
            }

            Console.WriteLine("\n\n" + directory.FullName + "\n\n");

            ExcelReader reader = new ExcelReader();
            //reader.CheckColumnsWithSylvan(EXCEL_FILE);
            //reader.ReadFileWithSylvan(EXCEL_FILE);
            reader.ReadFileWithInterop(EXCEL_FILE);

        }
    }
}
