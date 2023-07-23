using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
using VSCodeEditor;

public class LevelUpManager : MonoBehaviour
{
    public static LevelUpManager instance = null;

    public static LevelUpManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    [SerializeField] private List<GameObject> abilityCard = new List<GameObject>();
    [SerializeField] private Transform[] cardPosition;
    [SerializeField] private Transform[] cardFirstPosition;

    [SerializeField] private Button Leftbt;
    [SerializeField] private Button Middlebt;
    [SerializeField] private Button Rightbt;
    
    GameObject[] choiceAbiliey = new GameObject[3];


    public Canvas canvas;

    //private int arrNumber = 0;

    private void Awake()
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

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.UI.Button bt = null;
    }


// Update is called once per frame
    void Update()
    {
        
    }

    public void ChoiceAbility()
    {
        List<GameObject> choiceCard = new List<GameObject>(abilityCard);


        for (int i = 0; i < 3; i++)
        {
            int choiceNumber = Random.RandomRange(0, choiceCard.Count);

            choiceAbiliey[i] = choiceCard[choiceNumber];
            
            var card = Instantiate(choiceAbiliey[i], cardPosition[i].position, Quaternion.identity, canvas.transform);

            StartCoroutine(DownCard(card, cardPosition[i], i));
            int idx = new int();
            idx = i;
            card.GetComponent<Button>().onClick.AddListener(() => UpCardCoroutineCaller(idx));

            choiceCard.RemoveAt(choiceNumber);
        }
    }

    IEnumerator DownCard(GameObject abilityCard, Transform firstPosition, int num)
    {
        float count = 0;
        
        while (count <= 1f)
        {
            count += Time.deltaTime;
            abilityCard.transform.position = Vector3.Lerp(firstPosition.position, cardFirstPosition[num].position, count);
            yield return null;
        }
        
        while (count >= 0.7f)
        {
            count -= Time.deltaTime;
            abilityCard.transform.position = Vector3.Lerp(firstPosition.position, cardFirstPosition[num].position, count);
            yield return null;
        }
    }

    IEnumerator UpCard(int index)
    {
        float count = 0;

        while (count <= 1f)
        { 
            count += Time.deltaTime;
            abilityCard[index].transform.position =
                Vector3.Lerp(cardFirstPosition[index].position, cardPosition[index].position, count);
            yield return null;
        }
    }

    public void UpCardCoroutineCaller(int index)
    {
        StartCoroutine(UpCardSeparate(index));
    }

    IEnumerator UpCardSeparate(int selectedIdx)
    {
        StartCoroutine(UpCard(selectedIdx));

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            if (i == selectedIdx)
                continue;
            
            StartCoroutine(UpCard(i));
        }
    }
}
