using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._10._ReactiveCommandAndBinding.Scripts
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private Button _damageButton;

        private void Awake()
        {
            _damageButton
                .OnClickAsObservable()
                .Subscribe(_ => SendDamageEvent())
                .AddTo(this);
        }
        
        private void SendDamageEvent()
        {
            // Отправка сообщения
            MessageBroker.Default.Publish(new DamageEvent {Damage = 250});
        }
    }
}