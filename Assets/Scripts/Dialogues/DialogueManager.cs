using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
using Ink.Runtime;
using InventoryBackend;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;
using Utils.Singleton;
using Object = System.Object;

namespace Dialogues {
    public class DialogueManager : Singleton<DialogueManager> {
        [Header("Config")] 
        [SerializeField] private float typingSpeed = 0.04f;
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private GameObject choicesPanel;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject choicePrefab;
        [SerializeField] private Animator layoutAnimator;
        [SerializeField] private Animator portraitAnimator;
        [SerializeField] private TaskManager _taskManager;
        [SerializeField] private DialogueVariables _dialogueVariables;
        
        
        [NonSerialized] public UnityEvent dialogueStarted;
        [NonSerialized] public UnityEvent dialogueEnded;
        
        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.DIALOGUES];
        
        private ChoicesProcessor _choicesProcessor;
        private Story _currentStory;
        public bool _dialogueActive = false;
        private bool _hasAvailableChoices;
        private Action _functionToCallback;
        private Inventory _inventory;
        private Coroutine displayLineCoroutine;
        private bool canContinueToNextLine = false;
        private bool canSkipLine = false;
        private bool isRichText = false;
        
        private ExternalFunctions _externalFunctions;
        

        private const string SPEAKER_TAG = "speaker";
        private const string PORTRAIT_TAG = "portrait";
        private const string LAYOUT_TAG = "layout";
        
        
        protected override void Awake() {
            base.Awake();
            dialogueStarted = new UnityEvent();
            dialogueEnded = new UnityEvent();

            _inventory = FindObjectOfType<Inventory>();
            _choicesProcessor = new ChoicesProcessor(choicesPanel, choicePrefab, _inventory);
            _externalFunctions = new ExternalFunctions();
            //exitButton.onClick.AddListener(() => EndDialogue());
        }


        private void SelectPressed() {
            if(canContinueToNextLine && _dialogueActive && !_hasAvailableChoices) ContinueDialogue();
            else if (!canContinueToNextLine && _dialogueActive && !_hasAvailableChoices) canSkipLine = true;
        }
        private void Start() {
            //layoutAnimator = dialoguePanel.GetComponent<Animator>();
            dialoguePanel.SetActive(false);
            _dialogueActive = false;
            dialogueText.SetText("No dialogues playing. If you see this, you have a bug.");
        }
        
        /// <summary>
        /// Start new dialogue from a file. File must be provided by other Behaviour.
        /// Dialogue will only start if there is no other dialogue active.
        /// </summary>
        /// <param name="storyFile">File from which to load the story. Must be a JSON file, generated from Ink file.</param>
        /// <param name="finishAction">This action will be called when dialogues ends</param>
        public bool StartDialogue(TextAsset storyFile, Action finishAction = null) {
            EventsManager.instance.inputEvents.onSelectPressed += SelectPressed;
            if (_dialogueActive) {
                _logger.LogWarning("DialogueManager is already playing another dialogue.");
                return false;
            }
            _dialogueActive = true;
            _functionToCallback = finishAction;
            _currentStory = new Story(storyFile.text);
            _dialogueVariables.StartListening(_currentStory);
            _externalFunctions.Bind(_currentStory, _taskManager);
            
            dialoguePanel.SetActive(true);
            dialogueStarted.Invoke();
            ContinueDialogue();
            EventsManager.instance.playerEvents.DisablePlayerMovement();
            portraitAnimator.Play("default");
            layoutAnimator.Play("left");
            return true;
        }
        
        /// <summary>
        /// End the current dialogue. If there is no dialogue active, nothing will happen. Dialogue progress won't be saved.
        /// </summary>
        public void EndDialogue() {
            if (!_dialogueActive) {
                return;
            }
            _dialogueVariables.StopListening(_currentStory);
            _currentStory = null;
            _dialogueActive = false;
            dialoguePanel.SetActive(false);
            dialogueEnded.Invoke();
            _functionToCallback?.Invoke();
            EventsManager.instance.playerEvents.EnablePlayerMovement();
            EventsManager.instance.inputEvents.onSelectPressed -= SelectPressed;
        }
        
        /// <summary>
        /// Main function in the dialogue process, manages choices parsing, tag parsing and canvas updating.
        /// Will end the dialogue if there are no more lines to read.
        /// </summary>
        public void ContinueDialogue() {
            if (!_currentStory.canContinue) {
                EndDialogue();
                return;
            }
            UpdateDialogueBox();
            
        }

        private IEnumerator DisplayLine(string line) {
            dialogueText.SetText(line);
            _choicesProcessor.DestroyChoices();
            _hasAvailableChoices = false;
            dialogueText.maxVisibleCharacters = 0;
            canContinueToNextLine = false;
            foreach (char letter in line.ToCharArray()) {
                if (canSkipLine) {
                    dialogueText.maxVisibleCharacters = line.Length;
                    break;
                }

                if (letter == '<' || isRichText) {
                    isRichText = true;
                    if (letter == '>') {
                        isRichText = false;
                    }
                }
                else {
                    dialogueText.maxVisibleCharacters++;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            _hasAvailableChoices = _choicesProcessor.ProcessChoices(_currentStory);
            canContinueToNextLine = true;
            canSkipLine = false;
        }
        private void UpdateDialogueBox() {
            if (displayLineCoroutine is not null) {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(_currentStory.Continue()));
            HandleTags(_currentStory.currentTags);
        }

        private void HandleTags(List<string> currentTags) {
            foreach (string tag in currentTags) {
                string[] splittedTag = tag.Split(":");
                if(splittedTag.Length!=2) CDebug.LogError("Tag cannot be appropriately parsed: " + tag);
                else {
                    string tagKey = splittedTag[0].Trim();
                    string tagVal = splittedTag[1].Trim();
                    switch (tagKey) {
                        case SPEAKER_TAG:
                            break;
                        case PORTRAIT_TAG:
                            portraitAnimator.Play(tagVal);
                            break;
                        case LAYOUT_TAG:
                            layoutAnimator.Play(tagVal);
                            break;
                        default:
                            CDebug.LogWarning("Tag came, but it's not handled: " + tag);
                            break;
                    }
                }
                
            }
        }

        public Ink.Runtime.Object GetVariableState(string variableName) {
            Ink.Runtime.Object variableValue = null;
            _dialogueVariables.variables.TryGetValue(variableName, out variableValue);
            if (variableValue == null) {
                CDebug.LogWarning("Ink variable found null: " + variableName);
            }

            return variableValue;
        }
        public void SetVariableState(string variableName, Ink.Runtime.Object variableValue) {
            if (!_dialogueVariables.variables.ContainsKey(variableName)) {
                CDebug.LogWarning("Cannot assign value to variable, because ink variable was found null: " + variableName);
                return;
            }
            _dialogueVariables.variables.Remove(variableName);
            _dialogueVariables.variables.Add(variableName, variableValue);
        }
    }
}
