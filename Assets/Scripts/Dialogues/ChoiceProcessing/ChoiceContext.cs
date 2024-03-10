using Items;
using JetBrains.Annotations;

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
        
        public bool GetsQuest { get; private set; }
        // [CanBeNull] private QuestDefinition _getQuest;
    }
}