using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class BankButton : MonoBehaviour
{
    [SerializeField] private Bank _bank;
    [SerializeField] private Stacker _stacker;
    
    private Button _button;

    private void Awake() =>
        _button = GetComponent<Button>();

    private void OnEnable() =>
        _button.onClick.AddListener(Click);

    private void OnDisable() =>
        _button.onClick.RemoveListener(Click);

    private void Click() =>
        _stacker.ForceStack(_bank.Pop());
}