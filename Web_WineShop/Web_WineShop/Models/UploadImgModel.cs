using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Web_WineShop.Models
{
	public class UploadImgModel
	{
		static List<string> validExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".pdf" };
		public async static Task<List<String>> Upload(List<IFormFile> files)
		{
			List<String> result = new List<string>(files.Count);
			foreach (IFormFile file in files)
			{
				if (!validExtensions.Contains(Path.GetExtension(file.FileName)))
				{
					throw new NotSupportedException("Invalid file type.");
				}
				var filePath = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);
				filePath = Path.Combine("img", filePath);

				using (var stream = System.IO.File.Create(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath)))
				{
					await file.CopyToAsync(stream);
				}
				result.Add(filePath);

			}
			return result;
		}
	}
}
