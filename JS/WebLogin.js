// JScript File 
/*****************************************************
 *
 *
 * Created by: Geary_Tu
 * Modified Date:
 * Modified by:
 * Time: 09:49 AM
 * 
 *  
 ****************************************************/
 
 String.prototype.Trim = function() 
{ 
    return this.replace(/(^\s*)|(\s*$)/g, "");    //delete space
} 
 // check username and password  
 function CHKNamePassword()          
 {
    var Name=document.getElementById("Name").value.Trim();
    var Password=document.getElementById("Password").value.Trim();
	if(document.getElementById("VerifyCode")!=null)
		var VerifyCode=document.getElementById("VerifyCode").value.Trim();
    //alert(Name+Password);
    if(Name=="")
    {
        alert("UserName is Null,Please input and try again!");
        document.getElementById("Name").value="";
        document.getElementById("Name").focus();
        return false;
    }
    else if(Password=="")
    {
        alert("Password is Null,Please input and try again!");
        document.getElementById("Password").value="";
        document.getElementById("Password").focus();
        return false;
    }
	else if(document.getElementById("VerifyCode")!=null)
	{
		if(VerifyCode=="")
		{
		alert("VerifyCode is Null,Please input and try again!")	;
		document.getElementById("VerifyCode").value="";
        document.getElementById("VerifyCode").focus();
		return false;
		}
		else
		{
			if(document.getElementById("VerifyCode").value!=document.getElementById("Code").value)
			{
				alert("VerifyCode Error! Please input again!");
				document.getElementById("VerifyCode").value="";
        		document.getElementById("VerifyCode").focus();
				return false;
			}
		}
		
	}
    else
        return true;
 }
 //reset
 function Reset()
 {
    document.getElementById("Name").value="";
    document.getElementById("Password").value="";
	if(document.getElementById("VerifyCode")!=null)
	{
		document.getElementById("VerifyCode").value="";
	}
    document.getElementById("Name").focus();
    return false;
 }

//Admin_Login verifycode
function getCode()
{
document.getElementById("Code").value=Math.floor(Math.random()*9000) + 1000;
document.getElementById("Name").focus();
}


