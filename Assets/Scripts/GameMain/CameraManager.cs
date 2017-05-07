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
            transform.position = new Vector3(map_.m_schoolPos.x, transform.position.y, transform.position.z);

            tweener_ = transform.DOMove(target_.transform.position + new Vector3(difference_.x, difference_.y, -10), 5.0f).OnComplete(() => tweener_ = null);
        }

        private void LateUpdate() {

            if (Input.GetKeyDown(KeyCode.Return)) {
                tweener_.Kill();
                tweener_ = null;
            }

            if (tweener_ == null || tweener_.IsComplete()) {
                transform.position = target_.transform.position + new Vector3(difference_.x, difference_.y, -10);
            }
        }
    }
}
