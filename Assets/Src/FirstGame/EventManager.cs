using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager
{
    public delegate void NotificationDelegate(Notification notice);

    private static EventManager instance;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }

            return instance;
        }
    }

    //存放消息的字典类
    private Dictionary<uint, NotificationDelegate> eventListeners = new Dictionary<uint, NotificationDelegate>();

    /// <summary>
    /// 是否存在事件的监听器
    /// </summary>
    /// <param name="eventKey"></param>
    /// <returns></returns>
    public bool HasEventListener(uint eventKey)
    {
        return eventListeners.ContainsKey(eventKey);
    }

    /// <summary>
    /// 添加监听者
    /// </summary>
    public void AddEventListener(uint eventkey, NotificationDelegate listener)
    {
        //添加一个空位
        if (!HasEventListener(eventkey))
        {
            NotificationDelegate del = null;
            eventListeners[eventkey] = del;
        }

        eventListeners[eventkey] += listener;
    }
    
    /// <summary>
    /// 移除监听者
    /// </summary>
    /// <param name="evenkey"></param>
    /// <param name="listener"></param>
    public void RemoveEventListener(uint evenkey, NotificationDelegate listener)
    {
        if (!HasEventListener(evenkey))
            return;
        eventListeners[evenkey] -= listener;
        //清除该位置
        if (eventListeners[evenkey] == null)
        {
            RemoveEventListener(evenkey);
        }
    }

    public void RemoveEventListener(uint eventkey)
    {
        eventListeners.Remove(eventkey);
    }
    
    /// <summary>
    /// 分发事件，不需要知道发送者
    /// </summary>
    /// <param name="eventkey"></param>
    /// <param name="notific"></param>
    public void Dispatch(uint eventkey, Notification notific)
    {
        if (!HasEventListener(eventkey))
        {
            return;
        }

        eventListeners[eventkey](notific);
    }
    
    /// <summary>
    /// 分发事件 需要知道发送者，具体消息情况
    /// </summary>
    /// <param name="eventkey"></param>
    /// <param name="sender"></param>
    /// <param name="param"></param>
    public void Dispatch(uint eventkey, GameObject sender, EventArgs param)
    {
        if (!HasEventListener(eventkey))
        {
            return;
        }
        eventListeners[eventkey](new Notification(sender,param));
    }

    public void Dispatch(uint eventkey)
    {
        if (!HasEventListener(eventkey))
        {
            return;
        }
        eventListeners[eventkey](new Notification());
    }

    public void Dispatch(uint eventkey, EventArgs param)
    {
        if (!HasEventListener(eventkey))
        {
            return;
        }
        eventListeners[eventkey](new Notification(param));
    }
}