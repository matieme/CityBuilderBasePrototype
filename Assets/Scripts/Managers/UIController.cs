using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement;
    public Action OnHousePlacement;
    public Action OnSpecialPlacement;
    public Action OnBigStructurePlacement;
    
    public Button placeRoadButton;
    public Button placeHouseButton;
    public Button placeSpecialButton;
    public Button placeBigStructureButton;

    
    private void Start()
    {
        placeRoadButton.onClick.AddListener(() =>
        {
            OnRoadPlacement?.Invoke();
        });
        
        placeHouseButton.onClick.AddListener(() =>
        {
            OnHousePlacement?.Invoke();
        });
        
        placeSpecialButton.onClick.AddListener(() =>
        {
            OnSpecialPlacement?.Invoke();
        });
        
        placeBigStructureButton.onClick.AddListener(() =>
        {
            OnBigStructurePlacement?.Invoke();
        });
    }
}