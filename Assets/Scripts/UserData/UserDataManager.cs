﻿using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class UserDataManager : PlayFabIDConsumer
{

    UserData userData;

    UserDataNetworkPuller playerDataNetworkPuller;
    UserDataNetworkPusher playerDataNetworkPusher;

    public UserDataManager()
    {

        userData = new UserData();
        playerDataNetworkPuller = new UserDataNetworkPuller();
        playerDataNetworkPusher = new UserDataNetworkPusher();
    }

    public string GetDataLocally(string key)
    {
        return userData.GetData(key);
    }

    public void StoreDataLocally(string key, string value)
    {
        userData.Store(key, value);
    }
   
    public void SaveAllDataOnServer()
    {
        playerDataNetworkPusher.PushUserData(userData);
    }

    public void RetreiveAllDataFromServer()
    {
        Dictionary<string, UserDataRecord> userDataRecords =
                        playerDataNetworkPuller.GetUserData( base.GetPlayFabId() );

        Dictionary<string, string> data = new Dictionary<string, string>();

        foreach (KeyValuePair<string, UserDataRecord> entry in userDataRecords)
        {
            data.Add(entry.Key, entry.Value.ToString());
        }

        userData.SetData(data);
    }
    
}