using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Town {
    public class CameraFollowPlayerComponent : MonoBehaviour
    {
        public Transform player;

        void Update()
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10.0f);
        }
    }
}
