﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonCSharp<T> where T : new() {

	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new T();
			}
			return instance;
		}
	}
}
