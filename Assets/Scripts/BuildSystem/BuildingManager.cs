using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{   
    // SerializeField 可将private的对象显示在unity面板上
    // [SerializeField] private BuildingTypeSO buildingType;
    private Camera mainCamera;
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType;
    private void Start(){
        mainCamera = Camera.main;

        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list[2];

    }
    // Update is called once per frame
    void Update()
    {
        // GetMouseButton与GetMouseButtonDown区分，前者点击一次会执行多次，后者只执行一次
        if (Input.GetMouseButtonDown(0)){
            // 实例化prefab
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
        // mouseVisualTransform.position = GetMouseWorldPosition();
        // if (Input.GetKeyDown(KeyCode.G))
        // {
        //     buildingType = buildingTypeList.list[2];
        // }
    
    }

    private Vector3Int GetMouseWorldPosition(){
        // 在此处转为整型值，使得每个个Tile只能放置在Tile中心
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3Int((int)mouseWorldPosition.x, (int)mouseWorldPosition.y, 0);
    }
}
