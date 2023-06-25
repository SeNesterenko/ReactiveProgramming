using UnityEngine;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private ItemSpawner _itemSpawner;

        private void Start()
        {
            _inputController.Initialize(_itemSpawner.SpawnItem);
        }
    }
}