using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_Script : MonoBehaviour
{
    private int counter = 0;
    public GameObject[] gameObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Ended:
                    counter++;
                    if (counter > 5)
                        counter = 0;
                    break;
            }
        }

        ChangeView(counter);
    }

    public void ChangeView(int counter)
    {
        switch (counter)
        {
            case 0:
                gameObjects[0].SetActive(true);
                gameObjects[1].SetActive(false);
                gameObjects[2].SetActive(false);
                gameObjects[3].SetActive(false);
                gameObjects[4].SetActive(false);
                gameObjects[5].SetActive(false);
                break;
            case 1:
                gameObjects[0].SetActive(false);
                gameObjects[1].SetActive(true);
                gameObjects[2].SetActive(false);
                gameObjects[3].SetActive(false);
                gameObjects[4].SetActive(false);
                gameObjects[5].SetActive(false);
                break;
            case 2:
                gameObjects[0].SetActive(false);
                gameObjects[1].SetActive(false);
                gameObjects[2].SetActive(true);
                gameObjects[3].SetActive(false);
                gameObjects[4].SetActive(false);
                gameObjects[5].SetActive(false);
                break;
            case 3:
                gameObjects[0].SetActive(false);
                gameObjects[1].SetActive(false);
                gameObjects[2].SetActive(false);
                gameObjects[3].SetActive(true);
                gameObjects[4].SetActive(false);
                gameObjects[5].SetActive(false);
                break;
            case 4:
                gameObjects[0].SetActive(false);
                gameObjects[1].SetActive(false);
                gameObjects[2].SetActive(false);
                gameObjects[3].SetActive(false);
                gameObjects[4].SetActive(true);
                gameObjects[5].SetActive(false);
                break;
            case 5:
                gameObjects[0].SetActive(false);
                gameObjects[1].SetActive(false);
                gameObjects[2].SetActive(false);
                gameObjects[3].SetActive(false);
                gameObjects[4].SetActive(false);
                gameObjects[5].SetActive(true);
                break;
        }
    }
}
