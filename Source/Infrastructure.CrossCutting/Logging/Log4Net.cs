using log4net;
using log4net.Config;
using System;
using System.Globalization;

namespace Infrastructure.CrossCutting.Logging
{
    public class Log4Net : ILogger
    {
        #region Members

        readonly ILog _source;

        #endregion

        #region  Constructor

        /// <summary>
        /// Create a new instance of this trace manager
        /// </summary>
        public Log4Net()
        {
            // Create default source
            _source = LogManager.GetLogger("SigcomtFramework");
        }

        #endregion

        #region ILogger Members

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Info(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                _source.Info(messageToTrace);
            }
        }
        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Warning(string message, params object[] args)
        {

            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                _source.Warn(messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Error(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                _source.Error(messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="exception"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Error(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString(); // The ToString() create a string representation of the current exception

                _source.Error(string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Debug(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                _source.Debug(messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="exception"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Debug(string message, Exception exception,params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString(); // The ToString() create a string representation of the current exception

                _source.Debug(string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="item"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Debug(object item)
        {
            if (item != null)
            {
                _source.Debug(item.ToString());
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        public void Fatal(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                _source.Fatal(messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Infrastructure.CrossCutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="exception"><see cref="Infrastructure.CrossCutting.Logging.ILogger"/></param>
        /// <param name="args">Argumentos</param>
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString();
                    // The ToString() create a string representation of the current exception

                _source.Fatal(string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace,
                    exceptionData));
            }
        }

        #endregion
    }

    public static class Log4NetConfigurator
    {
        public static void Configure()
        {
            XmlConfigurator.Configure();
        }
    }
}
