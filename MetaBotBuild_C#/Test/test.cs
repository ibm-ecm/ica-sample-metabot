/*disclaimer of warranties.
 this code is sample code created by ibm corporation. ibm grants you a
 nonexclusive copyright license to use this sample code example. this
 sample code is not part of any standard ibm product and is provided to you
 solely for the purpose of assisting you in the development of your
 applications. this example has not been thoroughly tested under all
 conditions. ibm, therefore cannot guarantee nor may you imply reliability,
 serviceability, or function of these programs. the code is provided "as is",
 without warranty of any kind. ibm shall not be liable for any damages
 arising out of your or any other parties use of the sample code, even if ibm
 has been advised of the possibility of such damages. if you do not agree with
 these terms, do not use the sample code.
 copyright ibm corp. 2019 all rights reserved.
 to run, see readme.md
 * */

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test
{
    static class test
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //project2:  read json file input, return key-vaule pairs  
            //To run it, please edit the input params according to your request
            //string configPath = "C:\\Users\\Administrator\\Desktop\\capture_config.json";
            string configPath = @"C:\Users\bcovey\Documents\Visual Studio 2017\Projects\content-analyzer-metabot\ContentAnalyzer_MetaBot\config.json";
            //string imagePath = "C:\\Users\\Administrator\\Desktop\\images_BACA\\car5.pdf";
            string imagePath = @"C:\Users\bcovey\Documents\Visual Studio 2017\Projects\content-analyzer-metabot\ContentAnalyzer_MetaBot\Facture N° F27096.pdf";
            //Make Bot call twice once for Key Value Pair
            //Once for Table
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var res = new MetaBot.SyncCapture();
            Console.WriteLine("Time To Sign in: " + sw.Elapsed);
            string resultKPV = res.MainJsonKPV(configPath, imagePath);
            Console.WriteLine("Time To Get JSON KPV: " + sw.Elapsed);
            string resultTables = res.MainJsonTables(configPath, imagePath);
            Console.WriteLine("Time To JSON Tables: " + sw.Elapsed);
            string csvKPV = res.ConvertToCSVKPV(resultKPV);
            Console.WriteLine("Time To Convert JSON to CSV for KPV: " + sw.Elapsed);
            List<string> csvTables = res.ConvertToCSVTable(resultTables);
            Console.WriteLine("Time To Convert JSON to CSV for Tables: " + sw.Elapsed);

            Console.WriteLine("------------");
            Console.WriteLine("KPV JSON");
            Console.WriteLine("------------");
            Console.WriteLine(resultKPV);
            Console.WriteLine("------------");
            Console.WriteLine("Tables JSON");
            Console.WriteLine("------------");
            Console.WriteLine(resultTables);
            Console.WriteLine("------------");
            Console.WriteLine("KPV CSV");
            Console.WriteLine("------------");
            Console.WriteLine(csvKPV);
            Console.WriteLine("------------");
            Console.WriteLine("Tables CSV");
            Console.WriteLine("------------");
            foreach (string line in csvTables)
            {
                Console.WriteLine(line);
            }
            

        }
    }
}
