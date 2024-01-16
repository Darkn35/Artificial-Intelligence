using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct AIVariants
    {
        public TextMeshProUGUI textMeshPro;
        public Transform targetAI;
        public Vector3 offset;
    }

    public List<AIVariants> aiVariants;
    public Transform canvasTransform;
    public TextMeshProUGUI textMeshProUGUIPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects spawnObjects = GetComponent<SpawnObjects>();

        foreach (GameObject aiObj in spawnObjects.spawnedAIPrefab)
        {
            var aiVariantTransform = new AIVariants();
            aiVariantTransform.targetAI = aiObj.transform;
            TextMeshProUGUI textPrefab = Instantiate(textMeshProUGUIPrefab, aiObj.transform.position, Quaternion.identity);
            textPrefab.transform.SetParent(canvasTransform);
            aiVariantTransform.textMeshPro = textPrefab;
            aiVariants.Add(aiVariantTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pair in aiVariants)
        {
            if (pair.textMeshPro != null && pair.targetAI != null)
            {
                Vector3 targetPos = pair.targetAI.position + pair.offset;
                pair.textMeshPro.transform.position = Camera.main.WorldToScreenPoint(targetPos);
                float targetAvoidanceQuality = pair.targetAI.GetComponent<NavMeshAgent>().avoidancePriority;
                pair.textMeshPro.text = targetAvoidanceQuality.ToString();
            }
        }
    }
}
