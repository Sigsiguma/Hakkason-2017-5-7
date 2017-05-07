using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace utility {
    public class TextAlpha : MonoBehaviour {

        private Text clickText;

        private void Awake() {
            clickText = GetComponent<Text>();
        }

        private void Start() {
            clickText = GetComponent<Text>();
            DOTween.ToAlpha(() => clickText.color, color => clickText.color = color, 0.1f, 1.0f).SetLoops(-1, LoopType.Yoyo);
        }

    }
}
