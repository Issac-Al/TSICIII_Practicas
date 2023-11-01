using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject bullet;
    private GameObject actualBullet;
    public float bulletSpeed;
    public Transform spawnPos;
    public Transform playerPos;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerAnim.SetTrigger("shoot");
            actualBullet = Instantiate(bullet, spawnPos.position, Quaternion.identity);
            actualBullet.transform.rotation = playerPos.rotation;
            actualBullet.GetComponent<Rigidbody>().AddForce(playerPos.right * bulletSpeed);
        } 
    }
}
