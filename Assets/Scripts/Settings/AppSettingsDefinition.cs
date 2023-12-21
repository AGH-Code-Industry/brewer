using UnityEngine;

namespace Settings {
    [CreateAssetMenu(menuName = "Settings/AppSettings", fileName = "AppSettings")]
    public class AppSettingsDefinition : ScriptableObject {
        [Header("Scene names")]
        [Tooltip("Scene to load after loading game")]
        public string firstSceneName = "MainMenu";
        
        [Tooltip("Main menu scene")]
        public string mainMenuSceneName = "MainMenu";

        [Tooltip("Game manager scene name")]
        public string gameManagerSceneName = "Game";
        
        [Tooltip("Scene with player's 'house', where mixing and selling takes place.")]
        public string dormitorySceneName = "_placeholder";
        
        [Tooltip("Scene where player gathers resources, farms etc.")]
        public string townSceneName = "_placeholder";


        [Header("Resource paths")]
        public string itemsResPath = "Items";

        
        [Header("Data Persistence")]
        public string defaultSaveName;
    }   
}
