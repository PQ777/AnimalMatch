using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//다트윈 사용할때 선언

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;
    // Card에 인스펙터에 있는 Sprite Renderer를 가져온다

    [SerializeField]
    private Sprite animalSprite;
    // 뒤집을 카드 동물(이미지를 할거니 Sprite 클래스)

    [SerializeField]
    private Sprite backSprite;
    // 배경이미지

    private bool isFlipped = false;
    //  true면 animalSprite가 보여주고 false면 backSprite가 보여준다
    private bool isFlipping = false;
    // 카드가 뒤집히고 있는지 확인

    public int cardID;
    // 카드 아이디

    public void SetCardID(int id)
    {
        cardID = id;
    }

    public void SetAnimalSprite(Sprite sprite)  // 전달값은 Sprite
    {
        this.animalSprite = sprite;
    }

    public void FlipCard()      // 카드 뒤집기
    {
        isFlipping = true;
       

        Vector3 originalScale = transform.localScale;
        // 최초의 scale 값(x y z가 1로 설정)
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);
        // x 값을 바꾸는 변수 (x가 1에서 0으로 바꾼다)

        transform.DOScale(targetScale, 0.2f).OnComplete(() =>
        {   // 부드럽게 넘기기 위한 효과
            // DOScale은 원하는 시간값으로 바꾼다, DOScale(변경되는 결과값, 얼마만큼 하는 시간)
            // x가 0이 되었다면 다음 수행을 할 수 있는 함수는 ,OnComplete(() => )

            isFlipped = !isFlipped;
            // true false로 반대

            if (isFlipped)      // 뒤집힌 상태
            {
                cardRenderer.sprite = animalSprite;
                // card에 Sprite Renderer에 있는 sprite를 animalSprite로 바꾼다
            }
            else        // 뒤집힌 상태가 아니면
            {
                cardRenderer.sprite = backSprite;
            }

            transform.DOScale(originalScale, 0.2f).OnComplete(() =>
            {   // 원래의 Scale로 변경
                isFlipping = false;
                // 다시 클릭할때 바꿀 수 있게 false로 변경
            });
        });

    }

    void OnMouseDown()
    {
        if(!isFlipping)     // 빠르게 클릭할때 중복으로 클릭될 수 있는 현상을 방지
        {
            //Debug.Log("mouse down");   
            FlipCard();
        }

    }
}
