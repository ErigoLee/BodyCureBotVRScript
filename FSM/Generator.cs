using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //Instante Enemy Objects - Enemy(1stage monster) Enemy2(2stage monster) Enemy3(3stage monster) 
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    
    //stage manager variable
    private int stage;
    private bool nextStage;
    private bool enemysGenerator;


    //enemy generator count
    private int enemy_count = 3;
    private int enemy2_count = 3;
    private int enemy3_count = 2;

    //enemys manager variable 
    private List<GameObject> Enemys;

    //dfs state text variable - variable access hinding and Inspector show
    //[SerializeField] private ClearText cleartext;
    //[SerializeField] private ChanceText chanceText;
    //[SerializeField] private StageText stageText;
    //guideUIObjects
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject levelupText;
    [SerializeField] private GameObject gameOverText;
    private bool tryagin = false;

    //generator stop variable
    private bool generatorStop;

    //player.cs access variable 
    [SerializeField] private Player player;


    //DefenceManger
    [SerializeField] private DefenceManger defenceManger;

    void Start()
    {
        stage = 1;
        Enemys = new List<GameObject>();
        nextStage = false;
        enemysGenerator = true;
        victoryText.SetActive(false);
        levelupText.SetActive(false);
        gameOverText.SetActive(false);
        //givechance 시 explain 시 generatorStop이 true 상태이다.
        generatorStop = true;

    }

    public void GeneratorStopTurnOff()
    {
        generatorStop = false;
    }
    public void GeneratorStopTurnOn()
    {
        generatorStop = true;
    }
    public void deleteEnemy(GameObject _enemy)
    {
        foreach(GameObject enemy in Enemys)
        {
            if(enemy == _enemy)
            {
                Enemys.Remove(enemy);
                break;
            }
        }
    }
    IEnumerator PlayerReadyInterval()
    {
        yield return new WaitForSeconds(2.0f);
        generatorStop = false;
        enemysGenerator = true;
        //chanceText.AlertWindowEnd();
        gameOverText.SetActive(false);
    }

    public void DiePlayer()
    {
        StopAllCoroutines();
        generatorStop = true;
        nextStage = false;
        enemysGenerator = false;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < Enemys.Count; i++)
        {
            GameObject enemy = Enemys[i];
            Destroy(enemy);
        }
        Enemys.Clear();
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }

        //chanceText.AlertWindow(stage);
        gameOverText.SetActive(true);
        tryagin = true;
        player.GiveChance();
        StartCoroutine(PlayerReadyInterval());
    }


    IEnumerator Enemy01_Generator()
    {
        for (int i = 0; i < enemy_count; i++)
        {
            float x = Random.Range(-20.0f, 20.0f);
            float z = Random.Range(-10.0f, 10.0f);
            Vector3 spawn = transform.position;
            spawn.x += x;
            spawn.z += z;
            GameObject instance = Instantiate(Enemy, spawn, transform.rotation);
            Enemys.Add(instance);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator Enemy02_Generator()
    {
        for(int i = 0; i < enemy2_count; i++)
        {
            float x = Random.Range(-20.0f, 20.0f);
            float z = Random.Range(-10.0f, 10.0f);
            Vector3 spawn = transform.position;
            spawn.x += x;
            spawn.z += z;
            GameObject instance = Instantiate(Enemy2, spawn, transform.rotation);
            Enemys.Add(instance);
            yield return new WaitForSeconds(1.5f);
        }
    }
    
    IEnumerator Enemy03_Generator()
    {
        for (int i = 0; i < enemy3_count; i++)
        {
            float x = Random.Range(-20.0f, 20.0f);
            float z = Random.Range(-10.0f, 10.0f);
            Vector3 spawn = transform.position;
            spawn.x += x;
            spawn.z += z;
            GameObject instance = Instantiate(Enemy3, spawn, transform.rotation);
            Enemys.Add(instance);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator Stage01()
    {
        //stageText.StageTextStart(stage);
        yield return new WaitForSeconds(2.0f);
        //stageText.StageTextEnd();
        player.isShootTurnOn();
        StartCoroutine(Enemy01_Generator());
        yield return new WaitForSeconds(0.2f);
        nextStage = true;
    }

    IEnumerator Stage02()
    {
        //stageText.StageTextStart(stage);
        if (!tryagin)
        {
            levelupText.SetActive(true);
        }
        
        yield return new WaitForSeconds(2.0f);
        //stageText.StageTextEnd();
        if (!tryagin)
        {
            levelupText.SetActive(false);
        }
        else
        {
            tryagin = false;
        }
        
        player.isShootTurnOn();
        StartCoroutine(Enemy01_Generator());
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Enemy02_Generator());
        yield return new WaitForSeconds(0.2f);
        nextStage = true;
    }

    IEnumerator Stage03()
    {
        //stageText.StageTextStart(stage);
        if (!tryagin)
        {
            levelupText.SetActive(true);
        }
        yield return new WaitForSeconds(2.0f);
        //stageText.StageTextEnd();
        if (!tryagin)
        {
            levelupText.SetActive(false);
        }
        else
        {
            tryagin = false;
        }
        levelupText.SetActive(false);
        player.isShootTurnOn();
        StartCoroutine(Enemy01_Generator());
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Enemy02_Generator());
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Enemy03_Generator());
        yield return new WaitForSeconds(0.2f);
        nextStage = true;
    }    
    void Update()
    {
        

        if (generatorStop)
            return;

        if (stage > 3)
        {

            //cleartext.SetClear();
            victoryText.SetActive(true);
            defenceManger.DenfenceEnd();
            return;
        }

        //다음단계로 갈 수 있고, enemysGenerator가 상태가 false이고 적들의 수가 0일 때,
        if(nextStage && !enemysGenerator && Enemys.Count == 0)
        {
            nextStage = false;
            enemysGenerator = true;
            stage++;

            player.setStage(stage);
            player.isShootTurnOff();
        }


        if (!nextStage && enemysGenerator)
        {
            enemysGenerator = false;
            switch (stage)
            {

                case 1:
                    StartCoroutine(Stage01());
                    break;
                case 2:
                    StartCoroutine(Stage02());
                    break;
                case 3:
                    StartCoroutine(Stage03());
                    break;
            }
        }
        
    }
}
