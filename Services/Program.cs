using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Services
{
    internal class Program
    {
        static void PrintWithColor(string message, ConsoleColor color)
        {
            ConsoleColor initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = initialColor;
        }
        
        static void PrintErrorInfo(string errorInfo)
        {
            PrintWithColor(errorInfo + '\n', ConsoleColor.Red);
        }

        static void PrintDataSet(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                DataColumnCollection columns = table.Columns;
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in columns)
                    {
                        string columnName = column.ColumnName;
                        Console.Write($"{columnName}: ");
                        PrintWithColor($"{row[columnName]}\t", ConsoleColor.Cyan);
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                try
                {
                    sqlHelper.Connect("10.21.138.186", "sa", "94254694");
                    Console.WriteLine("Connection Opened!\nCommand:");
                    DataSet result = sqlHelper.Query(Console.ReadLine());
                    // SELECT * FROM StudentCourse.dbo.Student
                    PrintDataSet(result);
                } catch (SqlException ex)
                {
                    PrintErrorInfo(ex.ToString());
                }
            }
            Console.WriteLine("Connection Closed!");
            Console.ReadLine();
        }
    }
}
