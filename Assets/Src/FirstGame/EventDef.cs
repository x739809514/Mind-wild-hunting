using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventDef 
{
    PhoneCallChange=0,    //接打电话状态
    CookBoxCountChange=1, //做菜事件改变
    CookDragEnd=2,        //做菜拖拽事件
    WeChatMsgChange=3,    //微信消息发送事件
    WeChatBackMsgChange=4,//微信回消息
}
