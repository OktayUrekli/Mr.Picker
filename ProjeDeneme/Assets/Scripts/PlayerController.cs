using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject[] hp=new GameObject[3] ;
    [SerializeField] TextMeshProUGUI topXPText;
    [SerializeField] TextMeshProUGUI lskorText;
    [SerializeField] TextMeshProUGUI fskorText;
    [SerializeField] TextMeshProUGUI topDiamondText;
    
    
    [SerializeField] AudioSource victorySound;
    [SerializeField] AudioSource loseSound;
    [SerializeField] AudioSource fruitSound;
    [SerializeField] AudioSource diamondSound;
    [SerializeField] AudioSource damageSound;



    Rigidbody myRigidBody;
    float yatay;
    int playerHealty;    
    int topDiamonds;
    int topXP;

    bool sag;
    bool sol;

    // dokunmatik 2 için özel

    private float speed = 0.01f;
    private Touch touch;


    void Start()
    {

        victoryPanel.SetActive(false);
        playerHealty =3;
        topDiamonds=0;
        topXP = 0;
        myRigidBody = GetComponent<Rigidbody>();
        topDiamondText.text = topDiamonds.ToString();
        topXPText.text = topXP.ToString() + " XP";

    }
   
    void Update()
    {
        yatay = Input.GetAxis("Horizontal");
        PlayerMovement(yatay);
        Dokunmatik2();
        //PlayerMoveDokunmatik();

    }

    private void Dokunmatik2()
    {
        if (Input.touchCount>0)
        {
            touch=Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position=new Vector3(transform.position.x+touch.deltaPosition.x*speed,transform.position.y,transform.position.z);
            }
        }
    }

    private void PlayerMoveDokunmatik()
    {
        Vector3 sagGit = new Vector3(7f, transform.position.y, transform.position.z);
        Vector3 solGit = new Vector3(-0.5f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.deltaPosition.x > 50f)
            {
                sag = true;
                sol = false;
            }
            if (parmak.deltaPosition.x < -50f)
            {
                sag = false;
                sol = true;
            }
            if (sag == true)
            {
                transform.position = Vector3.Lerp(transform.position, sagGit, 2f * Time.deltaTime);
            }
            if (sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, solGit, 2f * Time.deltaTime);
            }
        }
    }

    private void PlayerMovement(float yatay)
    {
        myRigidBody.velocity=new Vector3(yatay*750*Time.deltaTime,0,0);
        myRigidBody.AddForce(Vector3.forward *22000*Time.deltaTime);
   
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Diamond")
        {
           diamondSound.Play();
            topDiamonds++;
            Destroy(other.gameObject);
            topDiamondText.text = topDiamonds.ToString();
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            damageSound.Play();
            playerHealty--;
            Destroy(other.gameObject);
            PlayerHealtControl(playerHealty);
        }
        else if(other.gameObject.tag == "Fruit")
        {
          fruitSound.Play();
            topXP += 5;
            Destroy(other.gameObject);
            topXPText.text =topXP.ToString()+" XP";
        }
        
        else if (other.gameObject.tag=="Final")
        {
            victorySound.Play();
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
            fskorText.text = "SKOR:"+ topXP.ToString() + " XP";
        }
    }

    private void PlayerHealtControl(int heart)
    {
        if (heart==0)
        {
            losePanel.SetActive(true);
            hp[heart].SetActive(false);
            loseSound.Play();
            lskorText.text = "SKOR:"+topXP.ToString() + " XP";
            Time.timeScale = 0f;
        }
        else
        {
            hp[heart].SetActive(false);
        }
    }

}
