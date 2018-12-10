# FID软件架构研究

## 架构

### [STAThread]

每个Thread都有一个关于ApartmentState（线程套间状态）的属性，可以把它设置为STA，MTA，UNKNOW。

当指定一个工程的启动窗口的时候,需要在该窗口类中申明一个Main()方法，并为这个方法设置[STAThread]属性。

[*why*]

## 界面
