using ABPCommerce.Debugging;

namespace ABPCommerce
{
    public class ABPCommerceConsts
    {
        public const string LocalizationSourceName = "ABPCommerce";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d392a7bb78e545e389994b04ad21efdf";
    }
}
