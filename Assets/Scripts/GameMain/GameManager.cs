using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using utility.fade;

namespace gamemain {
    public class GameManager : SingletonMonoBehaviour<GameManager> {

        private Text currentMile_;

        private GameObject player_;

        private DisrtanceCalculator cal_;

        private Rigidbody2D playerRgbd_;

        public GameState state;

        private new void Awake() {
            FadeManager.Init();
            state = GameState.Start;
        }

        private void Start() {
            Fade.FadeOut(1.0f);
            currentMile_ = GameObject.Find("CurrentMile").GetComponent<Text>();
            player_ = GameObject.Find("hito");
            cal_ = player_.GetComponent<DisrtanceCalculator>();
            playerRgbd_ = player_.GetComponent<Rigidbody2D>();
        }

        private void Update() {
            currentMile_.text = "学校まで " + cal_.GetDistance().ToString();
            if (state == GameState.Playing) {
                if (Mathf.Abs(playerRgbd_.velocity.x) < 0.005f) {
                    ResultManager.Instance.ResultDraw(cal_.GetDistance());
                    state = GameState.End;
                }
            }

            if (Input.GetMouseButtonDown(0)) {
                Application.CaptureScreenshot("sukusho2.png");
            }
        }

    }

    public enum GameState {
        Start,
        Playing,
        End
    };
}
