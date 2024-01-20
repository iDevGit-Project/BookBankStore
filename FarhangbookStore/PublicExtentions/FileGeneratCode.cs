namespace FarhangbookStore.PublicExtentions
{
    public class FileGeneratCode
    {
        public static string GuidCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
