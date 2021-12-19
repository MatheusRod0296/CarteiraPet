using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Events;
using Serilog.Parsing;

namespace CarteiraPet.Commom.extensions
{
    public static class LoggerExtensions
    {
        public static void Important(
            this ILogger logger,
            string messageTemplate,
            params object[] args)
        {
            logger.ForContext("IsImportant", true)
                .Information(messageTemplate, args);
        }
        
        public static void Logtrace(
            this ILogger logger,
            TraceCustomLog logObj)
        {
            var dict = new LogEventProperty( "Message", new ScalarValue(logObj.Message));
            var dict2 = new LogEventProperty( "IsImportant", new ScalarValue(logObj.IsImportant));
            var dict3 = new LogEventProperty( "ConnectionId", new ScalarValue(logObj.ConnectionId));
            
            var properties = new List<LogEventProperty>() { dict, dict2 , dict3};

            var text = new MessageTemplate(logObj.Message,  new List<MessageTemplateToken>());

            logger.ForContext("connectionId", logObj.ConnectionId, false)
                .Write(LogEventLevel.Information, logObj.Message + "2", new LogEvent(DateTimeOffset.Now, LogEventLevel.Information, null, text ,properties ));
        }
    }
    
    public class TraceCustomLog
    {
        public TraceCustomLog(string connectionId, bool isImportant, string message)
        {
            ConnectionId = connectionId;
            IsImportant = isImportant;
            Message = message;
        }

        public string ConnectionId { get;  set; }
        public bool IsImportant { get;  set; }
        public string Message { get;  set; }
    }
}