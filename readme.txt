Git is a distributed version control system
Git is free software under GPL.



Git Keywords:
init 初始化Git

git config --global user.name "Name"
git config --global user.email "EmaiName@address.add"
mkdir 新建一个目录
cd Location 进入Location位置 Location格式按照Unix格式书写
pwd 打印当前路径
git add 增加一个文件 如果要增加几个文件 可以多次执行此语句
git commit 提交add中在临时空间中的文件 此时会进入Vim通常情况用下文中的输入格式
git commit -m "XXXXXXX" 提交文件并增加说明内容
git status 查看文件状态，有哪些文件被修改过了
git diff 查看文件修改的情况
git log 查看过去的版本的信息
git log --pretty=oneline 可是让信息显示在一行里面
git reset --hard HEAD^ 退回到上一个版本 上两个版本 HEAD^^ 上100个HEAD~100
git reset --hard XXXXX 返回到XXXXX版本号所在的版本可以用作后退之后返回使用
git reflog  版本操作的情况
Git中的重要概念
Working Stage 工作区
Stage 暂存区
Repository 版本库
工作区 add 暂存区 commit 版本库
