using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

internal class ChainBuilder : MonoBehaviour
{
    private const int StartCardCount = 1;
    
    [SerializeField][Min(0)] private int _cardCount = 40;
    [SerializeField][Min(2)] private int _minLength = 2;
    [SerializeField][Min(2)] private int _maxLength = 7;
    [SerializeField][Range(0f, 1f)] private float _chanceToUpper = 0.65f;
    [SerializeField][Range(0f, 1f)] private float _chanceToRevert = 0.15f;

    private readonly FaceType[] _faces = Enum.GetValues(typeof(FaceType)).Cast<FaceType>().ToArray();
    private int _minBaseLength;

    private void Awake() =>
        _minBaseLength = _minLength - StartCardCount;

    public List<List<FaceType>> GenerateChains()
    {
        int remainCardCount = _cardCount;
        List<List<FaceType>> chains = new ();
        int lastFaceIndex = 0;

        while (remainCardCount > 0)
        {
            int lenght = GetLenght(remainCardCount);
            List<FaceType> chain = GenerateChain(lenght, ref lastFaceIndex);

            remainCardCount -= lenght - 1;
            chains.Add(chain);
        }

        return chains;
    }

    private List<FaceType> GenerateChain(int lenght, ref int lastFaceIndex)
    {
        bool isChainGoingUpper = Random.value <= _chanceToUpper;
        List<FaceType> chain = new (lenght);
        lastFaceIndex = GetFaceIndex(lastFaceIndex, _faces);
        chain.Add(_faces[lastFaceIndex]);

        for (int i = 1; i < lenght; i++)
        {
            isChainGoingUpper = Random.value <= _chanceToRevert ? !isChainGoingUpper : isChainGoingUpper;
            lastFaceIndex = (_faces.Length + lastFaceIndex + (isChainGoingUpper ? 1 : -1)) % _faces.Length;
            chain.Add(_faces[lastFaceIndex]);
        }

        return chain;
    }

    private int GetLenght(int remainCardCount)
    {
        int lenght;
            
        if (remainCardCount - _minBaseLength < _minBaseLength)
        {
            lenght = remainCardCount + StartCardCount;
        }
        else
        {
            lenght = Random.Range(_minLength, Mathf.Min(_maxLength, remainCardCount - _minBaseLength) + 1);
        }

        return lenght;
    }

    private int GetFaceIndex(int lastFaceIndex, FaceType[] faces)
    {
        int generatedIndex = lastFaceIndex;

        while (generatedIndex == lastFaceIndex)
        {
            generatedIndex = Random.Range(0, faces.Length);
        }

        return generatedIndex;
    }
}