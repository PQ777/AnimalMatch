using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    // ī�� ������ ������Ʈ

    [SerializeField]
    private Sprite[] cardSprites;
    // ī�� ����Ʈ(�迭)

    private List<int> cardIDList = new List<int>();
    // ID�� �����ϴ� ����Ʈ, ����ִ� ������ ����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        GenerateCardID();
        InitBoard();
    }

    void GenerateCardID()
    {
        // 0 0, 1 1, 2 2, 3 3, .... 19 19 ����
        for(int i=0; i<cardSprites.Length; i++)
        {
            cardIDList.Add(i);  // i ���� �߰�
            cardIDList.Add(i);
        }
    }
    
    void InitBoard()
    {
        float spaceY = 1.8f;    // y ����
        // row (-2. -1. 0, 1, 2 ������ Ŀ����)
        // 0 - 2 = -2 * spaecY = -3.6
        // 1 - 2 = -1 * spaceY = -1.8
        // 2 - 2 = 0 * spaceY = 0
        // 3 - 2 = 1 * spaceY = 1.8
        // 4 - 2 = 2 * spaceY = 3.6
        // 5 / 2 = 2(������ �ٲ�����)
        /*
         *  �߰��� �ִ� 2�� 0�̴�. 2 - 2 �� =0 �̴� 0�� y ��ǥ�̴�
         *  ���� ��ǥ�� 2�� ���ָ� -2 -1 0 1 2 ��ġ�� ���´�
         *  ��ġ�� ���� ������ y(y ����)�� �����ָ� �ȴ�
         *  5 / 2 = 2.5�� ���´� (2�� ���ϴ� ���)
         */

        // (row - (int)(rowCount / 2)) * spaceY , y��ǥ�� ���ϴ� ����

        float spaceX = 1.3f;    // ���� ����
        // col (-1.5, -0.5, 0.5, 1.5)
        // 0 - 2 = -2 + 0.5 = -1.5
        // 1 - 2 = -1 + 0.5 = -1.5
        // 2 - 2 = 0 + 0.5 = 0.5
        // 3 - 2 = 1 + 0.5 = 1.5
        /*
         �� ���� ���ؼ� 0 �������� ���缭 ��ġ�� �� �ִ�
         �� ��ǥ���� colCount /2�� �� ���� ���� ������ 0.5�� �����ָ� �ȴ�
         
         */

        // (col - (colCount / 2)) * spaceX + (spaceX / 2);

        int rowCount = 5;
        // ���� ũ��
        int colCount = 4;
        // ���� ũ��

        int cardIndex = 0;

        for(int row = 0; row < rowCount; row++)
        {   // 5�� �ݺ�
            for(int col = 0; col < colCount; col++)
            {   // 4�� �ݺ�

                float posX = (col - (colCount / 2)) * spaceX + (spaceX / 2);
                float posY = (row - (int)(rowCount / 2)) * spaceY;

                Vector3 pos = new Vector3(posX, posY, 0f);
                // ī�� ��ġ ����

                GameObject cardObject = Instantiate(cardPrefab, pos, Quaternion.identity);
                // cardObject ������Ʈ
                Card card = cardObject.GetComponent<Card>();
                // Card Ŭ�������� ������Ʈ ��������

                int cardID = cardIDList[cardIndex++];
                // �ش��ϴ� ��ġ�� ���� �����´�
                card.SetCardID(cardID);
                card.SetAnimalSprite(cardSprites[cardID]);
                // �ε��� �������� ī�尡 �ٲ��

                }
        }
    }
}
