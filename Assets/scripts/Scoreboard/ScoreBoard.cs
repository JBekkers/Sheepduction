using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    [SerializeField] public float EndScore;
    [SerializeField] public List<float> Times;
    private ScoreData sd;
    public bool End;
    private int num;
    private Text hs1txt;
    private Text hs2txt;
    private Text hs3txt;
    private Text hs4txt;
    private Text hs5txt;


    public static ScoreBoard instance { get; private set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sd = SaveManager.load();
        SaveManager.Save(sd);

        Times.Add(sd.HS1); Times.Add(sd.HS2); Times.Add(sd.HS3); Times.Add(sd.HS4); Times.Add(sd.HS5);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        //Debug.LogError(Times);
        sd = SaveManager.load();

        if (Input.GetKeyDown(KeyCode.K))
        {
            UpdateScoreboard();
        }


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            //get text objects to display highscores on
            hs1txt = GameObject.Find("Number1").GetComponent<Text>() as Text;
            hs2txt = GameObject.Find("Number2").GetComponent<Text>() as Text;
            hs3txt = GameObject.Find("Number3").GetComponent<Text>() as Text;
            hs4txt = GameObject.Find("Number4").GetComponent<Text>() as Text;
            hs5txt = GameObject.Find("Number5").GetComponent<Text>() as Text;

            //set score on the board
            hs1txt.text = sd.HS1.ToString() + " sec";
            hs2txt.text = sd.HS2.ToString() + " sec";
            hs3txt.text = sd.HS3.ToString() + " sec";
            hs4txt.text = sd.HS4.ToString() + " sec";
            hs5txt.text = sd.HS5.ToString() + " sec";

            //Debug.Log("scene is loaded");
        }
    }

    public void UpdateScoreboard()
    {
        Times.Add((int)EndScore);
        Times.Sort();
        Times.Reverse();

        sd.HS1 = Times[0];
        sd.HS2 = Times[1];
        sd.HS3 = Times[2];
        sd.HS4 = Times[3];
        sd.HS5 = Times[4];

        SaveManager.Save(sd);
    }
}

