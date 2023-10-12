using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // 싱글턴
    private List<Card> allCards;
    // 모든 카드 리스트

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Board board = FindObjectOfType<Board>();
        // Board 객체(클래스)를 찾아온다
        allCards =  board.GetCards();

        StartCoroutine("FlipAllCardsRoutine");
        // 코루틴 시작
    }

    IEnumerator FlipAllCardsRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);
    }

    void FlipAllCards() // 모든 카드를 뒤집는다
    {
        foreach(Card card in allCards)
        {
            card.FlipCard();
        }
    }
}
