#aliyun api

##area code ȫ��ʡ��������������ѯ�ӿ�

``` python
import urllib, urllib2, sys


host = 'http://jisuarea.market.alicloudapi.com'
path = '/area/all'
method = 'GET'
appcode = '���Լ���AppCode'
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
