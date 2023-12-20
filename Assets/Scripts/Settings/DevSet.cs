using UnityEngine;
using Utils;
using Utils.Singleton;

namespace Settings {
    [RequireComponent(typeof(DoNotDestroy))]
    public class DevSet : Singleton<DevSet> {
        public AppSettingsDefinition appSettings;
        public DefaultSaveDataDefinition defSaveData;
    }   
}