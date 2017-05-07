using UnityEngine;
using UniRx;

namespace utility.input {
    public static partial class ObservableInputTriggerExtensions {

        public static IObservable<Unit> OnLongPointerDownAsObservable(this Component component) {
            if (component == null || component.gameObject == null) return Observable.Empty<Unit>();
            return GetOrAddComponent<ObservableLongPointerDownTrigger>(component.gameObject).OnLongPointerDownAsObservable();
        }
    }
}
