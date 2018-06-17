using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour {

    [SerializeField]
    private Camera cam;

	void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = cam.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(cam.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        scale *= cameraSize.x / spriteSize.x;

        transform.position = Vector2.zero;
        transform.localScale = scale;
    }

    void Update()
    {
        //this.transform.position = cam.transform.position;
    }
}
