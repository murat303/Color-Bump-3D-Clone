using System;
using System.Collections.Generic;

public class Messenger
{
    static Dictionary<Type, List<Delegate>> mappings = new Dictionary<Type, List<Delegate>>();

    public static void Register<T>(Action<T> action)
    {
        var type = typeof(T);
        if (!mappings.ContainsKey(type))
        {
            mappings.Add(type, new List<Delegate>());
        }

        mappings[type].Add(action);
    }

    public static void Send<T>(T message)
    {
        if (message == null) throw new ArgumentNullException();

        var type = typeof(T);
        if (!mappings.ContainsKey(type)) return;

        foreach (var listener in mappings[type])
        {
            listener?.DynamicInvoke(message);
        }
    }

    public static void UnRegisterAll(object target)
    {
        var listsOfActions = mappings.Values;

        foreach (var listOfActions in listsOfActions)
        {
            listOfActions.RemoveAll(x => x.Target == target);
        }
    }
}
