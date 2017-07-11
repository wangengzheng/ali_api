#using

System.Net
System.Net.Security
System.Security.Cryptography.X509Certificates
RestSharp
Newtonsoft.Json


#add references
Newtonsoft.Json.dll
RestSharp.dll




void Main()
{
	//Parent();

    AllList();
	
	//Child("77").Dump();
}

// Define other methods and classes here
private const String host = "http://jisuarea.market.alicloudapi.com";
private const String path = "/area/query";
private const String allPath ="/area/all";
private const String method = "GET";
private const String appcode = "APPCODE 1741d7c96aa84664ba2cf7e********";


public class ReturnStr
{
   public string status{ get; set; }
   public string msg{ get; set; }
   public List<ReturnData> result { get; set; }
}

public class ReturnData
{

  public string id { get; set; }
  public string name { get; set; }
  public string parentid { get; set; }
  public string parentname {get;set;}
  public string areacode { get; set; }
  public string zipcode { get; set; }
  public string depth { get; set; }
}


public List<ReturnData> ParentList()
{
    var client =new RestClient(host);
	
	var request =new RestRequest(allPath,Method.GET);
   
    request.AddHeader("Authorization",appcode);
    	
    var response = client.Execute(request);
    
	//response.Dump();	
	
	if(response.Content!=null)
	{
	  return  JsonConvert.DeserializeObject<ReturnStr>(response.Content).result.Where (r => r.depth=="1" || r.depth=="2").ToList();
	}
	
	return null;
		
}

public List<ReturnData> Child(string parentid)
{

   System.Threading.Thread.Sleep(2000);

   var client =new RestClient(host);
	
	var request =new RestRequest(path,Method.GET);
   
    request.AddHeader("Authorization",appcode);
	
	request.AddParameter("parentid",parentid);
    
    var response = client.Execute(request);
    
	//response.Dump();
	Console.WriteLine (parentid);
	Console.WriteLine (response.Content);
	
	if(response.Content!=null)
	{  
	  var @object =JsonConvert.DeserializeObject<ReturnStr>(response.Content);
	  
	  if(@object==null)
	     return null;
	 
	  return  @object.result;
	}
	
	return null;
}



public List<ReturnData> AllList()
{    
   var data = new List<ReturnData>();
   
   var parent =ParentList();
   
   if(parent==null)
     return null;
	 
   data.AddRange(parent);
   
   var depth2 = parent.Where (p =>p.depth=="2" ).ToList();
   
   if(depth2==null)
      throw new ArgumentNullException("depth2 is null list");

	List<ReturnData> childData = null;  
	  
   	foreach (var element in depth2)
	{
	    childData  = Child(element.id);
		
		if(childData==null)
			continue;
			
	    data.AddRange(childData);
	}
	  
	  
	  
	Console.WriteLine (JsonConvert.SerializeObject(data));
	
	return data;
}


