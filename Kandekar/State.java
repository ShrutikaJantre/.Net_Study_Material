Storing state
1)-ViewData ViewData is derived from the ViewDataDictionary class and is a Dictionary object where Keys are String while Values will be objects.

-While retrieving the data it needs to be Type Cast to its original type
-ViewData is used for passing value from Controller to View
-ViewData is available only for Current Request. value lost on a request redirect

usage 
In Controller
Emp obj1 = new Emp();
ViewData["key1"] = obj1;
ViewData["s"] = "aaa";
ViewData["i"] = 1000;


In View

@{
Emp obj1 = (Emp)ViewData["key1"] 
string s  = ViewData["s"].ToString();
int i = (int)ViewData["i"];
}

2)ViewBag - 
-ViewBag is a Wrapper built around ViewData.
-Dynamic Object
-While retrieving, there is no need for Type Casting data

ViewBag.Prop1 = value;

@ViewBag.Prop1







3)TempData
TempData is derived from the TempDataDictionary class and is a Dictionary object where Keys are String while Values will be objects.
While retrieving the data it needs to be Type Cast to its original type 
TempData is available for Current Request. It will not be destroyed on redirection.
-------------------------------------------------------------



Between requests
4) QueryString (passed values is stored in the url)



5) Session Variables
Available for Session
Session["key"] = value;
to store value ...
Session["i"] = 100;
To read value....
int i = (int)Session["i"];




6) Application variables(common data for all users)
Available across sessions
System.Web.HttpContext.Current.Application["Name"] = "Value";



7) Cookies
HttpCookie objCookie = new HttpCookie("ChocoChip");

objCookie.Expires = DateTime.Now.AddDays(1);
objCookie.Value = "a";

//objCookie.Values["key1"] = "a";
//objCookie.Values["key2"] = "b";

Response.Cookies.Add(objCookie);



read a cookie
HttpCookie objCookie = Request.Cookies["ChocoChip"];
//null if not present
string s;
s = objCookie.Value;
//s = objCookie.Values["key1"];



delete a cookie
HttpCookie objCookie = new HttpCookie("ChocoChip");

objCookie.Expires = DateTime.Now.AddDays(-1);

Response.Cookies.Add(objCookie);



