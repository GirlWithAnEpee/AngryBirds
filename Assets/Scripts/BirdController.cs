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
        // нажали пробел - если нет птицы, создаём
        if (curBird is null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                curBird = Instantiate(birdPrefab, transform.position, transform.rotation);
            }
        }

        // отпустили ЛКМ - запускаем птицу в полёт и обнуляем переменную
        if (Input.GetMouseButtonUp(0) && curBird is not null)
        {
            Rigidbody2D rb = curBird.GetComponent<Rigidbody2D>();
            rb.simulated = true;
            rb.AddForce(((transform.position - curBird.transform.position) * 5), ForceMode2D.Impulse);
            curBird = null;
        }

        if (Input.GetMouseButton(0) && curBird is not null)
        {
            Vector3 v = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * magicConst + curBird.transform.position;
            Vector3 newPos = Vector3.ClampMagnitude(v - transform.position, 2);
            curBird.transform.position = transform.position + newPos;
        }
    }
}
