using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // �̱���
    private List<Card> allCards;
    // ��� ī�� ����Ʈ

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
        // Board ��ü(Ŭ����)�� ã�ƿ´�
        allCards =  board.GetCards();

        StartCoroutine("FlipAllCardsRoutine");
        // �ڷ�ƾ ����
    }

    IEnumerator FlipAllCardsRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);
    }

    void FlipAllCards() // ��� ī�带 �����´�
    {
        foreach(Card card in allCards)
        {
            card.FlipCard();
        }
    }
}
