using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Scenes._6._Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Item> _items;
        [SerializeField] private MoneyService _moneyService;

        private void Start()
        {
            foreach (var item in _items)
            {
                _moneyService.MoneyObservable // Получаем поток денег из сервиса
                    .Select(money => money >= item.Price || item.IsPurchased) // Преобразуем поток денег,
                    // чтобы проверить, хватает ли денег для покупки или предмет уже куплен
                    .Subscribe(item.SetButtonInteractable) // Подписываемся на изменения в потоке
                    // и вызываем метод SetButtonInteractable у предмета для обновления доступности кнопки
                    .AddTo(this); // Добавляем подписку к объекту предмета

                item.ButtonClicked // Получаем поток событий клика по кнопке предмета
                    .Where(_ => !item.IsPurchased) // Фильтруем события только для некупленных предметов
                    .Subscribe(_ => // Подписываемся на события клика по кнопке предмета
                    {
                        item.BuyItem(); // Вызываем метод BuyItem у предмета для обозначения его как купленного
                        _moneyService
                            .SpendMoney(item.Price); // Вызываем метод SpendMoney у сервиса для списания
                        // денег за покупку предмета
                    })
                    .AddTo(this); // Добавляем подписку к объекту предмета
            }
        }
    }
}