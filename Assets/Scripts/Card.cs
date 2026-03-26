using System;
using UnityEngine;

internal class Card : MonoBehaviour
{
    private bool _isOpen;
        
    public event Action StatusChanged;
        
    public FaceType Face { get; private set; }

    public bool IsOpen
    {
        get => _isOpen;

        private set
        {
            _isOpen = value;
            StatusChanged?.Invoke();
        }
    }

    public void Initialize(FaceType face, bool isOpen = false)
    {
        Face = face;
        IsOpen = isOpen;
    }

    public void Close() =>
        IsOpen = false;

    public void Open() =>
        IsOpen = true;
}