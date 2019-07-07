# DBProject
先创建表 people(sid varchar, skey varchar, rem_check INT) 
      表Flight_Chart(字段和文档一致,出了Flight_ID和Plane_ID为Varchar外,其他字段都为INT)
      表Seating_Chart(Flight_ID varchar,Seat_Number INT,Customer_ID varchar,Seat_State INT)
      然后数据随意插入
      
更改Models/ConnectionFactory.cs中的 CreateConnection方法的 connString

Views/ChooseFlight/Flight.cshtml不可以直接运行,需要先运行同目录下的ChooseFlightcshtml然后再点击跳转过去
UserList同理(这个文件夹我用来做测试,没有用)
其他页面均可直接运行
