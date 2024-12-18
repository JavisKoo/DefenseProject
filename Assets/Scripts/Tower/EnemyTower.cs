using Chracter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemyTower : BaseCharacter
{
    //Spawn

    [Header("UI")]
    public GameObject[] enemyObjs;

    public List<EnemySpawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd = false;
    public float curSpawnDelay = 0;
    public float nextSpawnDelay = 0;

    float spwanDelay;
    string spawnType;

    public Transform enemySpawnPoint;

    private bool isStageEnd = false;
    //UI
    [Header("UI")]
    public Slider towerHPSlider;
    public Text towerHPText;

    //Game Clear
    public GameObject stageClearPanel;

    private void Awake()
    {
        //spawn
        spawnList = new List<EnemySpawn>();

        //StartCoroutine(WaitStageManager());
    }

    private void Start()
    {
        SetCharacterSettings(500);
        towerHPSlider.maxValue = MaxHealth;
        ReadSpawnFile();
    }

    private void Update()
    {
        towerHPSlider.value = CurrentHealth;
        towerHPText.text = CurrentHealth + " / " + MaxHealth;

        //spawn
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            curSpawnDelay = 0;
        }

        //stage end
        /*if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;

        }*/
    }

    void ReadSpawnFile()
    {
        //���� �ʱ�ȭ
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        //���� �б�
        Debug.Log("Stage" + StageManager.Instance.stage.ToString());
        TextAsset textFile = Resources.Load("Stage" + StageManager.Instance.stage.ToString()) as TextAsset;
        StringReader reader = new StringReader(textFile.text);

        while(reader != null)
        {
            string line = reader.ReadLine();
            Debug.Log(line);

            if (line == null)
                break;


            EnemySpawn spawnData = new EnemySpawn();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.type = line.Split(',')[1].ToString();
            spawnList.Add(spawnData);
        }
        //�ؽ�Ʈ ���� �ݱ�
        reader.Close();

        //ù��° ���� ������ ����
        nextSpawnDelay = spawnList[0].delay;
    }

    void SpawnEnemy()
    {
        int enemyIndex = 0;
        switch (spawnList[spawnIndex].type)
        {
            case "�˻�":
                enemyIndex = 0;
                break;

            case "����":
                enemyIndex = 1;
                break;

            case "�����ü�":
                enemyIndex = 2;
                break;

            case "���":
                enemyIndex = 3;
                break;

            case "������":
                enemyIndex = 4;
                break;

            case "������":
                enemyIndex = 5;
                break;

            case "���˻�":
                enemyIndex = 6;
                break;

            case "�̳�Ÿ��ν�":
                enemyIndex = 7;
                break;

            case "��Ÿ��ν�":
                enemyIndex = 8;
                break;

            case "��":
                enemyIndex = 9;
                break;

            case "�����":
                enemyIndex = 10;
                break;

            case "�罿���":
                enemyIndex = 11;
                break;

            case "��������":
                enemyIndex = 12;
                break;

            case "���ɼ���":
                enemyIndex = 13;
                break;

            case "�巡��":
                enemyIndex = 14;
                break;
        }
        GameObject enemy = GameObject.Instantiate(enemyObjs[enemyIndex], enemySpawnPoint);
        enemy.tag = "Enemy";
        enemy.layer = 7;
        enemy.GetComponent<BaseCharacter>().Spawn();

        spawnIndex++;
        if (spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

        //���� ���� ������
        nextSpawnDelay = spawnList[spawnIndex].delay;
    }

    public override void TakeDamage(float damage, float enemyAccuracy = 200)
    {
        if (isStageEnd)
            return;


        float finalDamage = damage - Armor;
        if (finalDamage <= 0)
        {
            finalDamage = 1;
        }

        CurrentHealth -= finalDamage;

        switch (StageManager.Instance.stage)
        {
            case 1:
                if (CurrentHealth <= MaxHealth / 10 * 8) //80%���Ϸ� ��������
                {
                    StageManager.Instance.stage++;
                    StageManager.Instance.StageStart();
                }
                break;

            case 2:
                if (CurrentHealth <= MaxHealth / 10 * 4) //40%���Ϸ� ��������
                {
                    StageManager.Instance.stage++;
                    StageManager.Instance.StageStart();
                }
                break;
        }
        
        if (CurrentHealth <= 0)
        {
            Time.timeScale = 0f;
            stageClearPanel.SetActive(true);
            //Die();
            CurrentHealth = 0;
        }


        if (healthBar != null)
        {
            healthBar.TowerHealth(CurrentHealth, MaxHealth);
        }
    }

    /*public virtual void Die()
    {

    }*/

    protected IEnumerator WaitStageManager()
    {
        yield return new WaitForSeconds(0.2f);
        ReadSpawnFile();

    }
}
