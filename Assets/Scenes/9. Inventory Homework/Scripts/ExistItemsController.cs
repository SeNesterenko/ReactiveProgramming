using UniRx;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public class ExistItemsController : Singleton<ExistItemsController>
    {
        public IReadOnlyReactiveDictionary<StoreItem, ItemViewController> ExistItems => _existItems;

        private ReactiveDictionary<StoreItem, ItemViewController> _existItems = new();

        public bool CanAddItem(StoreItem storeItem)
        {
            return !_existItems.ContainsKey(storeItem);
        }

        public void AddItem(StoreItem storeItem, ItemViewController itemViewController)
        {
            _existItems[storeItem] = itemViewController;
        }

        public void RemoveItem(StoreItem storeItem)
        {
            _existItems.Remove(storeItem);
        }
    }
}