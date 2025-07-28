using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public GameObject panel = null;
    public GameObject button = null;
    public Text Level = null;
    public Text Score = null;
    public Animator Enviroment = null;
    public GameObject obj = null;

    // Start is called before the first frame update
    private Animator anime = null;
    private float speed = 0;
    private float curScore = 0;
    private Vector2 pos = Vector2.zero;

    public float factor = 1;
    private float waittimer = 0;
    private List<GameObject> objList = null;
    private GameObject curr = null;
    private Color tempCol = Color.black;
    private bool active = false;

    void Start()
    {
        anime = GetComponent<Animator>();
        pos = new Vector2(600, 100);
        objList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if( waittimer < Time.time && speed > 0)
        {
            curr = getObjfromPool();
            if (!curr)
            {
                curr = Instantiate(obj);
                objList.Add(curr);
            }
            if (curr)
            {
                curr.transform.position = new Vector3(1.1920929e-06f, 13.5000725f, 125);
                curr.SetActive(true);
                randomizeObj(curr);
                curr.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed * factor);
            }

            waittimer = Time.time + 10/speed;
        }


        
    }

    public void setPos(Vector2 v)
    {
        if (v.x >= 0 && v.y >= 0)
            pos = v;

        if(speed > 0)
        {
             if (pos.x > 0 && pos.x <= 426)
            anime.SetFloat("Pos", Mathf.Lerp(anime.GetFloat("Pos"), 0, speed / 5));
        else if (pos.x > 426 && pos.x <= 854)
            anime.SetFloat("Pos", Mathf.Lerp(anime.GetFloat("Pos"), 0.5f, speed / 5));
        else if (pos.x > 854 && pos.x <= 1280)
            anime.SetFloat("Pos", Mathf.Lerp(anime.GetFloat("Pos"), 1, speed / 5));


        if (pos.y <= 360)
            anime.SetFloat("verticle", Mathf.Lerp(anime.GetFloat("verticle"), 0, speed / 5));
        else 
            anime.SetFloat("verticle", Mathf.Lerp(anime.GetFloat("verticle"), 1, speed / 5));

        if (pos.x > 0 && pos.x <= 426)
            anime.SetFloat("horizontal", Mathf.Lerp(anime.GetFloat("horizontal"), -1, speed / 5));
        else if(pos.x > 426 && pos.x <= 854)
            anime.SetFloat("horizontal", Mathf.Lerp(anime.GetFloat("horizontal"), 0, speed / 5));
        else if (pos.x > 854 && pos.x <= 1280)
            anime.SetFloat("horizontal", Mathf.Lerp(anime.GetFloat("horizontal"), 1, speed / 5));

        }
        
       

        if (panel)
        {
            if (pos.x > 0 && pos.x <= 426)
            {
                panel.transform.GetChild(0).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(0).GetComponent<Image>().color, new Color32(15, 189, 250, 150), speed / 5);
                panel.transform.GetChild(1).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(1).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                panel.transform.GetChild(2).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(2).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);

                if (pos.y <= 360)
                {
                    panel.transform.GetChild(3).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(3).GetComponent<Image>().color, new Color32(15, 189, 250, 150), speed / 5);
                    panel.transform.GetChild(4).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(4).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(5).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(5).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                }
                else
                {
                    panel.transform.GetChild(3).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(3).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(4).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(4).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(5).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(5).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                }
            }
            else if (pos.x > 426 && pos.x <= 854)
            {
                panel.transform.GetChild(0).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(0).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                panel.transform.GetChild(1).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(1).GetComponent<Image>().color, new Color32(15, 189, 250, 150), speed / 5);
                panel.transform.GetChild(2).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(2).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);

                if (pos.y <= 360)
                {
                    panel.transform.GetChild(3).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(3).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(4).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(4).GetComponent<Image>().color, new Color32(15, 189, 250, 150), speed / 5);
                    panel.transform.GetChild(5).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(5).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                }
                else
                {
                    panel.transform.GetChild(3).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(3).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(4).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(4).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(5).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(5).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                }
            }
            else if (pos.x > 854 && pos.x <= 1280)
            {
                panel.transform.GetChild(0).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(0).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                panel.transform.GetChild(1).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(1).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                panel.transform.GetChild(2).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(2).GetComponent<Image>().color, new Color32(15, 189, 250, 150), speed / 5);

                if (pos.y <= 360)
                {
                    panel.transform.GetChild(3).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(3).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(4).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(4).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(5).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(5).GetComponent<Image>().color, new Color32(15, 189, 250, 150), speed / 5);
                }
                else
                {
                    panel.transform.GetChild(3).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(3).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(4).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(4).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                    panel.transform.GetChild(5).GetComponent<Image>().color = Color32.Lerp(panel.transform.GetChild(5).GetComponent<Image>().color, new Color32(255, 255, 255, 80), speed / 5);
                }
            }
        }


        


    }

    public void setSpeed(float s)
    {
        speed = s;

        foreach (GameObject g in objList)
        {
            if (g.activeInHierarchy)
                g.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed * factor);
        }

        if (Enviroment)
            Enviroment.speed = 1f * speed;


        if (Level && speed != 0)
            Level.text = speed + "";


    }

    public double map(double x, double in_min, double in_max, double out_min, double out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public void GameOver(bool b)
    {
        if(speed > 0)
        {
            setSpeed(0);
            if (b)
                anime.SetTrigger("Death1");
            else
                anime.SetTrigger("Death2");

            button.SetActive(true);
            button.GetComponentInChildren<Text>().text = "Try Again";
        }
    }
    public void StartOver()
    {
        anime.Play("Start");
        setSpeed(1);
        anime.SetTrigger("Start");
        curScore = 0;
        Score.text = 0 + "";
        foreach (GameObject g in objList)
        {
            g.SetActive(false);
        }
        button.SetActive(false);
        
    }



    public void setScore()
    {
        curScore++;
        if (Score && speed != 0)
        {
            Score.text = curScore + "";
            setSpeed(1 + ((int)curScore / 30) * 0.5f);
        }



    }

    private GameObject getObjfromPool()
    {
        foreach(GameObject g in objList)
        {
            if (!g.activeInHierarchy)
                return g;
        }

        return null;
    }

    private void randomizeObj(GameObject g)
    {
        tempCol = Color.HSVToRGB(Random.Range(0, 1f), 1, 1);

        foreach (Transform t in g.transform)
        {
            t.gameObject.SetActive(Random.Range(0, (int)speed + 1) != 0);
            t.GetComponent<Renderer>().material.color = tempCol;
        }

        if (g.transform.GetChild(3).gameObject.activeInHierarchy == true && g.transform.GetChild(4).gameObject.activeInHierarchy == true && g.transform.GetChild(5).gameObject.activeInHierarchy == true)
            g.transform.GetChild(Random.Range(3,6)).gameObject.SetActive(false);

        if(g.transform.GetChild(0).gameObject.activeInHierarchy == false && g.transform.GetChild(1).gameObject.activeInHierarchy == false && g.transform.GetChild(2).gameObject.activeInHierarchy == false && g.transform.GetChild(3).gameObject.activeInHierarchy == false && g.transform.GetChild(4).gameObject.activeInHierarchy == false && g.transform.GetChild(5).gameObject.activeInHierarchy == false)
            g.transform.GetChild(Random.Range(1, 6)).gameObject.SetActive(true);
    }

}
