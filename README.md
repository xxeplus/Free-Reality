# Free-Reality
# *成员变量和访问修饰符*

~~我的学习计划~~**内卷之王养成计划**

**1.**必须申明在类语句块中

**2.**用来描述对象特征

**3.**可以是任意变量类型

**4.**数量不做限制

**5.**是否赋值根据需求来定

```c#
class program
{
    Console.WriteLine("成员变量和修饰符")；   
}  
```

***

# **成员方法**

**1.**成员方法不要加static关键字

**2.**成员方法必须实测出对象在通过对象中使用

**3.**成员方法受到访问修饰符的影响

***



# **Console控制台窗口**

window->General->console（shift+ctrl+c）

**显示代码编译过程中或者游戏运行过程中的报错、警告、测试信息**

***小狐狸游戏Demo制作***

实现了游戏角色击败敌人的程序和动画

实现了Enemy的移动和动画，让他能够在相应的地点进行固定的移动。

Remake地图添加了更多的元素



﻿﻿# Unity学习入门01学习目标

﻿﻿## C#核心及Unity的入门学习


# 学习内容：初步了解

1.类和对象的定义及理解



2.小狐狸Unity教程Enemy的移动



3.小狐狸操作系统的进一步优化





+++

## **索引器：**可以像数组一样通过索引访问其中元素。



## **制作小狐狸问题BUG总结**

~~游戏开发难啊~~**学习使人快乐**

-01-   在使用不同材质的时候，有时候会人物在移动过程中会消失

sol：但换过材质之后就不会发生这种情况。

---



-02-  刚开始的时候在VS编辑代码的时候并没有出现unity函数的提示项

sol：要在Edit->Preferences->External Tools->unityvs OpenFile

---



-03-  樱桃暴击.在人物碰撞在Cherry时会发生的暴击效果

sol：调整人物的碰撞体体积

---

-04-  人物Crouch动画在调用过程中会出现延迟效果（在Animator中）

sol：刚开始在idle->crouch：crouching(true)  idle(false)—>crouching(true)  

crouch->idle:crouching(flase)—>crouching(false)  idle(true)

---

-05-  在game进行时tilemap会出现裂缝

sol：在Tilemap的transform中修改x=0.99,y=0.99;

禁用抗锯齿     Edit中选中project settings修改Filter Mode(Point (no filter)),然后apply
