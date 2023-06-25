using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _quantityText;
        [SerializeField] private Image _image;

        public void Initialize(int quantity, Sprite spriteImage)
        {
            _quantityText.text = quantity.ToString();
            _image.sprite = spriteImage;
        }

        public void ChangeViewQuantity(int quantity)
        {
            _quantityText.text = quantity.ToString();
        }
    }
}