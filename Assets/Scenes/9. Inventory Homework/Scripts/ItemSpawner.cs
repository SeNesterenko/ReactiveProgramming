using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private ItemViewController _itemViewControllerPrefab;
        [SerializeField] private GridLayoutGroup _rootSpawn;
        [SerializeField] private ItemStore _itemStore;

        public void SpawnItem()
        {
            var item = _itemStore.GetStoreItem();

            if (ExistItemsController.Instance.CanAddItem(item))
            {
                var newItemController = Instantiate(_itemViewControllerPrefab, _rootSpawn.transform);
                newItemController.Initialize(new ItemModel(item.Sprite, 1, item));
                ExistItemsController.Instance.AddItem(item, newItemController);
            }
            else
            {
                ExistItemsController.Instance.ExistItems[item].ProcessIncreaseQuantityOfItems();
            }
        }
    }
}