using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Button _addItemButton;

        public void Initialize(Action onClickAddItemButton)
        {
            _addItemButton
                .OnClickAsObservable()
                .Subscribe(_ => onClickAddItemButton?.Invoke())
                .AddTo(this);
        }
    }
}