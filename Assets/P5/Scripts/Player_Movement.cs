using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{
    public float speed, mouseSpeed;
    private Animator playerAnim;
    // Start is called before the first frame update
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float movementH = Input.GetAxis("Horizontal");
        float movementV = Input.GetAxis("Vertical");
        Vector3 translation = new Vector3(movementV * speed, 0, -movementH * speed);
        Vector3 rot = transform.localEulerAngles;
        Vector3 mousePosition = new Vector3(0, Input.GetAxis("Mouse X") * mouseSpeed, Input.GetAxis("Mouse Y") * mouseSpeed);
        rot.z += mousePosition.z;
        rot.y += mousePosition.y;

        if (movementH == 0 && movementV == 0)
            playerAnim.SetBool("running", false);
        else
            playerAnim.SetBool("running", true);

        transform.localEulerAngles = rot;
        transform.Translate(translation);
    }

}
