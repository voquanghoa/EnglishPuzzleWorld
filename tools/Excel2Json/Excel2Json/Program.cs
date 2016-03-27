using Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Excel2Json
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Usage: <program> <excel file>");
				return;
			}

			var excelFileName = args[0];
			var directory = Path.GetDirectoryName(excelFileName);
			var jsonFileName = Path.Combine(directory, Path.GetFileNameWithoutExtension (excelFileName) + ".json");

			Data data = new Data();
			foreach (var sheet in Workbook.Worksheets(args[0]))
			{
				foreach (var row in sheet.Rows)
				{
					var question = row.Cells[1].Text;
					var answer = row.Cells[2].Text;
					var categoryName = row.Cells[3].Text;

					var category = data.FirstOrDefault(x => x.Name == categoryName);

					if (category == null)
					{
						category = new Category();
						category.Name = categoryName;
						data.Add(category);
					}

					category.Questions.Add(new Question()
					{
						Answer = answer,
						Title= question
					});
				}	
			}

			File.WriteAllText(jsonFileName, JsonConvert.SerializeObject(data));
			
		}
	}
}
