using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    // 카드 프리팹 오브젝트

    [SerializeField]
    private Sprite[] cardSprites;
    // 카드 리스트(배열)

    private List<int> cardIDList = new List<int>();
    // ID를 관리하는 리스트, 비어있는 정수형 리스트

    // Start is called before the first frame update
    void Start()
    {
        GenerateCardID();
        InitBoard();
    }

    void GenerateCardID()
    {
        // 0 0, 1 1, 2 2, 3 3, .... 19 19 들어간다
        for(int i=0; i<cardSprites.Length; i++)
        {
            cardIDList.Add(i);  // i 값을 추가
            cardIDList.Add(i);
        }
    }
    
    void InitBoard()
    {
        float spaceY = 1.8f;    // y 간격
        // row (-2. -1. 0, 1, 2 순으로 커진다)
        // 0 - 2 = -2 * spaecY = -3.6
        // 1 - 2 = -1 * spaceY = -1.8
        // 2 - 2 = 0 * spaceY = 0
        // 3 - 2 = 1 * spaceY = 1.8
        // 4 - 2 = 2 * spaceY = 3.6
        // 5 / 2 = 2(정수로 바꿨을때)
        /*
         *  중간에 있는 2는 0이다. 2 - 2 는 =0 이니 0이 y 좌표이다
         *  각각 좌표에 2를 빼주면 -2 -1 0 1 2 위치가 나온다
         *  위치가 나온 값에서 y(y 간격)을 곱해주면 된다
         *  5 / 2 = 2.5가 나온다 (2를 구하는 방법)
         */

        // (row - (int)(rowCount / 2)) * spaceY , y좌표를 구하는 공식

        float spaceX = 1.3f;    // 가로 간격
        // col (-1.5, -0.5, 0.5, 1.5)
        // 0 - 2 = -2 + 0.5 = -1.5
        // 1 - 2 = -1 + 0.5 = -1.5
        // 2 - 2 = 0 + 0.5 = 0.5
        // 3 - 2 = 1 + 0.5 = 1.5
        /*
         각 값을 더해서 0 기준으로 맞춰서 배치할 수 있다
         각 좌표에서 colCount /2를 한 것을 빼준 값에서 0.5롤 더해주면 된다
         
         */

        // (col - (colCount / 2)) * spaceX + (spaceX / 2);

        int rowCount = 5;
        // 세로 크기
        int colCount = 4;
        // 가로 크기

        int cardIndex = 0;

        for(int row = 0; row < rowCount; row++)
        {   // 5번 반복
            for(int col = 0; col < colCount; col++)
            {   // 4번 반복

                float posX = (col - (colCount / 2)) * spaceX + (spaceX / 2);
                float posY = (row - (int)(rowCount / 2)) * spaceY;

                Vector3 pos = new Vector3(posX, posY, 0f);
                // 카드 위치 정의

                GameObject cardObject = Instantiate(cardPrefab, pos, Quaternion.identity);
                // cardObject 오브젝트
                Card card = cardObject.GetComponent<Card>();
                // Card 클래스에서 컴포넌트 가져오기

                int cardID = cardIDList[cardIndex++];
                // 해당하는 위치에 값을 가져온다
                card.SetCardID(cardID);
                card.SetAnimalSprite(cardSprites[cardID]);
                // 인덱스 기준으로 카드가 바뀐다

                }
        }
    }
}
