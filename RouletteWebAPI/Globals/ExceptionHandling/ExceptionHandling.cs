using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebAPI.Globals.ExceptionHandling
{
    public class ExceptionHandling
    {
        //public static Boolean HandleAndCreateExceptionMessageUsing(
        // String message, Exception exception, String processName, String batchReference, String sourceIdentifier, String serviceId = default(String), String canonicalId = default(String), String globalId = default(String), SeverityLevels severity = SeverityLevels.Critical)
        //{
        //    if (message == null) throw new ArgumentNullException(nameof(message));
        //    if (exception == null) throw new ArgumentNullException(nameof(exception));
        //    if (String.IsNullOrWhiteSpace(processName)) throw new ArgumentException(nameof(processName));
        //    if (String.IsNullOrWhiteSpace(sourceIdentifier)) throw new ArgumentException(nameof(sourceIdentifier));
        //    if (serviceId == null) serviceId = RootService.InstanceId.ToString();

        //    var additionalProperties = new Dictionary<String, String>()
        //    {
        //        { "ErrorReference", ErrorReference }
        //    };

        //    var result = HandleCreateAndLoadIntoUsing(
        //        message, exception, Globals.ApplicationName, processName, sourceIdentifier, default(String), default(String),
        //        serviceId, canonicalId, globalId, additionalProperties, severity);

        //    return result;
        //}
    }
}
