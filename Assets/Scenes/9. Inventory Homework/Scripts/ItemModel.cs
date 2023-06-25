using UniRx;
using UnityEngine;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public class ItemModel
    {
        public StoreItem StoreItem { get; }
        public Sprite Sprite { get; }
        public IReadOnlyReactiveProperty<int> Quantity => _quantity;

        private readonly IntReactiveProperty _quantity;

        public ItemModel(Sprite sprite, int quantity, StoreItem storeItem)
        {
            _quantity = new IntReactiveProperty(quantity);
            Sprite = sprite;
            StoreItem = storeItem;
        }

        public void IncreaseCount()
        {
            _quantity.Value++;
        }

        public void ReduceCount()
        {
            _quantity.Value--;
        }
    }
}