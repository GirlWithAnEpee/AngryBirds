using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private GameObject curBird;
    private GameObject lineRight;
    private GameObject lineLeft;
    public GameObject birdPrefab;
    public float magicConst = 30;
    public float flightStrength = 15;

    // Start is called before the first frame update
    void Start()
    {
        lineLeft = GameObject.Find("LineLeft");
        lineRight = GameObject.Find("LineRight");
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ������ - ���� ��� �����, ������
        if (curBird is null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                curBird = Instantiate(birdPrefab, transform.position, transform.rotation);
                Camera.main.GetComponent<CameraController>().SetBird(curBird);
            }

            // ������� ������� ����������� � ��������
            lineLeft.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            lineRight.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        } else
        {
            // ���� ����� ���� - ������� ������� ������ ��������� �� ���
            lineLeft.GetComponent<LineRenderer>().SetPosition(0, curBird.transform.position);
            lineRight.GetComponent<LineRenderer>().SetPosition(0, curBird.transform.position);
        }

        // ��������� ��� - ��������� ����� � ���� � �������� ����������
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
            Vector3 newPos = Vector3.ClampMagnitude((v - transform.position) * flightStrength, 2);
            curBird.transform.position = transform.position + newPos;
        }
    }
}
