using UniRx;
using UnityEngine;

namespace Scenes._10._ReactiveCommandAndBinding
{
    public class MessageBrokerExample : MonoBehaviour
    {
        private void Start()
        {
            // Подписка на сообщение
            MessageBroker.Default.Receive<TestArgs>()
                .Subscribe(Debug.Log)
                .AddTo(this);

            // Отправка сообщения
            MessageBroker.Default.Publish(new TestArgs { Value = 1000 });
        }
    }

    public class TestArgs
    {
        public int Value { get; set; }
    }
}