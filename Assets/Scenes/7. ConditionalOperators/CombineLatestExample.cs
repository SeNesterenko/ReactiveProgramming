using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._7._ConditionalOperators
{
    public class CombineLatestExample : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _loginInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private Button _button;

        private void Start()
        {
            // Создаем потоки событий изменения текста в полях ввода
            IObservable<string> inputField1Stream = _loginInputField.onValueChanged.AsObservable();
            IObservable<string> inputField2Stream = _passwordInputField.onValueChanged.AsObservable();

            // Объединяем потоки с помощью оператора CombineLatest
            IObservable<bool> combinedStream = inputField1Stream
                .CombineLatest(inputField2Stream, (text1, text2) =>
                    !string.IsNullOrEmpty(text1) && !string.IsNullOrEmpty(text2))
                .StartWith(false); // Добавляем начальное значение false
            
            
            // Подписываемся на изменения в объединенном потоке и обновляем доступность кнопки
            combinedStream.Subscribe(canInteract =>
            {
                _button.interactable = canInteract;
            }).AddTo(this);
        }
    }
}