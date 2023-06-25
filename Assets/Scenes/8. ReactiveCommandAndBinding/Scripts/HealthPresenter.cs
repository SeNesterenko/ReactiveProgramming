using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._10._ReactiveCommandAndBinding.Scripts
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Button _resurrectButton;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Start()
        {
            float maxHealth = _playerHealth.Health.Value;

            // Связывание реактивной команды с кнопкой позволяет установить кнопку в активное состояние,
            // когда команда может быть выполнена, и в неактивное состояние, когда команда не может быть выполнена. 
            _playerHealth.ResurrectCommand.BindTo(_resurrectButton);


            _playerHealth.Health
                .Subscribe(health =>
                {
                    _healthText.text = health.ToString();
                    _healthBar.fillAmount = health / maxHealth;
                })
                .AddTo(this);
        }
    }
}