using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using DataPersistence;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Utils.Singleton;

namespace MainMenu {
    public class MainMenuManager : MonoBehaviour {
        [Header("Buttons")] 
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button craftingButton;

        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.APPLICATION];

        private void Awake() {
            newGameButton.onClick.AddListener(OnNewGame);
            continueButton.onClick.AddListener(OnContinue);
            optionsButton.onClick.AddListener(OnOptions);
            quitButton.onClick.AddListener(OnQuit);
            craftingButton.onClick.AddListener(OnCrafting);
        }

        private void OnNewGame() {
            DataPersistenceManager.I.CreateNewGame();
            SceneManager.LoadScene(DevSet.I.appSettings.gameManagerSceneName, LoadSceneMode.Single);
        }

        private void OnContinue() {
            DataPersistenceManager.I.LoadSave(DevSet.I.appSettings.defaultSaveName);
            SceneManager.LoadScene(DevSet.I.appSettings.gameManagerSceneName, LoadSceneMode.Single);
        }
        private void OnCrafting()
        {
            SceneManager.LoadScene("Crafting");
        }
        private void OnOptions(){_logger.LogWarning($"Option {"Options" % Colorize.Red} is not yet implemented.");}
        private void OnQuit() { UnityEngine.Application.Quit(); }
    }
}