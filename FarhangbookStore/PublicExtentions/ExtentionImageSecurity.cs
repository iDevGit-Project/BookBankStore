namespace FarhangbookStore.PublicExtentions
{
    public static class ExtentionImageSecurity
    {
        public static string ImageSecurity(this IFormFile file)
        {
            try
            {
                System.Drawing.Image.FromStream(file.OpenReadStream());
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }
    }
}
