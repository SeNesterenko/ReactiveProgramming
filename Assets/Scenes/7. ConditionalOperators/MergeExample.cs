using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._7._ConditionalOperators
{
    public class MergeExample : MonoBehaviour
    {
        [SerializeField] private Button _button1;
        [SerializeField] private Button _button2;
        [SerializeField] private Button _button3;
        [SerializeField] private Transform _targetObject;

        private void Start()
        {
            // Создаем потоки событий нажатия кнопок
            var button1ClickStream = _button1.OnClickAsObservable();
            var button2ClickStream = _button2.OnClickAsObservable();
            var button3ClickStream = _button3.OnClickAsObservable();

            // Объединяем потоки событий с помощью оператора Merge
            var mergedStream = button1ClickStream.Merge(button2ClickStream,
                button3ClickStream);

            // Подписываемся на объединенный поток и применяем эффект "bounce" к игровому объекту
            mergedStream.Subscribe(_ => ApplyBounceEffect())
                .AddTo(this);
        }

        private void ApplyBounceEffect()
        {
            // Применяем эффект "bounce" к игровому объекту
            _targetObject
                .DOPunchScale(Vector3.one * 0.2f, 0.5f, 1)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => _targetObject.DOScale(Vector3.one, 0.2f));
        }
    }
}