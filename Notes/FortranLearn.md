# Fortran语言学习

## Fortran简介

Fortran源自于“公式翻译”（英语：FormulaTranslation）的缩写，是一种编程语言。它是世界上最早出现的计算机高级程序设计语言，广泛应用于科学和工程计算领域。FORTRAN语言以其特有的功能在数值、科学和工程计算领域发挥着重要作用。Fortran 90之前的版本是人们所知晓的FORTRAN（全部字母大写），从Fortran 90以及以后的版本都写成Fortran（仅有第一个字母大写）

### 特性编辑

Fortran语言的最大特性是接近数学公式的自然描述，在计算机里具有很高的执行效率。  
易学，语法严谨。  
可以直接对矩阵和复数进行运算，这一点类似MATLAB。  
自诞生以来广泛地应用于数值计算领域，积累了大量高效而可靠的源程序。  
很多专用的大型数值运算计算机针对Fortran做了优化。  
广泛地应用于并行计算和高性能计算领域。  
Fortran 90，Fortran 95，Fortran 2003的相继推出使Fortran语言具备了现代高级编程语言的一些特性  

### 程序包

几个著名的Fortran程序包：  

IMSL--国际数学和统计链接库  
BLAS--Basic Linear Algebra Subroutines  
LAPACK--Linear Algebra PACKage  

### 发展趋势编辑

Fortran语言是一种极具发展潜力的语言，在全球范围内流行过程中，Fortran语言的标准化不断吸收现代化编程语言的新特性，并且在工程计算领域仍然占有重要地位。  
Fortran语言与程序化语言JAVA,C#等高级语言相比，它缺乏创造力。但是，由于很多优秀的工程计算软件都是运用Fortran语言编写，例如ANSYS、Marc，为了能够使用这些商业软件的高级功能，用户必须先学会Fortran语言，才能编写应用程序接口。由此决定了Fortran在工程计算领域将长期处于统治地位。  
在数值计算中，Fortran语言仍然不可替代。Fortran 90标准引入了数组计算等非常利于矩阵运算的功能。在数组运算时，Fortran能够自动进行并行运算，这是很多编程语言不具备的。运用Fortran语言，用户能够运用很多现成的函数软件包，所以非常便利。（MATLAB的早期版本，主要就是为两个著名的Fortran函数包提供程序接口。）

## Fortran语法基础

**If...then**语句

### 关系运算符

