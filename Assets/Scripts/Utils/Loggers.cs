using System.Collections.Generic;
using CoinPackage.Debugging;

namespace Utils {
    public static class Loggers {
        public static Dictionary<LoggerType, CLogger> LoggersList;

        public enum LoggerType {
            UTILS,
            APPLICATION,
            DATA_PERSISTENCE,
            INVENTORY,
            DIALOGUES,
            RECIPES
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
                },
                {
                    LoggerType.INVENTORY,
                    new CLogger(LoggerType.INVENTORY) {
                        LogEnabled = true
                    }
                },
                {
                    LoggerType.DIALOGUES,
                    new CLogger(LoggerType.DIALOGUES) {
                        LogEnabled = true
                    }
                },
                {
                    LoggerType.RECIPES,
                    new CLogger(LoggerType.RECIPES) {
                        LogEnabled = true
                    }
                }
            };
        }
    }
}