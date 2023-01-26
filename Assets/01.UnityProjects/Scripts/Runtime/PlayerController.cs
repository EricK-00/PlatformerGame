using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float NORMAL_45DEGREE = 0.7f;

    public AudioClip deathSound;
    private bool isDead = false;


    public float jumpForce;
    private int jumpCount;
    private bool isGrounded = false;

    #region Player's component
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private AudioSource _audioSource;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponentMust<Rigidbody2D>();
        _animator = gameObject.GetComponentMust<Animator>();
        _audioSource = gameObject.GetComponentMust<AudioSource>();

        Functions.Assert(_rigidbody2D != null, "[Player] No Rigidbody component");
        Functions.Assert(_animator != null, "[Player] No Animator component");
        Functions.Assert(_audioSource != null, "[Player] No AudioSource component");

        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        // { 플레이어 점프
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            ++jumpCount;
            _rigidbody2D.velocity = Vector2.zero;

            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            _audioSource.Play();
        }
        else if (Input.GetMouseButtonUp(0) && _rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity * 0.5f;
        }
        // } 플레이어 점프

        _animator.SetBool("Grounded", isGrounded);
    }

    //! 플레이어 사망
    private void Die()
    {
        _animator.SetTrigger("Die");

        _audioSource.clip = deathSound;
        _audioSource.Play();

        _rigidbody2D.velocity = Vector2.zero;
        isDead = true;
    }

    //! 트리거 충돌 감지 처리 메서드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DeadZone") && !isDead)
        {
            Die();
        }
    }

    //! 바닥에 닿을 때 실행하는 메서드
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > NORMAL_45DEGREE)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    //! 바닥에서 벗어날 때 실행하는 메서드
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}