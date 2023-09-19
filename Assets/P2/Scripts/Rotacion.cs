using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public GameObject plano, plano2, plano3;
    private Transform plano_transform;
    private float changeSceneCD;
    private int state = 0;
    public float gradosRotacion = 1;
    // Start is called before the first frame update
    void Start()
    {
        plano_transform = plano.transform;
        changeSceneCD = 0;
        plano2.SetActive(false);
        plano3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        plano_transform.Rotate(new Vector3(0, gradosRotacion, 0));
        CambiaPlano();
        Debug.Log(Time.time);
        Debug.Log(changeSceneCD);
        Debug.Log(state);
    }

    public void CambiaPlano()
    {
        if (changeSceneCD < Time.time && state == 0)
        {
            plano.SetActive(false);
            plano2.SetActive(true);
            state = 1;
            plano_transform = plano2.transform;
            changeSceneCD = Time.time + 10.0f;
        }
        else
        {
            if (changeSceneCD < Time.time && state == 1)
            {
                plano2.SetActive(false);
                plano3.SetActive(true);
                state = 2;
                plano_transform = plano3.transform;
                changeSceneCD = Time.time + 10.0f;
            }
            else
            {
                if (changeSceneCD < Time.time && state == 2)
                {
                    plano3.SetActive(false);
                    plano.SetActive(true);
                    state = 0;
                    plano_transform = plano.transform;
                    changeSceneCD = Time.time + 10.0f;
                }
            }
        }
    }

}