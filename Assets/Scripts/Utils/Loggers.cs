using System.Collections.Generic;
using CoinPackage.Debugging;

namespace Utils {
    public static class Loggers {
        public static Dictionary<LoggerType, CLogger> LoggersList;

        public enum LoggerType {
            UTILS,
            APPLICATION,
            DATA_PERSISTENCE
        }
        
        static Loggers() {
            LoggersList = new Dictionary<LoggerType, CLogger> {
                {
                    LoggerType.UTILS,
                    new CLogger(LoggerType.UTILS) {
                        LogEnabled = true
                    }
                },
                {
                    LoggerType.APPLICATION,
                    new CLogger(LoggerType.APPLICATION) {
                        LogEnabled = true
                    }
                },
                {
                    LoggerType.DATA_PERSISTENCE,
                    new CLogger(LoggerType.DATA_PERSISTENCE) {
                        LogEnabled = true
                    }
                }
            };
        }
    }
}