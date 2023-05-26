using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class diChuyen : MonoBehaviour
{
    public bool isRight = true;
    public Animator animator;
    private Rigidbody2D rb;
    private bool nen;
    public GameObject panel, button, text;
    public TextMeshProUGUI diemText;
    int tong = 0;
    public GameObject PSBrick;
    private bool isPause = false;

    public AudioSource mainSound;
    public AudioSource deathSound;
    // Start is called before the first frame update

    void tinhTong(int scorce)
    {
        tong += scorce;
        diemText.text = "Điểm: " + tong;
    }
    void Start()
    {
        mainSound.Play();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tinhTong(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            transform.Translate(Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isRunning", false);
        }

        if (nen)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (isRight)
                {
                    // transform.Translate(0, Time.deltaTime * 100, 0);
                    rb.AddForce(new Vector2(0, 400));
                }
                else
                {
                    // transform.Translate(0, Time.deltaTime * 100, 0);
                    rb.AddForce(new Vector2(0, 400));
                }
                nen = false;
            }

        }

        if (Input.GetKey(KeyCode.P))
        {
            isPause = !isPause;
            if (isPause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }

    // Hàm quản lý va chạm của các gameObject
    // Chỉ cần gõ "oncollisionEnter2D" thì sẽ tự nhảy ra hàm đầy đủ
    private void OnCollisionEnter2D(Collision2D collision) // Va chạm đẩy nhau
    {
        // Nếu gameObject đó va chạm với gameObject có tag là "nenDat" thì 
        if (collision.gameObject.tag == "nenDat")
        {
            nen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Va chạm xuyên qua nhau
    {
        if (collision.gameObject.tag == "tren")
        {
            // Nấm die
            var name = collision.attachedRigidbody.name; // Lấy tên của layer đang tương tác, biết tên của con đó.
            Destroy(GameObject.Find(name));
        }

        if (collision.gameObject.tag == "trai" || collision.gameObject.tag == "roi")
        {
            mainSound.Stop();
            deathSound.Play();
            // Game over, replay màn chơi
            Time.timeScale = 0;  // dừng scene

            panel.SetActive(true);  // show panel
            button.SetActive(true); // show button
            text.SetActive(true);   // show text
        }

        if (collision.gameObject.tag == "coin")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhTong(5);
        }

        if (collision.gameObject.tag == "box")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            // Bật Practice lên
            // Có 3 thông cần truyền vào: (Practice muốn hiển thị, Vị trí để hiện thị Practice System - vị trí hiện tại
            // của cái gạch, Rotarion của cái brick)
            Instantiate(PSBrick, collision.gameObject.transform.position, collision.gameObject.transform.localRotation);
        }

        if (collision.gameObject.tag == "quaMan")
        {
            SceneManager.LoadScene("Man2");
        }


    }
}
