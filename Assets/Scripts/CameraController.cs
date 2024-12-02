using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject bird;
    private float timer = 0f; // ������
    private bool isLerping = false; // ����, �����������, ���� �� ������������
    public float duration = 5f; // ������������ �������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bird is not null)
        {
            // ������� ������� ���������� ������
            Vector3 curCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 1, 0));

            // ���� ������ ���������� �� �����, ���������� ������ �� ���
            if (bird.transform.position.x >= curCenter.x)
            {
                transform.position = new Vector3(bird.transform.position.x, transform.position.y, transform.position.z);
            }
        } else
        // ����� ������ �����
        {
            /*isLerping = true; // �������� ������������
            timer = 0f;
            if (isLerping)
            {
                timer += Time.deltaTime; // ����������� ������ �� �������*/
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -1), 1);

               /* // ���������, ��������� �� ������������
                if (timer >= 1)
                {
                    isLerping = false; // ��������� ������������
                    bird = null; // ������� ����������
                }
            }*/

        }
    }

    public void SetBird(GameObject newBird)
    {
        bird = newBird;
    }
}
