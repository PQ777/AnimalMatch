using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//��Ʈ�� ����Ҷ� ����

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;
    // Card�� �ν����Ϳ� �ִ� Sprite Renderer�� �����´�

    [SerializeField]
    private Sprite animalSprite;
    // ������ ī�� ����(�̹����� �ҰŴ� Sprite Ŭ����)

    [SerializeField]
    private Sprite backSprite;
    // ����̹���

    private bool isFlipped = false;
    //  true�� animalSprite�� �����ְ� false�� backSprite�� �����ش�
    private bool isFlipping = false;
    // ī�尡 �������� �ִ��� Ȯ��

    public int cardID;
    // ī�� ���̵�

    public void SetCardID(int id)
    {
        cardID = id;
    }

    public void SetAnimalSprite(Sprite sprite)  // ���ް��� Sprite
    {
        this.animalSprite = sprite;
    }

    public void FlipCard()      // ī�� ������
    {
        isFlipping = true;
       

        Vector3 originalScale = transform.localScale;
        // ������ scale ��(x y z�� 1�� ����)
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);
        // x ���� �ٲٴ� ���� (x�� 1���� 0���� �ٲ۴�)

        transform.DOScale(targetScale, 0.2f).OnComplete(() =>
        {   // �ε巴�� �ѱ�� ���� ȿ��
            // DOScale�� ���ϴ� �ð������� �ٲ۴�, DOScale(����Ǵ� �����, �󸶸�ŭ �ϴ� �ð�)
            // x�� 0�� �Ǿ��ٸ� ���� ������ �� �� �ִ� �Լ��� ,OnComplete(() => )

            isFlipped = !isFlipped;
            // true false�� �ݴ�

            if (isFlipped)      // ������ ����
            {
                cardRenderer.sprite = animalSprite;
                // card�� Sprite Renderer�� �ִ� sprite�� animalSprite�� �ٲ۴�
            }
            else        // ������ ���°� �ƴϸ�
            {
                cardRenderer.sprite = backSprite;
            }

            transform.DOScale(originalScale, 0.2f).OnComplete(() =>
            {   // ������ Scale�� ����
                isFlipping = false;
                // �ٽ� Ŭ���Ҷ� �ٲ� �� �ְ� false�� ����
            });
        });

    }

    void OnMouseDown()
    {
        if(!isFlipping)     // ������ Ŭ���Ҷ� �ߺ����� Ŭ���� �� �ִ� ������ ����
        {
            //Debug.Log("mouse down");   
            FlipCard();
        }

    }
}
