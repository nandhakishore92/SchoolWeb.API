namespace SchoolWeb.API.Utilities
{
	public static class NLogLoggerExtensions
	{
		private const string LogPrefix = "SchoolWeb.Api Manual Log - ";

		public static void LogTraceWithPrefix(this ILogger logger, string message, params object[] args)
		{
			logger.LogTrace(LogPrefix + message, args);
		}

		public static void LogDebugWithPrefix(this ILogger logger, string message, params object[] args)
		{
			logger.LogDebug(LogPrefix + message, args);
		}

		public static void LogInformationWithPrefix(this ILogger logger, string message, params object[] args)
		{
			logger.LogInformation(LogPrefix + message, args);
		}

		public static void LogWarningWithPrefix(this ILogger logger, string message, params object[] args)
		{
			logger.LogWarning(LogPrefix + message, args);
		}

		public static void LogErrorWithPrefix(this ILogger logger, string message, params object[] args)
		{
			logger.LogError(LogPrefix + message, args);
		}

		public static void LogErrorWithPrefix(this ILogger logger, Exception? exception, string? message, params object?[] args)
		{
			logger.Log(LogLevel.Error, exception, LogPrefix + message, args);
		}

		public static void LogCriticalWithPrefix(this ILogger logger, string message, params object[] args)
		{
			logger.LogCritical(LogPrefix + message, args);
		}
	}
}
