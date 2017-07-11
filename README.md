#aliyun api

##area code 全国省市县行政区划查询接口

``` python
import urllib, urllib2, sys


host = 'http://jisuarea.market.alicloudapi.com'
path = '/area/all'
method = 'GET'
appcode = '你自己的AppCode'
querys = ''
bodys = {}
url = host + path

request = urllib2.Request(url)
request.add_header('Authorization', 'APPCODE ' + appcode)
response = urllib2.urlopen(request)
content = response.read()
if (content):
    print(content)
```
