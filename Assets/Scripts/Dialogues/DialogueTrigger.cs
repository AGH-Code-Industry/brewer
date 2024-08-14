using System;
using System.Collections;
using System.Collections.Generic;
using Dialogues;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DialogueTrigger : MonoBehaviour {
    [Header("Config")] 
    [SerializeField] private TextAsset inkJSON;
    private bool playerIsNear;
    

    private void OnEnable() {
        EventsManager.instance.inputEvents.onSelectPressed += SelectPressed;
    }
    private void OnDisable() {
        EventsManager.instance.inputEvents.onSelectPressed -= SelectPressed;
    }

    private void SelectPressed() {
        if (playerIsNear && !DialogueManager.I._dialogueActive) {
            DialogueManager.I.StartDialogue(inkJSON);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsNear = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsNear = true;
        }
    }
}
