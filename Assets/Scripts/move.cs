using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {

    private Rigidbody rb;
    public int force;
    public Text text;
    public Text timeText;
    public GameObject win;
    public GameObject lose;
    public int score = 0;
    public float time = 20;
    public int S = 0;
    public int T;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");//根据键盘输入‘A’  ‘D’使x获得值-1或1；
        float z = Input.GetAxis("Vertical");//W S
        rb.AddForce( new Vector3(x, 0, z)*force);//利用向量使刚体获得一个方向的力
        time -= Time.deltaTime;//时间每秒减一
        T = (int)time + S;
        if (T>=0)
        {
            timeText.text = T.ToString();//将T转换成字符串类型
        }
        else
        {
            lose.SetActive(true);
            //Application.Quit();
            Time.timeScale = 0;//暂停游戏画面
            //Debug.Log("Game Over");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Roll");//重新加载场景
            Time.timeScale = 1;//开始游戏画面
        }
    }
    //刚体碰撞监视器
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //string name = collision.collider.name;
    //    //print(name);
    //    if (collision.collider.tag == "gold") 
    //    {
    //        score++;
    //        text.text =  score.ToString();
    //        Destroy(collision.collider.gameObject);
    //    }  
    //}
    private void OnTriggerEnter(Collider other)//碰撞监视
    {
        if (other.tag=="gold") //tag 是识别物体设置的标记
        {
            score++;
            if (score == 7)
            {
                win.SetActive(true);//win文本显示为可见
                Time.timeScale = 0;
                //Application.Quit();
            }
            text.text = score.ToString();
            Destroy(other.gameObject);
        }
        if(other.tag=="add")
        {
            S += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "reduce")
        {
            S -= 4;
            Destroy(other.gameObject);
        }
        //timeText.text = T.ToString();
        if (other.tag == "dead")
        {
            Destroy(other.gameObject);
            lose.SetActive(true);//lose文本显示为可见
            Time.timeScale = 0;
           // Application.Quit();
        }
    }
}
