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

+++















