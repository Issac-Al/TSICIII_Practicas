using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cambio_mapa : MonoBehaviour
{
    [SerializeField]
    private int actualLevel = 0;
    public List<GameObject> maps;
    public List<Transform> spawnPoints;
    [SerializeField]
    private int tries = 5;
    public Rigidbody rb;
    public TMP_Text texto, estado;
    private bool falled = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        texto.text = transform.rotation.ToString();
        estado.text = tries.ToString();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entre a la colision");
        Debug.Log(other.gameObject.transform.tag);
        if (other.gameObject.CompareTag("Completed"))
        {
            actualLevel++;
            tries = 5;
            maps[actualLevel - 1].SetActive(false);
            maps[actualLevel].SetActive(true);
            transform.position = spawnPoints[actualLevel].position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (other.gameObject.CompareTag("Falled"))
        {
            Debug.Log("Entre al if");
            tries--;
            falled = true;
            if (tries <= 0)
            {
                maps[actualLevel].SetActive(false);
                actualLevel = 0;
                tries = 5;
                maps[actualLevel].SetActive(true);
            }
            transform.position = spawnPoints[actualLevel].position;
            rb.velocity = Vector3.zero;
        }
    }



}
