using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._6._Shop
{
    public class MoneyService : MonoBehaviour
    {
        public IObservable<int> MoneyObservable => _moneySubject;

        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private TextMeshProUGUI _moneyText;

        private readonly BehaviorSubject<int> _moneySubject = new(100);


        private void Start()
        {
            // Обрабатываем нажатие кнопки с помощью UniRx
            _addMoneyButton.OnClickAsObservable()
                .Subscribe(_ => AddMoney())
                .AddTo(this);

            // Подписываемся на событие изменения денег
            _moneySubject
                .Subscribe(money => _moneyText.text = _moneySubject.Value.ToString())
                .AddTo(this);
        }

        private void AddMoney()
        {
            int response = 100 + _moneySubject.Value;
            _moneySubject.OnNext(response);
        }

        public void SpendMoney(int amount)
        {
            var nextMoney = _moneySubject.Value - amount;
            _moneySubject.OnNext(nextMoney);
        }
    }
}