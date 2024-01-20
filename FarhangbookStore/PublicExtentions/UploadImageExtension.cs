namespace FarhangbookStore.PublicExtentions
{
    public class UploadImageExtension
    {
        public static string CreateImage(IFormFile file)
        {
            try
            {
                string imgname = FileGeneratCode.GuidCode() + Path.GetExtension(file.FileName);
                string Pathimg = Path.Combine(Directory.GetCurrentDirectory(), "/Admin/images/upload/bookImage/normalImage", imgname);
                string Pathimgthumb = Path.Combine(Directory.GetCurrentDirectory(), "/Admin/images/upload/bookImage/thumbnailimage", imgname);

                string imagesecurity = file.ImageSecurity();

                if (imagesecurity == "false")
                    return "false";

                using (var stream = new FileStream(Pathimg, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                ExtentionConvertImage convert = new ExtentionConvertImage();
                convert.Image_resize(Pathimg, Pathimgthumb, 400, 500);

                return imgname;
            }
            catch (Exception)
            {
                return "false";
            }

        }

        public static bool DeleteImg(string path, string imagename)
        {
            try
            {
                string FullPath = Path.Combine(Directory.GetCurrentDirectory(), "/Admin/images/upload/bookImage/normalImage/" + path + "/" + imagename);
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
