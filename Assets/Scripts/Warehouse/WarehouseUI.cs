using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseUI : MonoBehaviour
{
    public static Action<WarehouseUpgrade> OnUpgradeRequest;

    private WarehouseUpgrade _warehouseUpgrade;
    private void Start()
    {
        _warehouseUpgrade = GetComponent<WarehouseUpgrade>();
    }

    public void OpenWarehouseUpgradePanel()
    {
        OnUpgradeRequest?.Invoke(_warehouseUpgrade);
    }
}
