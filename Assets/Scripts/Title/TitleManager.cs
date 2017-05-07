using UnityEngine;
using UnityEngine.SceneManagement;
using utility.fade;

namespace title {
    public class TitleManager : MonoBehaviour {

        private bool isChangedScene = false;

        private void Awake() {
            FadeManager.Init();
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                if (!isChangedScene) {
                    isChangedScene = true;
                    Fade.FadeIn(1.0f, () => SceneManager.LoadScene("GameMain"));
                }
            }
        }

    }
}
