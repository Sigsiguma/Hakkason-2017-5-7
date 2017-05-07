using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace utility.text {
    public class SpriteDigitNumber : MonoBehaviour {

        public StringReactiveProperty inputDigit_;

        [SerializeField]
        private Sprite[] digits_;

        [SerializeField]
        private Vector2 digitSize_;

        private void Start() {
            inputDigit_.Subscribe(WriteDigits);
        }

        private void WriteDigits(string digits) {
            var drawPos = Vector2.zero;

            ResetWord();
            foreach (var digit in digits) {
                var index = digit - '0';

                if (index < digits_.Length) {
                    CreateAlphabetImage(index, drawPos);
                    drawPos.x += digitSize_.x;
                }
            }

        }

        private void CreateAlphabetImage(int index, Vector2 drawPos) {
            var obj = new GameObject("Number");
            var renderer = obj.AddComponent<Image>();
            renderer.sprite = digits_[index];
            renderer.rectTransform.sizeDelta = digitSize_;

            obj.transform.position = drawPos;
            obj.transform.SetParent(transform, false);
        }

        private void ResetWord() {
            foreach (Transform child in gameObject.transform) {
                Destroy(child.gameObject);
            }
        }

    }
}
