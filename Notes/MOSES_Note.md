# MOSES 学习笔记

## MOSES中的装载定义

```MOSES
&select :CTANK -select \
COT1P \
COT2P \
COT3P \
COT4P \
COT5P \
COT1S \
COT2S \
COT3S \
COT4S \
COT5S
```
&select :CTANK -selcet \
其中select是用来定义一个装载舱室的分组的,舱室名称在dat数据中定义，最后一个舱室不写\


```MOSES
&cmp_bal :ATANK -limit 3 98
```
&cmp_bal 用来设置MOSES自动调节压载的舱室