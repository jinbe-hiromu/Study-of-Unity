using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // �����ꂽ�}�E�X�̏ꏊ�փ��C�i�����j���΂�
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // �x�N�g�����擾�i���[���h���W�j
            var dir = ray.direction;

            //// �d�͂�������
            //prefabBullet.GetComponent<Rigidbody>().isKinematic = false;     // false�ŏd�͂�������
            
            // �v���n�u�̐���
            var bullet = Instantiate(prefabBullet);

            bullet.transform.position = transform.position;         // �X�N���v�g�����s���Ă���I�u�W�F�N�g�i�J�����I�u�W�F�N�g�j�̈ʒu�Ɠ����l�ɂ���

            // ����
            bullet.GetComponent<BulletController>().Shoot(dir.normalized * 3000);
        }
    }
}
