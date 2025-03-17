

namespace Global{
    public static class Logger{
        public const int FILE_NOT_FOUND = -1;
        public const int INVALID_TOKEN = -2;
        public const int MISSING_TOKEN = -3;
        public const int INVALID_OPERATOR = -4;
        public const int INVALID_SYNTAX = -5;
        public static void Error(string? mes, int EC = 0){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mes + ", error code: "+EC);
            Console.ForegroundColor = ConsoleColor.White;
           // Environment.Exit(EC);
        }
    }
}