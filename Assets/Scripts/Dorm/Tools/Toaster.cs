using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using Dorm.Items;
using Dorm.Movables;
using Dorm.Tools.Animations;
using Recipes;
using UnityEngine;
using Utils;

namespace Dorm.Tools {
    [RequireComponent(typeof(SimpleToolAnimation))]
    public class Toaster : Tool, IDragInteractable {
        private static readonly CLogger Logger = Loggers.LoggersList[Loggers.LoggerType.TOOLS];

        public Transform resultSpawnPoint;
        public Transform resultParent;
        
        private bool _isWorking;
        private RecipeDefinition _currentRecipe;
        private SimpleToolAnimation _anim;
        
        protected override void Awake() {
            base.Awake();
            _anim = GetComponent<SimpleToolAnimation>();
        }   
        
        public void EnteredPossibleDragInteraction(GameObject sourceObject) {
            Logger.Log($"{sourceObject.name} entered possible drag interaction with {toolDefinition}");
        }

        public void LeftPossibleDragInteraction(GameObject sourceObject) {
            Logger.Log($"{sourceObject.name} left possible drag interaction with {toolDefinition}");
        }

        public bool DragInteraction(GameObject sourceObject) {
            if(_isWorking) {
                return false;
            }
            var item = sourceObject.GetComponent<Item>();
            if (item != null) {
                if (RecipeChecker.FindRecipe(toolDefinition.toolType, new[] { item.itemDefinition },
                        out _currentRecipe)) {
                    Logger.Log($"{this} started working on {_currentRecipe}");
                    StartCoroutine(ProcessRecipe());
                    return true;
                }
                return false;
            }
            return false;
        }

        private IEnumerator ProcessRecipe() {
            _isWorking = true;
            _anim.StartAnimation();
            yield return new WaitForSeconds(_currentRecipe.timeToCraft);
            Logger.Log($"{this} finished working on {_currentRecipe}.");
            _isWorking = false;
            _anim.StopAnimation();
            Instantiate(_currentRecipe.result.prefab, resultSpawnPoint.position, Quaternion.identity, resultParent);
            _currentRecipe = null;
        }
    }
}