namespace BlazorApp1.NewFolder
{
    //made by Rayyan
    public class CitiesRepository
    {
        private static List<string> cities =new List<string>()
        {
            "Toronto",
            "Montreal",
            "Ottawa",
            "Calgary",
            "Halifax"
        };

        public static List<string> GetCities() => cities;
    }
}
