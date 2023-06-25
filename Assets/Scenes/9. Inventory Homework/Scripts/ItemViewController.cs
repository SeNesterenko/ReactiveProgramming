using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._9._Inventory_Homework.Scripts
{
    [RequireComponent(typeof(ItemView))]
    public class ItemViewController : MonoBehaviour
    {
        [SerializeField] private ItemView _itemView;
        [SerializeField] private Button _reduceQuantityItemsButton;

        private ItemModel _itemModel;

        public void Initialize(ItemModel itemModel)
        {
            _itemModel = itemModel;
            _itemModel.Quantity
                .Subscribe(_ => _itemView.ChangeViewQuantity(_itemModel.Quantity.Value))
                .AddTo(this);
        
            _itemView.Initialize(_itemModel.Quantity.Value, _itemModel.Sprite);

            _reduceQuantityItemsButton
                .OnClickAsObservable()
                .Subscribe(_ => ProcessReduceQuantityOfItems())
                .AddTo(this);
        }

        public void ProcessIncreaseQuantityOfItems()
        {
            _itemModel.IncreaseCount();
        }

        private void ProcessReduceQuantityOfItems()
        {
            _itemModel.ReduceCount();

            if (_itemModel.Quantity.Value == 0)
            {
                ExistItemsController.Instance.RemoveItem(_itemModel.StoreItem);
                Destroy(gameObject);
            }
        }
    }
}