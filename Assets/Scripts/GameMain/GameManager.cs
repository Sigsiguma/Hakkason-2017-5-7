using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utility.fade;

namespace gamemain {
    public class GameManager : MonoBehaviour {

        private void Awake() {
            FadeManager.Init();
        }

        private void Start() {
            Fade.FadeOut(1.0f);
        }

    }
}
