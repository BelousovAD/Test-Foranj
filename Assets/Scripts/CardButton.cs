using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class CardButton : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    [SerializeField] private Card _card;
    [SerializeField] private Stacker _stacker;
    
    private Button _button;

    private void Awake() =>
        _button = GetComponent<Button>();

    private void OnEnable() =>
        _button.onClick.AddListener(Click);

    private void OnDisable() =>
        _button.onClick.RemoveListener(Click);

    private void Click()
    {
        if (_stacker.TryStack(_card.Face))
        {
            _deck.Pop();
        }
    }
}