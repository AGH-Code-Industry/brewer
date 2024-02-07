using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NotificationSystem : MonoBehaviour
{
    public GameObject notificationContainer;
    public GameObject notificationPrefab;

    Queue<string> notificationQueue = new Queue<string>();

    class Notification
    {
        public float displaySecondsLeft;
        public float fadeSecondsLeft;
        public GameObject gameObject;
        public bool positionSet;
    }

    LinkedList<Notification> displayedNotifications = new LinkedList<Notification>();

    void AddNotification(string message)
    {
        notificationQueue.Enqueue(message);
    }

    const float displaySeconds = 4.0f;
    const float fadeSeconds = 0.5f;
    const int maxNotificationsToDisplayAtOnce = 4;
    const float appearingSpeed = 500.0f;

    int testMessagesSent = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            testMessagesSent++;
            AddNotification(testMessagesSent.ToString() + ". Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        }

        RectTransform notificationBefore = null;
        foreach (var notification in displayedNotifications.Reverse())
        {
            var transform = notification.gameObject.GetComponent<RectTransform>();

            if (notification.positionSet)
            {
                notificationBefore = transform;
                continue;
            }

            notification.positionSet = true;

            var renderer = notification.gameObject.GetComponent<CanvasGroup>();
            renderer.alpha = 1.0f;

            var position = transform.anchoredPosition;
            bool isOldestNotification = notificationBefore == null;
            if (isOldestNotification)
            {
                position.y = -transform.rect.height;
            }
            else
            {
                position.y = notificationBefore.position.y - transform.rect.height;
            }

            transform.anchoredPosition = position;
            notificationBefore = transform;
        }

        bool moveObjects = false;
        float distanceToMoveUpBy = Time.deltaTime * appearingSpeed;
        if (displayedNotifications.Count > 0)
        {
            var newestNotificationPosition = displayedNotifications.First().gameObject.GetComponent<RectTransform>().anchoredPosition;
            var isNotFullyVisible = newestNotificationPosition.y < 0.0f;
            if (isNotFullyVisible)
            {
                distanceToMoveUpBy = Mathf.Min(distanceToMoveUpBy, -newestNotificationPosition.y);
                moveObjects = true;
            }
        }

        foreach (var notification in displayedNotifications)
        {
            notification.displaySecondsLeft -= Time.deltaTime;
            if (moveObjects)
            {
                var transform = notification.gameObject.GetComponent<RectTransform>();
                var position = transform.anchoredPosition;
                position.y += distanceToMoveUpBy;
                transform.anchoredPosition = position;
            }
        }

        if (displayedNotifications.Count > 0)
        {
            var oldestNotification = displayedNotifications.Last();
            var topNotificationPosition = oldestNotification.gameObject.GetComponent<RectTransform>().anchoredPosition;
            if (oldestNotification.displaySecondsLeft <= 0)
            {
                var isFullyVisible = topNotificationPosition.y >= 0.0f;
                if (isFullyVisible)
                {
                    oldestNotification.fadeSecondsLeft -= Time.deltaTime;
                }

                var notificationRenderer = oldestNotification.gameObject.GetComponent<CanvasGroup>();
                notificationRenderer.alpha = oldestNotification.fadeSecondsLeft / fadeSeconds;
                if (oldestNotification.fadeSecondsLeft <= 0.0f)
                {
                    Destroy(oldestNotification.gameObject);
                    displayedNotifications.RemoveLast();
                }
            }
        }

        string message;
        if (displayedNotifications.Count < maxNotificationsToDisplayAtOnce && notificationQueue.TryDequeue(out message))
        {
            var notification = Instantiate(notificationPrefab, notificationContainer.transform);
            var textComponent = notification.transform.Find("Message").GetComponent<TextMeshProUGUI>();
            textComponent.text = message;
            displayedNotifications.AddFirst(new Notification {
                gameObject = notification,
                displaySecondsLeft = displaySeconds,
                fadeSecondsLeft = fadeSeconds,
                // Cannot set position on this frame, because the size isn't computed yet.
                positionSet = false,
            });
            var notificationRenderer = notification.GetComponent<CanvasGroup>();
            notificationRenderer.alpha = 0.0f;
        }
    }
}
