using SmartLearn.Debugging;

namespace SmartLearn
{
    public class SmartLearnConsts
    {
        public const string LocalizationSourceName = "SmartLearn";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "dd1f70f7d13043e78cdef67eca2600fd";
    }
}
