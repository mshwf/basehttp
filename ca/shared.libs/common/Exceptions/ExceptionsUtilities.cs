using System;
using System.Text;

namespace GET.PKI.Common
{
    public static class ExceptionsUtilities
    {
        /// <summary>
        /// Gets the most not-null inner exception
        /// </summary>
        /// <param name="ex">The potentially-parent exception</param>
        /// <returns>Exception without InnerException</returns>
        public static Exception GetInner(this Exception ex) => ex.InnerException?.GetInner() ?? ex;
        /// <summary>
        /// Get all messages of the exception and its inner exceptions
        /// </summary>
        /// <param name="ex">The top exception</param>
        /// <param name="msgs"></param>
        /// <returns>A string containing all messages in the exception and its inner exceptions</returns>
        public static string GetExceptionMessages(this Exception ex, StringBuilder msgs = null)
        {
            
            if (ex == null) return string.Empty;
            if (msgs == null)
            {
                msgs = new StringBuilder();
                msgs.AppendLine($" - {ex.Message}");
            }
            if (ex.InnerException != null)
                msgs.AppendLine(GetExceptionMessages(ex.InnerException));
            return msgs.ToString();
        }
    }
}
