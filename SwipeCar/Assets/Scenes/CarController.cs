using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float _speed = 0;
    private Vector2 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var currentPos = Input.mousePosition;
            var swipeLength = currentPos.x - _startPos.x;

            // �X���C�v�̒����������x�ɕϊ�
            _speed = swipeLength / 500.0f;

            // ���ʉ��̍Đ�
            GetComponent<AudioSource>().Play();
        }

        transform.Translate(_speed, 0, 0);
        _speed *= 0.98f;
    }
}
