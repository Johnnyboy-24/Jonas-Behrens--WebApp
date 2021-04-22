//Not functioning yet. Is to be used in Views/Home/Index.cshtml to only display a fraction of a BlodPosts Content
//Is needed so Index Out-Range Exception cant hit in Substring(), if the Content uis too short.
namespace MontiniInk.Misc
{
    public static class StringExtension
    {
        public static string Truncate(this string value, int maxLength)
        {
            if(value.Length>maxLength)
                return value.Substring(0, maxLength);
            return value;
                
        }
    }
}