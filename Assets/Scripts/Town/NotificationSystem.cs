using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UIElements;

public class NotificationSystem : MonoBehaviour
{
    public GameObject notificationContainer;
    public GameObject notificationPrefab;

    Queue<string> notificationQueue = new Queue<string>();

    class Notification
    {
        public float secondsToDisplayFor;
        public GameObject notificationObject;
        public bool positionSet;
    }

    Queue<Notification> notificationObjects = new Queue<Notification>();

    private void Start()
    {
    }

    void AddNotification(string message)
    {
        notificationQueue.Enqueue(message);
    }

    float notificationDisplaySeconds = 4.0f;
    float notificationFadeSeconds = 0.5f;
    int maxNotificationsToDisplayAtOnce = 4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        { 
            AddNotification("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        }

        // Reverse to set positions from the top.
        RectTransform notificationAbove = null;
        foreach (var notification in notificationObjects.Reverse())
        {
            if (!notification.positionSet)
            {
                notification.positionSet = true;

                var notificationRenderer = notification.notificationObject.GetComponent<CanvasGroup>();
                var notificationTransform = notification.notificationObject.GetComponent<RectTransform>();
                notificationRenderer.alpha = 1.0f;

                var position = notificationTransform.anchoredPosition;
                bool isTopmostNotification = notificationAbove == null;
                if (isTopmostNotification)
                {
                    position.y = -notificationTransform.rect.height;
                } 
                else
                {
                    position.y = notificationAbove.position.y - notificationTransform.rect.height;
                }
                //position = Vector2.zero;
                notificationTransform.anchoredPosition = position;
                notificationAbove = notificationTransform;
            }
        }

        bool moveObjectsUp = false;
        float distanceToMoveUpBy = Time.deltaTime * 500.0f;
        foreach (var notification in notificationObjects)
        {
            var transform = notification.notificationObject.GetComponent<RectTransform>();
            if (transform.anchoredPosition.y < 0.0f)
            {
                distanceToMoveUpBy = Mathf.Min(distanceToMoveUpBy, -transform.anchoredPosition.y);
                moveObjectsUp = true;
                break;
            }
        }

        foreach (var notification in notificationObjects)
        {
            notification.secondsToDisplayFor -= Time.deltaTime;
            if (moveObjectsUp)
            {
                var transform = notification.notificationObject.GetComponent<RectTransform>();
                var position = transform.anchoredPosition;
                position.y += distanceToMoveUpBy;
                transform.anchoredPosition = position;
            }
        }

        Notification topNotification;
        if (notificationObjects.TryPeek(out topNotification))
        {
            if (topNotification.secondsToDisplayFor < notificationFadeSeconds)
            {
                var notificationRenderer = topNotification.notificationObject.GetComponent<CanvasGroup>();
                notificationRenderer.alpha = topNotification.secondsToDisplayFor / notificationFadeSeconds;
            }

            if (topNotification.secondsToDisplayFor <= 0.0f)
            {
                Destroy(topNotification.notificationObject);
                notificationObjects.Dequeue();
            }
        }

        string message;
        if (notificationObjects.Count < maxNotificationsToDisplayAtOnce && notificationQueue.TryDequeue(out message))
        {
            var notification = Instantiate(notificationPrefab, notificationContainer.transform);
            var textComponent = notification.transform.Find("Message").GetComponent<TextMeshProUGUI>();
            textComponent.text = message;
            notificationObjects.Enqueue(new Notification
            {
                notificationObject = notification,
                secondsToDisplayFor = notificationDisplaySeconds,
                // Cannot set position on this frame, because the size isn't computed yet.
                positionSet = false
            });
            var notificationRenderer = notification.GetComponent<CanvasGroup>();
            notificationRenderer.alpha = 0.0f;
        }
    }
}
