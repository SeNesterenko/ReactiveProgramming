using UnityEngine;

namespace Scenes._9._Inventory_Homework.Scripts
{
    [CreateAssetMenu(fileName = "ItemStore", menuName = "ItemStore")]
    public class ItemStore : ScriptableObject
    {
        [SerializeField] private StoreItem[] _storeItems;

        public StoreItem GetStoreItem()
        {
            return _storeItems[Random.Range(0, _storeItems.Length - 1)];
        }
    }
}