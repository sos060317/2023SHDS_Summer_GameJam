using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoiceAbility()
    {
        List<GameObject> choiceCard = new List<GameObject>(abilityCard);

        GameObject[] choiceAbiliey = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            int choiceNumber = Random.RandomRange(0, choiceCard.Count);

            choiceAbiliey[i] = choiceCard[choiceNumber];
            
            var card = Instantiate(choiceAbiliey[i], cardPosition[i].position, Quaternion.identity, canvas.transform);

            StartCoroutine(DownCard(card, cardPosition[i], i));

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
}
