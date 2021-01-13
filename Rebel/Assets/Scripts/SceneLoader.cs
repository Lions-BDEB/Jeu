﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   public int currentScene;
   public void LoadNextScene()
   {
      currentScene = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentScene + 1);
   }
}