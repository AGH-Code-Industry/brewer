using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Utils.Singleton;

namespace MainMenu {
    public class MainMenuManager : Singleton<MainMenuManager> {
        [Header("Buttons")] 
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button quitButton;

        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.APPLICATION];

        protected override void Awake() {
            base.Awake();
            newGameButton.onClick.AddListener(OnNewGame);
            continueButton.onClick.AddListener(OnContinue);
            optionsButton.onClick.AddListener(OnOptions);
            quitButton.onClick.AddListener(OnQuit);
        }

        private void OnNewGame() {
            SceneManager.LoadScene(DevSet.I.appSettings.dormitorySceneName, LoadSceneMode.Single);
        }
        
        private void OnContinue(){_logger.LogWarning($"Option {"Continue" % Colorize.Red} is not yet implemented.");}
        private void OnOptions(){_logger.LogWarning($"Option {"Options" % Colorize.Red} is not yet implemented.");}
        private void OnQuit() { UnityEngine.Application.Quit(); }
    }
}