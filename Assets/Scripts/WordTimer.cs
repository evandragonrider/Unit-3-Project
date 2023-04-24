using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
 public WordManager wordManager;
 public float wordDelay = 20f;
 public float nextWordTime;

 private void Update(){
	 if (Time.time >= nextWordTime){
		 wordManager.AddWord();
		 nextWordTime = Time.time +wordDelay;
		 Debug.Log("WordTimer clone");
		 //wordDelay *= 0.99f;
	 }
 }
}