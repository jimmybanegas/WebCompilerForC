<!DOCTYPE html>
<html>
<head>
<title>Web Compiler For C</title>
</head>
<body>
<div>
<h1>Compiladores I</h1>
<p>Proyecto Compilador web para C</p>

<form enctype="multipart/form-data" method="post">
  First element :<br>
  <input type="text" name="firstelement"><br>
  Second element :<br>
  <input type="text" name="secondelement"> <br>

  <input type="radio" name="operation" value="Addition" checked> Addition <br>
  <input type="radio" name="operation" value="Substraction"> Substraction <br>
  <input type="radio" name="operation" value="Multiplication"> Multiplication <br>
  <input type="radio" name="operation" value="Division"> Division  <br>

  <input type="submit" value="Calculate">
</form> 

<%  
  int firstelement ;
  int secondelement;
%>

</div>
</body>
</html>