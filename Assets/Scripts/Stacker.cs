using System;
using System.Linq;
using UnityEngine;

internal class Stacker : MonoBehaviour
{
    [SerializeField] private Card _startCard;
    
    private readonly FaceType[] _faces = Enum.GetValues(typeof(FaceType)).Cast<FaceType>().ToArray();

    public bool TryStack(FaceType face)
    {
        int difference = Mathf.Abs(_startCard.Face - face);
        
        if (difference == 1 || difference == _faces.Length - 1)
        {
            _startCard.Initialize(face, true);
            return true;
        }

        return false;
    }

    public void ForceStack(FaceType face) =>
        _startCard.Initialize(face, true);
}