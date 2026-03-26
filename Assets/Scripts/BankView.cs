using UnityEngine;

internal class BankView : MonoBehaviour
{
    [SerializeField] private Bank _bank;

    private void OnEnable()
    {
        _bank.StatusChanged += UpdateView;
        UpdateView();
    }

    private void OnDisable() =>
        _bank.StatusChanged -= UpdateView;

    private void UpdateView() =>
        _bank.gameObject.SetActive(_bank.IsEmpty == false);
}