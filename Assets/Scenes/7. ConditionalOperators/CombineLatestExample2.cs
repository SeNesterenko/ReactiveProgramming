using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._7._ConditionalOperators
{
    public class CombineLatestExample2 : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle1;
        [SerializeField] private Toggle _toggle2;
        [SerializeField] private Toggle _toggle3;
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            // Создаем потоки событий изменения состояния переключателей
            IObservable<bool> toggle1Stream = _toggle1.OnValueChangedAsObservable();
            IObservable<bool> toggle2Stream = _toggle2.OnValueChangedAsObservable();
            IObservable<bool> toggle3Stream = _toggle3.OnValueChangedAsObservable();

            // Объединяем потоки событий с помощью оператора CombineLatest
            var combinedStream = Observable.CombineLatest(toggle1Stream, toggle2Stream, toggle3Stream);

            // Подписываемся на изменения в объединенном потоке и обрабатываем логику
            combinedStream
                .Subscribe(states =>
                {
                    bool isAnyEnabled = states.Contains(true);
                    _text.text = isAnyEnabled ? "Some toggle enabled" : "All toggles disabled";
                })
                .AddTo(this);
        }
    }
}