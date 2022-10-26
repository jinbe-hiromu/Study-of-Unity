using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        // ��ʊO�ɏo����I�u�W�F�N�g��j��
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // �����蔻��
        var arrowPosition = transform.position;
        var playerPosition = _player.transform.position;
        var vector = arrowPosition - playerPosition;
        var distance = vector.magnitude;
        var arrowRadius = 0.5f;
        var playerRadius = 1.0f;

        if(distance < arrowRadius + playerRadius)
        {
            // �ēX�N���v�g�ɏՓ˂������Ƃ�`����
            var director = GameObject.Find("GameDirector");         // GameObject������
            director.GetComponent<GameDirector>().DecreaseHp();     // �X�N���v�g������

            Destroy(gameObject);
        }
    }
}
