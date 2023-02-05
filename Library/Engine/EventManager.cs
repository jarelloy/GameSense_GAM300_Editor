using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void CallbackMethod(object sender, object[] args);

public class IEvent
{
    public struct Listener
    {
        public object Sender { get; set; }
        public CallbackMethod Function { get; set; }
        public Listener(object sender, CallbackMethod function)
        {
            Sender = sender;
            Function = function;
        }

    }
    public string Name { get; set; }
    public List<Listener> listeners = new List<Listener>();
    private List<Listener> ToRemove = new List<Listener>();

    public void Broadcast(object[] args)
    {
        foreach (Listener l in listeners)
        {
            l.Function(l.Sender, args);
        }
    }

    public void RemoveListener(object sender, CallbackMethod function)
    {
        List<Listener> ToRemove = new List<Listener>();
        foreach (Listener l in listeners)
        {
            if (l.Sender == sender && l.Function == function)
            {
                ToRemove.Add(l);
            }
        }
    }
    public void RemoveListener(object sender)
    {
        foreach(Listener l in listeners)
        {
            if(l.Sender == sender)
            {
                ToRemove.Add(l);
            }
        }
    }

    public void RemoveUnsubbedListeners()
    {
        foreach (Listener l in ToRemove)
        {
            listeners.Remove(l);
        }
        ToRemove.Clear();
    }
}
public static class EventManager
{
    private static Dictionary<string, IEvent> subscribers = new Dictionary<string, IEvent>();
       
    public static void Subscribe(string message, object sender, CallbackMethod function)
    {
        if(!subscribers.ContainsKey(message))
        {
            IEvent newEvent = new IEvent();
            newEvent.Name = message;
            subscribers.Add(message, newEvent);
        }

        IEvent.Listener listener = new IEvent.Listener(sender, function);
        subscribers[message].listeners.Add(listener);
    }

    public static void UnSubscribe(string message, object sender)
    {
        subscribers[message].RemoveListener(sender);
    }
    public static void UnSubscribe(string message, object sender, CallbackMethod function)
    {
        subscribers[message].RemoveListener(sender, function);
    }

    public static void Broadcast(string message, object[] args = null)
    {
        if(!subscribers.ContainsKey(message))
        {
            Debug.Log("Warning: Event Message \"" + message + "\" does not exists in manager (No one is listening to this message)");
            return;
        }
        subscribers[message].Broadcast(args);
    }

    public static void ClearAllMessages()
    {
        subscribers.Clear();
    }

    public static void RemoveUnSubbedMessages()
    {
        foreach (IEvent e in subscribers.Values)
        {
            e.RemoveUnsubbedListeners();
        }
    }

    public static void RemoveListener(object sender)
    {
        foreach (IEvent e in subscribers.Values)
        {
            e.RemoveListener(sender);
        }
    }
}
