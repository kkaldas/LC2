﻿using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class SignUp : MonoBehaviour
{
    [SerializeField] SignIn signIn;

    [SerializeField] string username;

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = signIn.GetEmail(),
            Username = username,
            Password = signIn.GetPassword()
        };

        print(signIn.GetEmail());
        print(username);
        print(signIn.GetPassword());

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, signIn.OnFailedLoginOrSignUp);
    }

    public void SetUsername(string username)
    {
        this.username = username;
    }

    public void SetEmail(string text)
    {
        signIn.SetEmail(text);
    }

    public void SetPassword(string text)
    {
        signIn.SetPassword(text);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("user registered!!");
    }
}
