﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteItem : Material {

	protected ItemMemento curMemento;

	//NOTE: ConcreteItem is meant to be found in the dungeon and then turn invisible once picked up.
	//At all times, a ConcreteItem object is a child of the player as an invisible version of the item
	//in the player's hand. This object is referenced for throwing
	public Item inventoryCounterpart;

	//public SpriteRenderer myRenderer;
	//public SpriteRenderer shadowRenderer;

	// animator gets its component every time this script is "enabled". Basically when the script begins.
	protected override void Awake()
	{
		base.Awake();
	  //myRenderer = gameObject.GetComponent<SpriteRenderer>();
	  //shadowRenderer = shadow.GetComponent<SpriteRenderer>();
	}

	protected override void LoadMemento() {
		MementoType = (GameObject) Resources.Load("ItemMemento");
	}

	//Create method for when TimeVibration hits the object
	public override Memento CreateMemento() {
		//Keep track of item's memento so that should the item be placed in the inventory, it can be retrieved
		if(curMemento == null) {
			curMemento = (ItemMemento) base.CreateMemento();
			return (Memento) curMemento;
		} else {
			curMemento.Initialize(this);
      return (Memento) curMemento;
		}
	}

	//Create method for if this item is in the inventory when it was saved.
	//CreateMemento and CreateInventoryMemento are built to combine for the heldItem
	public ItemMemento CreateInventoryMemento() {
		if(curMemento == null) {
			curMemento = Instantiate(MementoType).GetComponent<ItemMemento>();
			curMemento.InitializeInventory(true);
			return curMemento;
		} else {
			curMemento.InitializeInventory(true);
			return curMemento;
		}
	}

	//Keep track of item's memento so that should the item be placed in the inventory, it can be retrieved
	public override void useMemento(Memento oldState) {
		base.useMemento(oldState);
		//Empty ConcreteItem's curMemento variable
		EmptyMemento();
	}

	public void EmptyMemento() {
		curMemento = null;
	}

	public ItemMemento GetMemento() {
		return curMemento;
	}

	/*
	private void setVisibility(bool state) {
		myRenderer.enabled = state;
		shadowRenderer.enabled = state;
	}*/

  //Picks up this object and returns null, telling the program the Use()
  //function cannot be done on this item while in the players' hand
  public override Item PickedUp(GameObject holder) {
		//Pick up
		base.PickedUp(holder);
    //Return this object's inventory counterpart so it can be rendered and added to the inventory
    return inventoryCounterpart;
  }

  public Item GetItem() {
		return inventoryCounterpart;
	}

	// Use this item
	public override void Use () {
		//Do its effect

		//If this item is destroyed upon use:

			//Send back a message to the Inventory to refill the players' hand

			//Destroy the item

	}
}
