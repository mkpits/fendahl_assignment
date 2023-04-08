<%@ page import="java.sql.Connection" %>
<%@ page import="java.sql.DriverManager" %>
<%@ page import="java.sql.PreparedStatement" %>
<%@ page import="java.sql.ResultSet" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Registration form</title>
  <script>
    /*$(document).ready( function() {
      let now = new Date();
      let month = (now.getMonth() + 1);
      let day = now.getDate();
      if (month < 10)
        month = "0" + month;
      if (day < 10)
        day = "0" + day;
      let today = now.getFullYear() + '-' + month + '-' + day;
      $('#datePicker').val(today);
    });

    let today = new Date();
    let dd = String(today.getDate()).padStart(2, '0');
    let mm = String(today.getMonth() + 1).padStart(2, '0');
    let yyyy = today.getFullYear();
    today = mm + '/' + dd + '/' + yyyy;
    document.getElementById(today);*/
  </script>
</head>
<body bgcolor="#5f9ea0">
<%
  String arr[]=new String[4];
  try {
    Class.forName("com.mysql.jdbc.Driver");
    System.out.println("Driver loaded succesfully");
    Connection con = DriverManager.getConnection("jdbc:mysql://localhost:3306/bharti", "root", "Aboli@311");
    System.out.println("database connected successfully");
    PreparedStatement ps= con.prepareStatement("select * from tablenation");
    ResultSet rs=ps.executeQuery();
    while(rs.next()) {
      for(int i=0;i<4;i++){
        arr[i]=rs.getString("Nation_Name");
        System.out.println(arr[i]);
      }
    }
  } catch(Exception e){}
%>
<form action="" method="post">
  <center>
    <table cellspacing="30" bgcolor="#f0f8ff" style="vertical-align: 100px">
      <tr>
        <td colspan="2" align="center"><b>Registration Form</b></td>
      </tr>
      <tr>
        <td>Category : </td>
        <td><input type="radio" name="category" value='0' id="t1" required>Student
        <input type="radio" name="category" value='1' id="t2" required>IT Professional</td>
      </tr>
      <tr>
        <td>Candidate's Full Name : </td>
        <td><input type="text" name="name" t1="t3" maxlength="500" required></td>
      </tr>
      <tr>
        <td>Gender : </td>
        <td><input type="radio" name="Gender" value='0' id="t4" required>Male
          <input type="radio" name="Gender" value='1' id="t5" required>Female
          <input type="radio" name="Gender" value='2' id="t6" required>Other</td>
      </tr>
      <td>Address : </td>
      <td><select name="add" required>
        <option>--Nation--</option>
        <option value="1" id="t7" onclick="">India</option>
        <option value="2" id="t8" onclick="">United-Nation</option>
        <option value="3" id="t9" onclick="">Nepal</option>
        <option value="4" id="t10" onclick="">Sri lanka</option>
      </select></td>
      <tr>
        <td>Total Amount : </td>
        <td><input type="text" name="amt" value='1000' id="t11" readonly></td>
      </tr>
      <tr>
        <td>Paid Amount :</td>
        <td><input type="text" name="paidamt" id="t12"></td>
      </tr>
      <tr>
        <td>Remaining Amount :</td>
        <td><input type="text" name="remamt" id="t13" readonly></td>
      </tr>
      <tr>
        <td>Date :</td>
        <td><input type="date" name="date" id="t14"></td>
      </tr>
      <tr>
        <td><input type="reset" value="Reset"></td>
        <td><input type="submit" value="Save"></td>

      </tr>
    </table>
  </center>
</form>

</body>
</html>