namespace Autoclicker.clicker;

public static class ClickerData
{
    public static class LeftClicker
    {
        public static double OldCps { get; set;}
        public static double OldCpsMs { get; set; }
        public static double OldLowerCpsMs { get; set; }
        public static double OldUpperCpsMs { get; set; }
        public static double LessMs { get; set; }
        public static double MoreMs { get; set; }
        public static double Probability { get; set; }
        public static double DropMs { get; set; }
        public static double LowerBound { get; set; }
        public static double UpperBound { get; set; }
        public static string OldPriority { get; set; }
    }

    public static class RightClicker
    {
        public static double OldCps { get; set; }
        public static double OldCpsMs { get; set; }
        public static double OldLowerCpsMs { get; set; }
        public static double OldUpperCpsMs { get; set; }
        public static double LowerBound { get; set; }
        public static double UpperBound { get; set; }
        public static double DropMs { get; set; }
        public static double Probability { get; set; }
        public static double MoreMs { get; set; }
        public static double LessMs { get; set; }
        public static string OldPriority { get; set; }

    }
}