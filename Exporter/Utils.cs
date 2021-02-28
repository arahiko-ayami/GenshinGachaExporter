using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models.GachaLogModels;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace Exporter
{
    public static class Utils
    {
        public static string GetGameLocation()
        {
            string gameLocation = null;
            try
            {
                var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                gameLocation = String.Concat(userPath, "/AppData/LocalLow/miHoYo/Genshin Impact/output_log.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Can't read your gacha data, please close the game and try again!");
            }

            return gameLocation;
        }

        public static string GetJson(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var jsonData = String.Empty;
                try
                {
                    jsonData = webClient.DownloadString(url);
                }
                catch (Exception)
                {
                    // ignored
                }

                return jsonData;
            }
        }

        public static void WriteJsonFile(string json, string name)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"json_files";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(path + @"\" + name + ".json", json);
        }

        public static void WriteExcelFile(List<List> list, string name)
        {
            var date = (DateTime.Now).ToString("dd/MM/yyyy").Replace("/", "");
            var time = DateTime.Now.ToString("hh:mm:ss").Replace(":", "");
            var fileName = "GenshinGachaLog_" + name + "_" + date + time;
            string path = AppDomain.CurrentDomain.BaseDirectory + @"excel_files";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add(name);
                var headerRow = new List<string[]>()
                {
                    new string[] {"Time", "Name", "Item Type", "Rank Type"}
                };

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                var t = typeof(List);
                var workSheet = excel.Workbook.Worksheets[name];
                workSheet.Cells[headerRange].LoadFromArrays(headerRow);
                workSheet.Cells[headerRange].Style.Font.Bold = true;
                workSheet.Cells[4, 2].Style.Numberformat.Format = "0";
                
                workSheet.Cells[2, 1].LoadFromCollection(list, false, TableStyles.None, BindingFlags.Default, new MemberInfo[]
                {
                    t.GetProperty("time"),
                    t.GetProperty("name"),
                    t.GetProperty("item_type"),
                    t.GetProperty("rank_type")
                });

                for (int i = 2; i < list.Count+2; i++)
                {
                    if (workSheet.Cells[i, 4].Value is string)
                    {
                        workSheet.Cells[i, 4].Value = int.Parse((string) workSheet.Cells[i, 4].Value);
                    }
                }
                
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                workSheet.Cells[workSheet.Dimension.Address].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                FileInfo excelFile = new FileInfo(path + @"\" + fileName + ".xlsx");
                excel.SaveAs(excelFile);
            }
        }
    }
}