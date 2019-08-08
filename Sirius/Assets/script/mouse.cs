using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse: MonoBehaviour
{  // в инпекторе перетащить камеру в скрипт!

    public float mouseSensitivity = 100; // чувствительность мыши

    float rotY, rotX; // повороты по X Y
    public float clampAngle = 60; // 60 градусов (граница)

    void Start()
    {
        rotY = transform.localRotation.eulerAngles.y; //положение мыши по у
        rotX = transform.localRotation.eulerAngles.x; //положение мыши по х



    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // получаем положение мыши по Х
        float mouseY = Input.GetAxis("Mouse Y"); // получаем положение мыши по Y

        //меняем значение переменных поворота движения мыши * на чувствительность 
        rotX += mouseX * mouseSensitivity * Time.deltaTime;
        rotY += mouseY * mouseSensitivity * Time.deltaTime;


        rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle); // отсекаем всё что меньше -clampAngle и больше  clampAngle

        // вращение объектов на нужные велечины
        transform.rotation = Quaternion.Euler(-rotY, rotX, 0);


    }
}

