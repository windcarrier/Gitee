Git is a distributed version control system
Git is free software under GPL.
Git has mutable index called stage.
Git tracks changes of files.
Git new branch "div"
<<<<<<< HEAD
Git Creat a new branch and a difference

=======
Vim This is a Vim edit
Git Creating a new branch AND simple IN feature1
>>>>>>> feature1 //This is coflict mark

As a branch I must DO some change


Git Keywords:
init 初始化Git
      git init
      git remote add origin <你的项目地址> //注:项目地址形式为:https://gitee.com/xxx/xxx.git或者 git@gitee.com:xxx/xxx.gi
      如果你想克隆，只需要执行命令
      git clone <项目地址>
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
git 管理的是修改，当输入add时候此时修改了的内容被添加进暂存区，commit命令时，只能把暂存区的内容提交
并不能提交后续修改的内容，后续修改内容都算作修改部分
git checkout -- file 把工作区文件恢复到上次提交的状态
git reset HEAD file 把提交到暂存区的文件撤销
rm  删除一个文件
git rm 在git暂存区中删除一个文件
如果需要删除一个文件，使用git rm 删除文件后 使用 git commit提交删除
如果发现删除错误了 可以使用checkout来恢复
在GitHub托管代码时候需要用到SSH协议
创建SSH协议过程
ssh-keygen -t rsa -C."emailName@add.reg" 会在用户主目录下生成两个文件
id_rsa 和 id_rsa.pub 这就是两个秘钥对 .pub是公钥
git checkout -b dev 创建一个新的分支"div" -b 表示创建并切换
等于 以下两条命令：
git branch dev
git checkout dev
git branch  查看当前分支情况 当前分支前面会有一个*
git checkout BranchName 用于跳转到一个分支
git merge BranchName 将BranchName的文件合并到当前分支
git branch -d BranchName 删除一个分支
当git的几个分支出现冲突时 merge时会显示冲突
此时需要修改冲突的内容然后进行提交从而合并为新的master
git log --graph 可以以图的格式观察合并的情况
如果前期处理过冲突 后来分支和master独立进行修改
但是分支中并没有处理conflict而直接进行修改，然后master 也继续修改的话
合并到master自后 分支的修改将被合并到master中
如果只有一条分支且不冲突的情况下Git默认使用Fast forward格式进行merge
此时如果删除分支 分支信息就会丢掉
如需保留分支信息可以使用--no-ff形式 no Fast forward
这个做法相当于在分支后提交一个新的commit的master
Git 在项目使用的的规则
master分支只用来发布版本时使用
dev分支用来合并和管理更新
每个人有自己独立的brach分支来进行工作
合并*尤其是master与dev*时一般不采用Fast forward形式，因为此种形式看不出合并过
<<<<<<< Updated upstream

=======
Git 管理bug的强大之处
>>>>>>> Stashed changes// stash 命令自动合并之后产生的
git stash 可以用来临时储藏一个未编辑完成的工作
git stash list 可以看有几个stash
恢复工作有两个方法
git stash pop 恢复同时删除stash
git stash prop 恢复stash git stash drop 删除stash
git 中新建一个试验性质的分支 并修改之后 commit之后 如果么有合并
删除时候意味着废弃此次修改 使用 git branch -D BranchName
<<<<<<< HEAD
git 在于远程仓库连接时，最好先使用clone 来建立本地branch 
提交时候如果分支不是master的分支情况，如果需要合并需要使用 
git merge BranchName --allow-unrelated-history
=======
<<<<<<< HEAD
git push -u Name BranchName 用于上传代码
=======
git 在于远程仓库连接时，最好先使用clone 来建立本地branch 
提交时候如果分支不是master的分支情况，如果需要合并需要使用 
git merge BranchName --allow-unrelated-history
git 从远程仓库下载时也会有不是一个分支的情况，此时也需要使用上述语句来强制合并
git 可以通过建立一个.gitignore文件来忽略不想要上传的文件
需要把想要忽略的文件名写到这个文件中就可以了
git 可以就该命令 使用 git config --global alias. SHORTCMD ORIGENCMD
--global指的是修改全局变量， 后面填写短命令和原始命令
来看一个变态的修改lg命令的人的例子
git config --global alias.lg "log --color --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit"
git的配置文件都存储在.git/config文件中 别名等信息需要修改只需要在里面删除即可
后面的内容为在一个Linux系统上搭建Git服务的功能目前还未涉及暂时不考虑学习

>>>>>>> 53eb5e874b822ec27668c8ddd6e8b53cb47f3ac4

