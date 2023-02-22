<h1> OpenDocs.AspNetCore</h1>

<p>Wip library</p>

<hr>

<h2><strong>Getting started</strong></h2><br>

<span>Program.cs</span>
```C#
using OpenDocs.AspNetCore;

app.UseOpenDocs(app.Configuration);
```

<span>appsettings.yml</span>
```yml#
OpenDocs:
    Server: http://yourserver.com
    Environment: Development/Testing/Production
    ApplicationName: YourApplicationName
    ClientID: YourClientID
    ClientSecret: YourClientSecret
    SwaggerDocsUrl: Default '/swagger/swagger.json'
    GroupID: YourApplicationGroup 
```
<span>appsettings.json</span>
```json#
OpenDocs: {
    "Server": "http://yourserver.com"
    "Environment": "Development/Testing/Production"
    "ApplicationName": "YourApplicationName"
    "ClientID": "YourClientID"
    "ClientSecret": "YourClientSecret"
    "SwaggerDocsUrl": "Default '/swagger/swagger.json'"
    "GroupID": "YourApplicationGroup"
} 
```