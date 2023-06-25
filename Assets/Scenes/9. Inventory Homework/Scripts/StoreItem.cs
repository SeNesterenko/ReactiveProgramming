using System;
using UnityEngine;

namespace Scenes._9._Inventory_Homework.Scripts
{
    [Serializable]
    public class StoreItem
    {
        public string Name => _name;
        public Sprite Sprite => _sprite;
        
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
    }
}