using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChunkScript : MonoBehaviour
{
    #region scriptReferences

    LevelGeneration levelGeneration;

    #endregion

    [Tooltip("Here you can set how many of the rows should spawn obstacles (4 is max)")] [Range(1, 4)]
    public int obstacleAmount = 0;

    [Tooltip("Enable this if you want a chance for 2 obstacles per row")]
    public bool twoPerRow = false;

    [Tooltip("You can add or remove obstacles to this list, like pirogvagn, puddle, fishinghook")]
    public GameObject[] obstacles;

    [Header("Array list")]
    public List<GameObject[]> arrayList = new List<GameObject[]>();

    private Transform parent1;
    private Transform parent2;
    private Transform parent3;
    private Transform parent4;


    [Tooltip("Ignore this part")]
    [Header("Obstacle spawnpoints")]
    #region rows
    public GameObject[] row_1;
    public GameObject[] row_2;
    public GameObject[] row_3;
    public GameObject[] row_4;
    #endregion

    List<int> generatedRows = new List<int>();
    int[] possibleChoices = { 0, 1, 2, 3};

    List<GameObject> placedObstacles = new List<GameObject>();

    List<int> obstaclesPerRow = new List<int>();

    private void Awake()
    {
       
    }

    void Start()
    {
        //levelGeneration = GameObject.FindGameObjectWithTag("levelGen").GetComponent<LevelGeneration>();
        HideGrid(row_1);
        HideGrid(row_2);
        HideGrid(row_3);
        HideGrid(row_4);

        arrayList.Add(row_1);
        arrayList.Add(row_2);
        arrayList.Add(row_3);
        arrayList.Add(row_4);

        PlaceObstacles();


    }
    
    void Update()
    {
        
    }


    public void PlaceObstacles()
    {
        generatedRows.AddRange(possibleChoices);

        for (int i = 0; i < obstacleAmount; i++)
        {
            int rowNumber = Random.Range(0, generatedRows.Count);

            int chosenNumber = generatedRows[rowNumber];

            ChoseRowTarget(arrayList[chosenNumber]);

            generatedRows.RemoveAt(rowNumber);

        }

    }

    public void ChoseRowTarget(GameObject[] row)
    {
        print(row);

        int rowSpot = Random.Range(0, row.Length);
        SpawnObjects(row[rowSpot].transform.position);

        print("Rowspot" + " " + rowSpot);

        if(twoPerRow)
        {
            int randomPerRow = Random.Range(0, 10);
            if(randomPerRow > 5)
            {
                if (rowSpot == 0)
                {
                    int secondSpot = Random.Range(1, 2);
                    print("secondSpot" + " " + secondSpot);
                    SpawnObjects(row[secondSpot].transform.position);
                }
                else if (rowSpot == 1)
                {
                    int secondSpot = Random.Range(0, 1);
                    if (secondSpot == 1)
                        secondSpot++;

                    print("secondSpot" + " " + secondSpot);
                    SpawnObjects(row[secondSpot].transform.position);
                }
                else if (rowSpot == 2)
                {
                    int secondSpot = Random.Range(0, 1);
                    print("secondSpot" + " " + secondSpot);
                    SpawnObjects(row[secondSpot].transform.position);
                }
            }
        }

        

    }

    public void SpawnObjects(Vector3 spawnPos)
    {
        int obstacleNumber = Random.Range(0, obstacles.Length);
        placedObstacles.Add(Instantiate(obstacles[obstacleNumber], spawnPos, Quaternion.identity));
    }

    public void DestroyObstacles()
    {
        for (int i = 0; i < placedObstacles.Count; i++)
        {
            Destroy(placedObstacles[i]);
        }
    }


    public void HideGrid(GameObject[] rows)
    {

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].GetComponent<MeshRenderer>().enabled = false;
        }

    }

}
