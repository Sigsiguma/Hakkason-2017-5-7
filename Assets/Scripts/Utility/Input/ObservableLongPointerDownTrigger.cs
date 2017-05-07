using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

namespace utility.input {
    public class ObservableLongPointerDownTrigger : ObservableTriggerBase, IPointerDownHandler, IPointerUpHandler {

        private Subject<Unit> onLongPointerDown;

        private bool pressed_;

        private void Update() {
            if (pressed_) {
                if (onLongPointerDown != null) onLongPointerDown.OnNext(Unit.Default);
            }
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData event_data) {
            pressed_ = true;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData event_data) {
            pressed_ = false;
        }

        public IObservable<Unit> OnLongPointerDownAsObservable() {
            return onLongPointerDown ?? (onLongPointerDown = new Subject<Unit>());
        }

        protected override void RaiseOnCompletedOnDestroy() {
            if (onLongPointerDown != null) {
                onLongPointerDown.OnCompleted();
            }
        }
    }
}
