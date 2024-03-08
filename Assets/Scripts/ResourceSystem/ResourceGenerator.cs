using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private BuildingTypeSO buildingType;
    private float timer;
    private float timerMax;

    private void Awake(){
        // 获取建筑类型
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        timerMax = buildingType.resourceGeneratorData.timerMax;
        // Debug.Log("Time.deltaTime" + Time.deltaTime);
        timer = 0f;
    }
    private void Update(){
        // 增量时间，如果一秒update 60次，则deltaTime为1/60
        timer += Time.deltaTime;
        // 重置时间
        if (timer >= timerMax)
        {
            // timer += timerMax;
            timer = 0f;
            // Debug.Log("Ding!" + buildingType.nameString + ":" + buildingType.resourceGeneratorData.resourceType.nameString);
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);
        }

    } 
}
