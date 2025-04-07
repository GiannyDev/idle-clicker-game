using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface MineLocation
{
    void ApplyManagerBoost();
}

public class BaseWorkManager : MonoBehaviour
{
    [SerializeField] private GameObject boostButton;
    [SerializeField] private Image boostIcon;
    
    public MineLocation CurrentMineLocation { get; set; }
    public WorkManagerInfo ManagerAssigned { get; set; }
    public static Action<MineLocation> OnManagerClicked;
    
    private void Start()
    {
        HideBoostButton();
    }

    // private void Update() // Respuesta a Nathan para no seleccionar cosas detras de un UI Element
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // This prevents to click the Manager if we are clicking a UI Element
    //         if (EventSystem.current.IsPointerOverGameObject())
    //         {
    //             return;
    //         }
    //         
    //         // Here we are using Raycast to select our Manager and open their Panel
    //         RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
    //         if (hit.collider != null)
    //         {
    //             if (hit.collider.gameObject.GetComponent<BaseWorkManager>() != null)
    //             {
    //                 OnManagerClicked?.Invoke(CurrentMineLocation);
    //             }
    //         }
    //     }
    // }

    public void RunBoost()
    {
        CurrentMineLocation?.ApplyManagerBoost();
    }
    
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        OnManagerClicked?.Invoke(CurrentMineLocation);
    }

    public void HideBoostButton()
    {
        boostButton.SetActive(false);
    }

    public void SetupBoostButton()
    {
        if (ManagerAssigned != null)
        {
            boostButton.SetActive(true);
            boostIcon.sprite = ManagerAssigned.BoostIcon;
        }
    }
}
