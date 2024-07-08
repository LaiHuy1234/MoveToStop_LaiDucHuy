using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public static UserDataManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SaveData()
    {

    }
}
