using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleWiithTexture : MonoBehaviour
{
    void Start()
    {
        Image image = GetComponent<Image>();
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        float delta =  rectTransform.sizeDelta.y / image.sprite.rect.height ;
        rectTransform.sizeDelta = new Vector2(image.sprite.rect.width *delta, image.sprite.rect.height*delta);
    }
}
