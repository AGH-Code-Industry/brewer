using UnityEngine;

namespace Dorm.Phone {
    public class Phone : MonoBehaviour
    {
        public void SwitchPages(GameObject next) {
            next.SetActive(true);
        }
    }
}
