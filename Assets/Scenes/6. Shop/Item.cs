using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes._6._Shop
{
  public class Item : MonoBehaviour
  {
    public int Price { get; private set; }
    public bool IsPurchased { get; private set; }
    public IObservable<Unit> ButtonClicked => _button.OnClickAsObservable();

    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Button _button;
    [SerializeField] private Image _frameImage;
    [SerializeField] private Sprite _bothFrameSprite;


    private void Awake()
    {
      Price = Random.Range(100, 1000);
      _priceText.text = Price.ToString();
    }

    public void SetButtonInteractable(bool interactable)
    {
      _button.interactable = interactable;
    }

    public void BuyItem()
    {
      IsPurchased = true;
      _frameImage.sprite = _bothFrameSprite;
    }
  }
}
