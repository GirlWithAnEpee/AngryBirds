using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject bird;
    private float timer = 0f; // Таймер
    private bool isLerping = false; // Флаг, указывающий, идет ли интерполяция
    public float duration = 5f; // Длительность таймера

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bird is not null)
        {
            // находим текущие координаты центра
            Vector3 curCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 1, 0));

            // если птичка перелетела за центр, перемещаем камеру за ней
            if (bird.transform.position.x >= curCenter.x)
            {
                transform.position = new Vector3(bird.transform.position.x, transform.position.y, transform.position.z);
            }
        } else
        // иначе плавно назад
        {
            /*isLerping = true; // Начинаем интерполяцию
            timer = 0f;
            if (isLerping)
            {
                timer += Time.deltaTime; // Увеличиваем таймер по времени*/
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -1), 1);

               /* // Проверяем, завершена ли интерполяция
                if (timer >= 1)
                {
                    isLerping = false; // Завершаем интерполяцию
                    bird = null; // очищаем переменную
                }
            }*/

        }
    }

    public void SetBird(GameObject newBird)
    {
        bird = newBird;
    }
}
