using Items;
using JetBrains.Annotations;
using TaskSystem;

namespace Dialogues.ChoiceProcessing {
    public class ChoiceContext {
        public bool RequiresItem { get; private set; }
        [CanBeNull] private ItemDefinition _requiredItem;
        public ItemDefinition RequiredItem {
            get {
                if (!RequiresItem) {
                    return null;
                }
                return _requiredItem;
            }
            set {
                _requiredItem = value;
                RequiresItem = true;
            }
        }
        
        public bool GetsItem { get; private set; }
        [CanBeNull] private ItemDefinition _getItem;
        public ItemDefinition GetItem {
            get {
                if (!GetsItem) {
                    return null;
                }
                return _getItem;
            }
            set {
                _getItem = value;
                GetsItem = true;
            }
        }
        
        public bool GetsTask { get; private set; }
         [CanBeNull] private string _getTask;
         public string GetTask {
             get {
                 if (!GetsTask) {
                     return null;
                 }
                 return _getTask;
             }
             set {
                 _getTask = value;
                 GetsTask = true;
             }
         }
    }
}