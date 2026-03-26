using System.Collections.Generic;
using UnityEngine;

internal class Bank : MonoBehaviour
{
    private readonly Stack<FaceType> _faces = new ();

    public void Push(FaceType face) =>
        _faces.Push(face);

    public FaceType Pop() =>
        _faces.Pop();
}