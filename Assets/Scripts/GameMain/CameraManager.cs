using UnityEngine;

namespace gamemain {
    public class CameraManager : MonoBehaviour {

        [SerializeField]
        private Vector2 difference_;

        [SerializeField]
        private GameObject target_;

        private void LateUpdate() {
            transform.position = target_.transform.position + new Vector3(difference_.x, difference_.y, -10);
        }
    }
}
