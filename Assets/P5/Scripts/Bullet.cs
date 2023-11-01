using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Colision");
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("Spawn").GetComponent<EnemySpawner>().EnemiesRemove(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
