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
