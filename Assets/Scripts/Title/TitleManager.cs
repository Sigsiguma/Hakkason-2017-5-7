using UnityEngine;
using UnityEngine.SceneManagement;
using utility.fade;
using utility.sound;

namespace title {
    public class TitleManager : MonoBehaviour {

        private bool isChangedScene = false;

        private void Awake() {
            FadeManager.Init();
            SoundManager.Init();
        }

        private void Start() {
            SoundManager.BGM.Play("BGM", 0.5f);
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                if (!isChangedScene) {
                    isChangedScene = true;
                    SoundManager.SE.Play("decide", 3.0f);
                    Fade.FadeIn(1.0f, () => SceneManager.LoadScene("GameMain"));
                }
            }
        }

    }
}
