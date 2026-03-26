using System;
using System.Collections.Generic;
using UnityEngine;

internal class Bank : MonoBehaviour
{
    private readonly Stack<FaceType> _faces = new ();
    private bool _isEmpty;

    public event Action StatusChanged;

    public bool IsEmpty
    {
        get => _isEmpty;

        private set
        {
            _isEmpty = value;
            StatusChanged?.Invoke();
        }
    }

    public void Push(FaceType face)
    {
        _faces.Push(face);
        IsEmpty = _faces.Count == 0;
    }

    public FaceType Pop()
    {
        FaceType face = _faces.Pop();
        IsEmpty = _faces.Count == 0;
        
        return face;
    }
}