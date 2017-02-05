using System;
using System.CodeDom.Compiler;
using Microsoft.Practices.Unity;
using ShelfPriceCounting.Bootstrapping;
using ShelfPriceCounting.Business;

namespace ShelfPriceCounting.UI
{
	static class Program
	{
		static void Main()
		{
			//IoC container with registered dependencies
			var unityContainer = new Bootstrapper().Bootstrap();
			//resolved ReceiptService
			var receiptService = unityContainer.Resolve<ReceiptService>();
			

			var receipts = receiptService.GetReceipts();

			foreach (var receipt in receipts)
			{
				using (var writer = new IndentedTextWriter(Console.Out, "    "))
				{
					Console.SetOut(writer);
					writer.Indent = 0;
					writer.WriteLine(String.Format("Output {0}:", receipt.Id + 1));
					writer.Indent = 1;
					foreach (var product in receipt.Products)
					{
						writer.WriteLine(string.Format("{0} {1}: {2}", product.Count, product.Name, product.Price));
					}
					
					writer.WriteLine(string.Format("Sales Taxes: {0}", receipt.TotalTax));
					writer.WriteLine(string.Format("Total: {0}", receipt.TotalPrice));

					writer.Indent = 0;
				}				
			}

			Console.ReadLine();
		}
	}
}
