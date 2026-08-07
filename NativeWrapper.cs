using System;
using Godot;

namespace Netfox;

public abstract partial class NativeWrapper<T>: RefCounted, INativeWrapper<T> where T : GodotObject
{
	public T ObjectInstance { get; private set; }

	/**
	 * THIS VIRTUAL GETTER MUST BE STATIC INITIALIZED
	 */
	protected virtual GDScript GdScript => null;
	/**
	 * THIS VIRTUAL GETTER MUST BE STATIC INITIALIZED
	 */
	protected virtual StringName GdClassName => GetType().Name;

	/**
	 * Initializes an Object
	 */
	protected NativeWrapper()
	{
		SetInstance(TryCreateInstance());
	}

	/**
	 * if resource == null, it sets ObjectInstance to null. Good for having a wrapper ready just in case
	 */
	protected NativeWrapper(T resource, bool tryInstantiateIfNull = false)
	{
		if (resource == null && tryInstantiateIfNull)
		{
			resource = TryCreateInstance();
		}
		SetInstance(resource);
	}
	
	public virtual NativeWrapper<T> SetInstance(T resource)
	{
		if (resource != null)
		{
			var classname = GetObjectClassName(resource);
			if (classname != GdClassName)
			{
				throw new InvalidCastException(
					$"NativeWrapper InvalidCastException: Expected {GdClassName} but got {classname}"
				);
			}
		}
		ObjectInstance = resource;
		return this;
	}

	private T TryCreateInstance()
	{
		if (GdScript != null)
		{
			return (T) GdScript.New();
		}
		else if (ClassDB.CanInstantiate(GdClassName))
		{
			return (T)ClassDB.Instantiate(GdClassName);
		}
		else
		{
			return (T)ClassDB.Instantiate(GetType().Name);
		}
	}

	public static string GetObjectClassName(GodotObject obj)
	{
		var script = (Script)obj.GetScript();
		string scriptName = script?.GetGlobalName();
		return string.IsNullOrWhiteSpace(scriptName) ? obj.GetClass() : scriptName;
	}

	public static implicit operator T(NativeWrapper<T> myObj)
	{
		return myObj?.ObjectInstance;
	}

}
