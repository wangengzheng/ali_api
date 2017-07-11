const String host = "http://jisutianqi.market.alicloudapi.com";
private const String path = "/weather/query";
private const String method = "GET";
private const String appcode = "1741d7c96aa84664ba2cf7******";

static void Main(string[] args)
{
	String querys = "city=中山";
	String bodys = "";
	String url = host + path;
	HttpWebRequest httpRequest = null;
	HttpWebResponse httpResponse = null;

	if (0 < querys.Length)
	{
		url = url + "?" + querys;
	}

	if (host.Contains("https://"))
	{
		ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
		httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
	}
	else
	{
		httpRequest = (HttpWebRequest)WebRequest.Create(url);
	}
	httpRequest.Method = method;
	httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
	if (0 < bodys.Length)
	{
		byte[] data = Encoding.UTF8.GetBytes(bodys);
		using (Stream stream = httpRequest.GetRequestStream())
		{
			stream.Write(data, 0, data.Length);
		}
	}
	try
	{
		httpResponse = (HttpWebResponse)httpRequest.GetResponse();
	}
	catch (WebException ex)
	{
		httpResponse = (HttpWebResponse)ex.Response;
	}

	Console.WriteLine(httpResponse.StatusCode);
	Console.WriteLine(httpResponse.Method);
	Console.WriteLine(httpResponse.Headers);
	Stream st = httpResponse.GetResponseStream();
	StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
	Console.WriteLine(reader.ReadToEnd());
	Console.WriteLine("\n");

}

public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
{
	return true;
}Define other methods and classes here
private const String host = "http://jisutianqi.market.alicloudapi.com";
private const String path = "/weather/query";
private const String method = "GET";
private const String appcode = "1741d7c96aa84664ba2cf7e13bc0bd6a";

static void Main(string[] args)
{
	String querys = "city=中山";
	String bodys = "";
	String url = host + path;
	HttpWebRequest httpRequest = null;
	HttpWebResponse httpResponse = null;

	if (0 < querys.Length)
	{
		url = url + "?" + querys;
	}

	if (host.Contains("https://"))
	{
		ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
		httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
	}
	else
	{
		httpRequest = (HttpWebRequest)WebRequest.Create(url);
	}
	httpRequest.Method = method;
	httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
	if (0 < bodys.Length)
	{
		byte[] data = Encoding.UTF8.GetBytes(bodys);
		using (Stream stream = httpRequest.GetRequestStream())
		{
			stream.Write(data, 0, data.Length);
		}
	}
	try
	{
		httpResponse = (HttpWebResponse)httpRequest.GetResponse();
	}
	catch (WebException ex)
	{
		httpResponse = (HttpWebResponse)ex.Response;
	}

	Console.WriteLine(httpResponse.StatusCode);
	Console.WriteLine(httpResponse.Method);
	Console.WriteLine(httpResponse.Headers);
	Stream st = httpResponse.GetResponseStream();
	StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
	Console.WriteLine(reader.ReadToEnd());
	Console.WriteLine("\n");

}

public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
{
	return true;
}
