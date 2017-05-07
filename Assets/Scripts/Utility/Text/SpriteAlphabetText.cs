using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace utility.text {
    public class SpriteAlphabetText : MonoBehaviour {

        [SerializeField]
        private Sprite[] alphabets_;

        [SerializeField]
        private StringReactiveProperty inputText_;

        [SerializeField]
        private AlphabetType type_;

        [SerializeField]
        private Vector2 textSize_;

        private void Start() {
            inputText_.Subscribe(WriteAlphabet);
        }

        private void WriteAlphabet(string word) {
            var drawPos = Vector2.zero;

            ResetWord();
            foreach (var c in word) {
                var index = (type_ == AlphabetType.Upper) ? c - 'A' : c - 'a';

                if (index < alphabets_.Length) {
                    CreateAlphabetImage(index, drawPos);
                    drawPos.x += textSize_.x;
                }
            }
        }

        private void CreateAlphabetImage(int index, Vector2 drawPos) {
            var obj = new GameObject("Word");
            var renderer = obj.AddComponent<Image>();
            renderer.sprite = alphabets_[index];
            renderer.rectTransform.sizeDelta = textSize_;

            obj.transform.position = drawPos;
            obj.transform.SetParent(transform, false);
        }

        private void ResetWord() {
            foreach (Transform child in gameObject.transform) {
                Destroy(child.gameObject);
            }
        }

        private enum AlphabetType {
            Upper,
            Lower
        }
    }
}
