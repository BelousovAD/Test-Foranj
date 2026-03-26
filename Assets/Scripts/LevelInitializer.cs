using System.Collections.Generic;
using UnityEngine;

internal class LevelInitializer : MonoBehaviour
{
    [SerializeField] private ChainBuilder _chainBuilder;
    [SerializeField] private Bank _bank;
    [SerializeField] private Card _start;
    [SerializeField] private List<Deck> _decks = new ();

    private void Start()
    {
        List<List<FaceType>> chains = _chainBuilder.GenerateChains();

        for (int i = chains.Count - 1; i >= 0; i--)
        {
            int j;
                
            for (j = chains[i].Count - 1; j > 0; j--)
            {
                int index = Random.Range(0, _decks.Count);

                while (_decks[index].IsFull)
                {
                    index = Random.Range(0, _decks.Count);
                }
                    
                _decks[index].Push(chains[i][j]);
            }
                
            _bank.Push(chains[i][j]);
        }
            
        _start.Initialize(_bank.Pop(), true);
    }
}