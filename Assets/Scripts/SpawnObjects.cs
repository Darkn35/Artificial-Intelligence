using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<Transform> BlueDestination, RedDestination, GreenDestination, YellowDestination;
    public Transform BlueParent, RedParent, GreenParent, YellowParent;
    public GameObject blueAI, redAI, greenAI, yellowAI;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in BlueParent.GetComponentInChildren<Transform>())
        {
            BlueDestination.Add(t);
        }
        foreach (Transform t in RedParent.GetComponentInChildren<Transform>())
        {
            RedDestination.Add(t);
        }
        foreach (Transform t in GreenParent.GetComponentInChildren<Transform>())
        {
            GreenDestination.Add(t);
        }
        foreach (Transform t in YellowParent.GetComponentInChildren<Transform>())
        {
            YellowDestination.Add(t);
        }
        SpawnAIObjects();
    }

    void SpawnAIObjects()
    {
        int index = 0;
        foreach (Transform t in BlueDestination)
        {
            GameObject AIPrefab = Instantiate(blueAI, RedDestination[index].position, Quaternion.identity);
            AIPrefab.GetComponent<AI_Test>().Destination = t;
            AIPrefab.GetComponent<AI_Test>().AgentSpeed = 3.5f;
            AIPrefab.GetComponent<AI_Test>().AvoidanceType = UnityEngine.AI.ObstacleAvoidanceType.HighQualityObstacleAvoidance;
            AIPrefab.GetComponent<AI_Test>().AvoidancePredictionTime = 5f;
            AIPrefab.GetComponent<AI_Test>().StoppingDistance = 0f;
            index = index + 1;
        }
        index = 0;
        foreach (Transform t in RedDestination)
        {
            GameObject AIPrefab = Instantiate(redAI, BlueDestination[index].position, Quaternion.identity);
            AIPrefab.GetComponent<AI_Test>().Destination = t;
            AIPrefab.GetComponent<AI_Test>().AgentSpeed = 3.5f;
            AIPrefab.GetComponent<AI_Test>().AvoidanceType = UnityEngine.AI.ObstacleAvoidanceType.MedQualityObstacleAvoidance;
            AIPrefab.GetComponent<AI_Test>().AvoidancePredictionTime = 5f;
            AIPrefab.GetComponent<AI_Test>().StoppingDistance = 0f;
            index = index + 1;
        }
        index = 0;
        foreach (Transform t in GreenDestination)
        {
            GameObject AIPrefab = Instantiate(greenAI, YellowDestination[index].position, Quaternion.identity);
            AIPrefab.GetComponent<AI_Test>().Destination = t;
            AIPrefab.GetComponent<AI_Test>().AgentSpeed = 3.5f;
            AIPrefab.GetComponent<AI_Test>().AvoidanceType = UnityEngine.AI.ObstacleAvoidanceType.LowQualityObstacleAvoidance;
            AIPrefab.GetComponent<AI_Test>().AvoidancePredictionTime = 5f;
            AIPrefab.GetComponent<AI_Test>().StoppingDistance = 0f;
            index = index + 1;
        }
        index = 0;
        foreach (Transform t in YellowDestination)
        {
            GameObject AIPrefab = Instantiate(yellowAI, GreenDestination[index].position, Quaternion.identity);
            AIPrefab.GetComponent<AI_Test>().Destination = t;
            AIPrefab.GetComponent<AI_Test>().AgentSpeed = 3.5f;
            AIPrefab.GetComponent<AI_Test>().AvoidanceType = UnityEngine.AI.ObstacleAvoidanceType.MedQualityObstacleAvoidance;
            AIPrefab.GetComponent<AI_Test>().AvoidancePredictionTime = 5f;
            AIPrefab.GetComponent<AI_Test>().StoppingDistance = 0f;
            index = index + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
