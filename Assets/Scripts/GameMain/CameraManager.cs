using UnityEngine;
using DG.Tweening;

namespace gamemain {
    public class CameraManager : MonoBehaviour {

        [SerializeField]
        private Vector2 difference_;

        [SerializeField]
        private GameObject target_;

        private MapGenerator map_;

        private Tween tweener_;

        private void Start() {
            map_ = GameObject.Find("MapGenerator").GetComponent<MapGenerator>();

            // tweener_ = transform.DOMove(target_.transform.position + new Vector3(difference_.x, 0, -10), 5.0f);
        }

        private void LateUpdate() {

            /* 
            if (Input.GetMouseButtonDown(0)) {
                tweener_.Kill();
                tweener_ = null;
            }
			*/

            // if (tweener_ == null || tweener_.IsComplete()) {
            transform.position = target_.transform.position + new Vector3(difference_.x, difference_.y, -10);
            // }
        }
    }
}
