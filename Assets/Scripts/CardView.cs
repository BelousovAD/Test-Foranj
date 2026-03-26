using UnityEngine;
using UnityEngine.UI;

internal class CardView : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private Image _cover;
    [SerializeField] private Text _textField;
    [SerializeField] private Sprite _opened;
    [SerializeField] private Sprite _closed;

    private void OnEnable()
    {
        _card.StatusChanged += UpdateView;
        UpdateView();
    }

    private void OnDisable() =>
        _card.StatusChanged -= UpdateView;

    private void UpdateView()
    {
        if (_card.IsOpen)
        {
            _cover.sprite = _opened;
            _textField.gameObject.SetActive(true);
            _textField.text = _card.Face.ToString();
        }
        else
        {
            _cover.sprite = _closed;
            _textField.gameObject.SetActive(false);
        }
    }
}