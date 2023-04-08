<%@ page import="java.sql.Connection" %>
<%@ page import="java.sql.DriverManager" %>
<%@ page import="java.sql.PreparedStatement" %><%--
  Created by IntelliJ IDEA.
  User: Bharat
  Date: 08-04-2023
  Time: 14:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<h1>SuccessFully Submitted</h1>
<%

    String name = request.getParameter("name");
    String pass = request.getParameter("gen");
    String role = request.getParameter("address");

    // to retrive name gen address


    try {
        Class.forName("com.mysql.jdbc.Driver");//Driver Loaded
        System.out.println("driver loaded successfully");
        Connection con = DriverManager.getConnection("jdbc:mysql://localhost:3306/interview_data", "root", "Pass@123");
        System.out.println("Databased loaded succesfully");
       // con.prepareStatement("select insert *from interview_data where tablecity name=?, ");
        PreparedStatement ps = con.prepareStatement("insert into student_info(Name,Gender,Address) values (?,?,?)");


    }catch (Exception e){
        System.out.println(e);
    }




    response.sendRedirect("Success.jsp");
    /*
    
     */







%>
</body>
</html>
