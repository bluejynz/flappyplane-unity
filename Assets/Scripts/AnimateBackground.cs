using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBackground : MonoBehaviour
{
    private float screenWidthRatio;
    private float screenHeightRatio;
    private float imgWidth;
    private float imgHeight;
    private SpriteRenderer spriteRenderer;
    private Vector2 newSize;

    // Start is called before the first frame update
    void Start() {
      spriteRenderer = GetComponent<SpriteRenderer>();

      imgWidth = spriteRenderer.sprite.bounds.size.x;
      imgHeight = spriteRenderer.sprite.bounds.size.y;

      screenHeightRatio = Camera.main.orthographicSize * 2f;
      screenWidthRatio = screenHeightRatio / Screen.height * Screen.width;

      newSize = transform.localScale;
      newSize.x = screenWidthRatio / imgWidth + .1f;
      newSize.y = screenHeightRatio / imgHeight;
      transform.localScale = newSize;

      if(name == "BackgroundImage2") {
        transform.position = new Vector2(screenWidthRatio, 0f);
      }
      
      GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0f);
    }

    // Update is called once per frame
    void Update() { 
      if(transform.position.x <= -screenWidthRatio) {
        transform.position = new Vector2(screenWidthRatio, 0f);
      }
    }
}
