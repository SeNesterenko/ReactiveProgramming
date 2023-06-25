using UniRx;
using UnityEngine;

namespace Scenes._10._ReactiveCommandAndBinding.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<int> Health => _health;
        public ReactiveCommand ResurrectCommand;

        private readonly ReactiveProperty<int> _health = new(1000);


        private void Start()
        {
            // Команда станет доступна, когда игрок умер
            ResurrectCommand = _health.Select(x => x <= 0).ToReactiveCommand();

            // Выполнить, когда нажали на кнопку
            ResurrectCommand.Subscribe(_ => _health.Value = 1000);

            // Подписка на сообщение
            MessageBroker.Default
                .Receive<DamageEvent>()
                .Subscribe(TakeDamage);
        }

        private void TakeDamage(DamageEvent damageEvent)
        {
            _health.Value -= damageEvent.Damage;
        }
    }
}