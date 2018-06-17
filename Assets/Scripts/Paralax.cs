using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

    private const int LEFT = 0;
    private const int CENTER = 1;
    private const int RIGHT = 2;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject background;

    private float prevPosX;

    private float spriteWidth;

    private GameObject[] backgrounds;
	
    void Start()
    {
        prevPosX = cam.transform.position.x;
        Bounds b = background.GetComponent<SpriteRenderer>().sprite.bounds;
        spriteWidth = b.extents.x * 2;

        backgrounds = new GameObject[3];
        for (int i = 0; i < 3; ++i)
            backgrounds[i] = Instantiate(background);

        backgrounds[CENTER].transform.position = cam.transform.position;
        backgrounds[LEFT].transform.position = cam.transform.position - new Vector3(spriteWidth, 0);
        backgrounds[RIGHT].transform.position = cam.transform.position + new Vector3(spriteWidth, 0);
    }

	void Update()
    {
        if(speed == -1)
        {
            backgrounds[CENTER].transform.position = cam.transform.position;
            backgrounds[LEFT].transform.position = cam.transform.position - new Vector3(spriteWidth, 0);
            backgrounds[RIGHT].transform.position = cam.transform.position + new Vector3(spriteWidth, 0);
            return;
        }

        float camY = cam.transform.position.y;
        float camX = cam.transform.position.x;

        float diff = camX - prevPosX;
        prevPosX = camX;

        float offset = diff * speed;
        for(int i = 0; i < 3; ++i)
        {
            float x = backgrounds[i].transform.position.x;
            x += offset;
            backgrounds[i].transform.position = new Vector2(x, camY);
        }

        float rightThreshold = backgrounds[CENTER].transform.position.x + (spriteWidth / 2);
        float leftThreshold = backgrounds[CENTER].transform.position.x - (spriteWidth / 2);

        if (camX >= rightThreshold)
        {
            ShoveToRight();
        }
        else if (camX <= leftThreshold)
        {
            ShoveToLeft();
        }
	}

    private void ShoveToLeft()
    {
        GameObject temp1 = backgrounds[RIGHT];
        GameObject temp2 = backgrounds[LEFT];
        backgrounds[LEFT] = temp1;
        backgrounds[RIGHT] = backgrounds[CENTER];
        backgrounds[CENTER] = temp2;

        backgrounds[LEFT].transform.position = backgrounds[CENTER].transform.position - new Vector3(spriteWidth, 0);
    }

    private void ShoveToRight()
    {
        GameObject temp1 = backgrounds[RIGHT];
        GameObject temp2 = backgrounds[LEFT];
        backgrounds[RIGHT] = temp2;
        backgrounds[LEFT] = backgrounds[CENTER];
        backgrounds[CENTER] = temp1;

        backgrounds[RIGHT].transform.position = backgrounds[CENTER].transform.position + new Vector3(spriteWidth, 0);
    }
}
