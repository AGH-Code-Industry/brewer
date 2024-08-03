using System;
using System.Collections;
using UnityEngine;

namespace Dorm.Tools.Animations {
    public class SimpleToolAnimation : MonoBehaviour {
        public float animationSpeed = 1f;
        public Vector2 animationScaleMinMax ;
        
        private bool _shouldAnimate;
        private Vector3 _initialScale;

        private void Awake() {
            _initialScale = transform.localScale;
        }

        public void StartAnimation() {
            _shouldAnimate = true;
            StartCoroutine(Animate());
        }

        public void StopAnimation() {
            _shouldAnimate = false;
        }

        IEnumerator Animate() {
            var rise = -1;
            while (_shouldAnimate) {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (animationSpeed * Time.deltaTime * rise), transform.localScale.z);
                if (transform.localScale.y >= animationScaleMinMax.y) {
                    rise = -1;
                }

                if (transform.localScale.y <= animationScaleMinMax.x) {
                    rise = 1;
                }

                yield return new WaitForEndOfFrame();
            }

            transform.localScale = _initialScale;
        }
    }
}