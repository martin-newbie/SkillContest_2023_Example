using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    private static InGameManager _instance = null;
    public static InGameManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }
    [Header("UI")]
    public MainCanvas canvas;
    public Text messageText;
    public Animator textAnimator;

    [Header("Map Info")]
    public Vector2 borderSize;

    [Header("Stage Info")]
    public int stageIndex;
    public List<StageBase> stages = new List<StageBase>();
    StageBase curStage;

    [Header("Particles")]
    public ParticleSystem[] effectParticles;

    [Header("Positions")]
    public Transform playerSpawnPos;

    [Header("Objects")]
    public Player[] playerPrefabs;
    public Player curPlayer;
    public GameObject skillBomb;

    [Header("Skill")]
    public float healMaxDelay = 15f;
    public float bombMaxDelay = 30f;
    float healCurDelay;
    float bombCurDelay;

    [Header("Score")]
    public float score;
    public float scoreIncreasing = 10f;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(Vector3.zero, (Vector3)borderSize);
    }

    private void Start()
    {
        stageIndex = TempData.Instance.stageIndex;

        stages = GetComponents<StageBase>().ToList();
        curStage = stages[stageIndex];

        StartCoroutine(IntroLogic());
    }

    IEnumerator IntroLogic()
    {
        int charIdx = TempData.Instance.curFlightIndex;

        canvas.currentFlight.SetFlight(charIdx);
        canvas.weaponStatus.InitWeapon(charIdx);

        curPlayer = Instantiate(playerPrefabs[charIdx], playerSpawnPos.position, Quaternion.identity);

        yield return StartCoroutine(moveTo(curPlayer.transform, new Vector3(0, -4), 1f));
        curPlayer.playerActive = true;

        yield return StartCoroutine(IngameLogic());

        yield break;
    }

    IEnumerator IngameLogic()
    {
        yield return StartCoroutine(curStage.StageRoutine());
        // game clear

        TempData.Instance.stageScore[stageIndex] = score;

        SceneManager.LoadScene("Ranking");
        yield break;

        if (stageIndex < 2)
        {
            TempData.Instance.stageIndex++;
            SceneManager.LoadScene("InGame");
            
        }
        else
        {
            SceneManager.LoadScene("Ranking");
        }
    }


    IEnumerator moveTo(Transform subject, Vector3 targetPos, float duration)
    {
        float timer = 0f;
        Vector3 startPos = subject.position;

        while (timer <= duration)
        {
            subject.position = Vector3.Lerp(startPos, targetPos, easeOutCubic(timer / duration));
            timer += Time.deltaTime;
            yield return null;
        }


        yield return null;

        float easeOutCubic(float x)
        {
            return 1f - Mathf.Pow(1f - x, 3f);
        }
    }

    public bool IsInsideBorder_X(float x, float radius)
    {
        return borderSize.x / 2f >= x + radius && -borderSize.x / 2f <= x - radius;
    }
    public bool IsInsideBorder_Y(float y, float radius)
    {
        return borderSize.y / 2f >= y + radius && -borderSize.y / 2f <= y - radius;
    }

    public ParticleSystem PlayEffectParticle(int index, Vector3 pos)
    {
        var result = effectParticles[index];
        result.transform.position = pos;
        result.Play();
        return result;
    }

    private void Update()
    {
        SkillSetting();
        ScoreSetting();
    }

    void SkillSetting()
    {
        if (curPlayer == null) return;

        healCurDelay += Time.deltaTime;
        bombCurDelay += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X) && healCurDelay >= healMaxDelay)
        {
            curPlayer.HpRecover(curPlayer.maxHp / 2f);
            healCurDelay = 0f;
        }

        if (Input.GetKeyDown(KeyCode.C) && bombCurDelay >= bombMaxDelay)
        {
            Instantiate(skillBomb, curPlayer.transform.position, Quaternion.identity);
            bombCurDelay = 0f;
        }

        canvas.healSkillGauge.SetFill(1 - healCurDelay / healMaxDelay);
        canvas.bombSkillGauge.SetFill(1 - bombCurDelay / bombMaxDelay);
    }

    void ScoreSetting()
    {
        canvas.scoreBox.SetScore(score);

        if (curPlayer == null) return;

        score += scoreIncreasing * Time.deltaTime; // 기본 스코어 업
    }

    public void ScoreUp(float amount = 100f)
    {
        score += amount;
    }

    public void PrintMessage(string text)
    {
        messageText.text = text;
        textAnimator.SetTrigger("MessageTrigger");
    }
}
