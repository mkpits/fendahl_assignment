<%@ page import="java.sql.*" %>
<%@ page import="java.util.Date" %><%--
  Created by IntelliJ IDEA.
  User: hp
  Date: 4/8/2023
  Time: 3:24 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>registration_process</title>
</head>
<body>
<%
    int category_id=Integer.parseInt(request.getParameter("category"));
    String name=request.getParameter("name");
    int Gender=Integer.parseInt(request.getParameter("Gender"));
    int nation_id=Integer.parseInt(request.getParameter("add"));
    float total_amount=Float.parseFloat(request.getParameter("amt"));
    float paid_amount=Float.parseFloat(request.getParameter("paidamt"));
    float remaining_amt=Float.parseFloat(request.getParameter("remamt"));
    java.sql.Date date = java.sql.Date.valueOf(request.getParameter("date"));
    System.out.println(date);
    try {
        Class.forName("com.mysql.jdbc.Driver");
        System.out.println("Driver loaded succesfully");
        Connection con = DriverManager.getConnection("jdbc:mysql://localhost:3306/bharti", "root", "Aboli@311");
        System.out.println("database connected successfully");
        PreparedStatement ps=con.prepareStatement("INSERT INTO tablecourseregdetail(CategoryInd,FullName,GenderInd) values (?,?,?)");
        ps.setInt(1,category_id);
        ps.setString(2,name);
        ps.setInt(3,Gender);
        int result=ps.executeUpdate();
        PreparedStatement ps1=con.prepareStatement("select CourseRegID from tablecourseregdetail ORDER BY CourseRegID DESC LIMIT 1");
        ResultSet r= ps1.executeQuery();
        int r1=r.getInt("CourseRegID");
        PreparedStatement ps2=con.prepareStatement("INSERT INTO tableregaddress(CourseRegID,NationID) values (?,?)");
        ps2.setInt(1,r1);
        ps2.setInt(2,nation_id);
        int result1=ps2.executeUpdate();
        PreparedStatement ps3=con.prepareStatement("INSERT INTO tablefeedetail(CourseRegID,TotalAmount,MinPer,PaidAmount,BalAmount,PaidDate) values (?,?,?,?,?,?)");
        ps3.setInt(1,r1);
        ps3.setFloat(2,total_amount);
        if(category_id==0)
            ps3.setFloat(3,500);
        else
            ps3.setFloat(3,2400);
        ps3.setFloat(4,paid_amount);
        ps3.setFloat(5,remaining_amt);
        ps3.setDate(6,date);
        int result2=ps3.executeUpdate();

    } catch(Exception e){}
%>
</body>
</html>
