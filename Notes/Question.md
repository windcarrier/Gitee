# 问题及解决

## 使用LocalDB时Web.config连接字符的设置问题

### Film的modle代码

```c#
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFilmTest.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
    public class FilmDBContext : DbContext
    {
        public DbSet<Film> FilmdbSet { get; set; }
    }
}
```

### Web.config

```xml
  <connectionStrings>
    <add name="FilmDBContext"
   connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-MVCFilmTest;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\FilmDB.mdf"
   providerName="System.Data.SqlClient"/>
  </connectionStrings>
```

### 明细

name为model中数据库类的类名
Data Source 指的数据库类型
Integrated Security 指的是登陆类型，此处跟写“True”作用一样，就是可以以windows 身份登录，每次登录你就不用输账号密码了。如果是“false”就是指的sql server方式登录就要账号密码齐全。
Initial Catalog属性就是初始数据库名称
其中AttachDBFilename指的是一个路径，放mdf文件的地方，上面的写法是指的该文件放在自己工程的 App_Data文件夹下面