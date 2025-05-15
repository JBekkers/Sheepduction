using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject ufoPrefab;
    public GameObject ufoPrefab2;
    private GameObject newufo;

    public List<GameObject> Animallist;
    private GameObject pickedAnimal;

    private int rand;
    private int ufopick;
    private int numb;

    private int waves;
    private int SpawnedWaves;
    public bool StopWave;

    private float timer;

    public List<GameObject> ufoLeft;
    private int ufoSpawned;
    public bool GameEnd;

    public bool NextWave;

    public GameObject ScareCrow;
    public static WaveSpawner instance { get; private set; }

    private void Start()
    {
        ufoSpawned = 1;
        numb = 0;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
         if (!StopWave)
        {
            timer += Time.deltaTime;
        }

        if(ufoLeft.Count <= 0 && StopWave == true)
        {
            //spawn scarecrow
            StopWave = false;
            Instantiate(ScareCrow);
            SpawnedWaves = 0;
            //if scarecrow gets shot than nextwave is set to true
        }

        //als alle ufos dood zijn dan moet hij pas een nieuwe wave spawnen

        if (NextWave == true)
        {
            for (int i = 0; i < ufoSpawned; i++)
            {
                SpawnUfo();
            }
            waves++;
            SpawnedWaves++;
        }

        if (SpawnedWaves >= 3)
        {
            StopWave = true;
            NextWave = false;
        } 

        if (waves == 10)
        {
            waves = 0;
            ufoSpawned++;
            numb += 14;
        }

        if(Animallist.Count < 3)
        {
            ScoreBoard.instance.EndScore = timer;
            ScoreBoard.instance.End = true;
            SceneManager.LoadScene(0);
            ScoreBoard.instance.UpdateScoreboard();
        }
    }

    public void SpawnUfo()
    {
        if (Animallist.Count > 0)
        {
            rand = Random.Range(0, Animallist.Count);
            ufopick = Random.Range(0, 100);

            pickedAnimal = Animallist[rand];

            if (ufopick < numb)
            {
                newufo = Instantiate(ufoPrefab2);
                newufo.GetComponent<ufoController>().CanShoot = true;
            }else { newufo = Instantiate(ufoPrefab); }


            newufo.transform.position = new Vector3(pickedAnimal.transform.position.x, 30 , pickedAnimal.transform.position.z);
            newufo.GetComponent<ufoController>().target = pickedAnimal;
            Animallist.Remove(pickedAnimal);
            //Debug.Log(totalSpawned);
        }
    }
}
