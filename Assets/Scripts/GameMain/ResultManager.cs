using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

namespace gamemain {
    public class ResultManager : SingletonMonoBehaviour<ResultManager> {

        private Text mileText;

        private void Start() {
            mileText = GameObject.Find("Mile").GetComponent<Text>();
            gameObject.SetActive(false);
        }

        public void ResultDraw(int score) {

            gameObject.SetActive(true);
            mileText.text = score.ToString();

            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
                .First()
                .Subscribe(_ => {
                    utility.fade.Fade.FadeIn(1.0f, () => SceneManager.LoadScene("usshi"));
                    utility.sound.SoundManager.SE.Play("decide");
                });
        }
    }
}
