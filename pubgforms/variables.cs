using System.Threading;


namespace pubgforms
{
    static class variables
    {
        public static string tg_id {  get; set; }
        public static bool[] maps { get; set; } = new bool[9];
        public static bool Follow_Check { get; set; }
        public static int Follow_Box { get; set; }
        public static bool Line_Check { get; set; }
        public static CancellationTokenSource source;
        public static CancellationToken token;
        public static string mapping { get; set; }
        public static bool Box_30 { get; set; }
    }
}
