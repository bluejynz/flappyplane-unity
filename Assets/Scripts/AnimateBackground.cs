using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBackground : MonoBehaviour
{
    private float imgWidth;
    private float imgHeight;
    private SpriteRenderer spriteRenderer;
    private Vector2 newSize;

    // Start is called before the first frame update
    void Start() {
      spriteRenderer = GetComponent<SpriteRenderer>();

      imgWidth = spriteRenderer.sprite.bounds.size.x;
      imgHeight = spriteRenderer.sprite.bounds.size.y;

      newSize = transform.localScale;
      newSize.x = GameManager.screenWidthRatio / imgWidth + .1f;
      newSize.y = GameManager.screenHeightRatio / imgHeight;
      transform.localScale = newSize;

      if(name == "BackgroundImage2") {
        transform.position = new Vector2(GameManager.screenWidthRatio, 0f);
      }
      
      GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0f);
    }

    // Update is called once per frame
    void Update() { 
      if(transform.position.x <= -GameManager.screenWidthRatio) {
        transform.position = new Vector2(GameManager.screenWidthRatio, 0f);
      }
    }
}
