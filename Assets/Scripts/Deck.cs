using System.Collections.Generic;
using UnityEngine;

internal class Deck : MonoBehaviour
{
    private const int MinIndex = -1;
        
    private readonly List<Card> _cards = new ();
    private int _top = -1;

    public bool IsFull => _top == _cards.Count - 1;

    private void Awake() =>
        _cards.AddRange(GetComponentsInChildren<Card>());

    public void Push(FaceType face)
    {
        if (_top > MinIndex)
        {
            _cards[_top].Close();
        }
            
        _cards[++_top].Initialize(face, true);
    }

    public void Pop()
    {
        if (_top > MinIndex)
        {
            Card card = _cards[_top];
            _cards.RemoveAt(_top);
            _top--;
            Destroy(card.gameObject);

            if (_top > MinIndex)
            {
                _cards[_top].Open();
            }
        }
    }
}