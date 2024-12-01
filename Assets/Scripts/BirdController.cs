using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private GameObject curBird;
    public GameObject birdPrefab;
    float magicConst = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curBird is null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                curBird = Instantiate(birdPrefab, transform.position, transform.rotation);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D rb = curBird.GetComponent<Rigidbody2D>();
            rb.simulated = true;
            rb.AddForce(((transform.position - curBird.transform.position) * 5), ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 v = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * magicConst + curBird.transform.position;
            Vector3 newPos = Vector3.ClampMagnitude(v - transform.position, 2);
            curBird.transform.position = transform.position + newPos;
        }
    }
}
