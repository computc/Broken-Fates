﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonManager {
  public class RoomTemplate : MonoBehaviour {
      public GameObject[] topRooms;
      public GameObject[] bottomRooms;
      public GameObject[] leftRooms;
      public GameObject[] rightRooms;
      public GameObject[] closedRoom;

      public List<GameObject> rooms;

      public float waitTime;

      private bool exitSpawned = false;

      public GameObject xit;

  	// Update is called once per frame
  	void Update () {
          if(waitTime >= 300 && exitSpawned == false)
          {
              Instantiate(xit, rooms[rooms.Count-1].transform.position, Quaternion.identity);
              exitSpawned = true;
              WallScript.rankOne.populateFirstRank();
          }
  		else
          {
              waitTime = Time.frameCount;
          }
  	}
  }

	public enum Direction : int {
		Up = 3,
		Down = 1,
		Right = 4,
		Left = 2,
	}
}