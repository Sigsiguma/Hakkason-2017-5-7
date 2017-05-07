using UnityEngine;
using UniRx;

namespace utility.input {
    public static partial class ObservableInputTriggerExtensions {

        public static IObservable<Unit> OnLongPointerDownAsObservable(this GameObject gameObject) {
            if (gameObject == null) return Observable.Empty<Unit>();
            return GetOrAddComponent<ObservableLongPointerDownTrigger>(gameObject).OnLongPointerDownAsObservable();
        }

        private static T GetOrAddComponent<T>(GameObject gameObject)
            where T : Component {
            var component = gameObject.GetComponent<T>();
            if (component == null) {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }
    }
}
