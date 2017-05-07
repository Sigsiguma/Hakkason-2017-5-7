using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using utility.fade;

namespace gamemain {
    public class GameManager : SingletonMonoBehaviour<GameManager> {

        private Text currentMile_;

        private new void Awake() {
            FadeManager.Init();
        }

        private void Start() {
            Fade.FadeOut(1.0f);
            currentMile_ = GameObject.Find("CurrentMile").GetComponent<Text>();
        }

    }
}
