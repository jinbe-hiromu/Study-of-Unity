using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _player;
    float _jumpForce = 680.0f;
    float _walkForce = 30.0f;
    float _maxWalkSpeed = 2.0f;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _player = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _player.velocity.y == 0)
        {
            _animator.SetTrigger("JumpTrigger");
            _player.AddForce(transform.up * _jumpForce);
        }

        var director = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            director = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            director = -1;
        }

        // �v���C���\�̑��x�擾
        var speedx = Mathf.Abs(_player.velocity.x);

        // �X�s�[�h����
        if(speedx < _maxWalkSpeed)
        {
            _player.AddForce(transform.right * director * _walkForce);
        }

        // ���������Ŕ��]
        if(director != 0)
        {
            transform.localScale = new Vector3(director, 1, 1);
        }

        // �v���C���̑��x�ɉ����ăA�j���[�V�������x��ύX
        if(_player.velocity.y == 0)
        {
            // �����A�j���[�V����
            _animator.speed = speedx / 2.0f;
        }
        else
        {
            _animator.speed = 1.0f;
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
