# PersonList_webAPI_.NET
<h2>ABOUT</h2>
<p>Application contains only endpoints for create/get/update/delete http actions and paging. </p>
<p>Every endpoint is returning specified type:<br/>"apiResponse": { <br/> &nbsp &nbsp "statusCode": "string",<br/> &nbsp &nbsp "isSuccess": "bool",<br/> &nbsp &nbsp "errorList": "string",<br/> &nbsp &nbsp "result": "object"<br/> }.</p>
<p>To start this aplicattion it is neccessary to change people.json file path in <strong>personlist.Infrastructure.Seeders.PersonSeeder</strong>.</p>
<h2>TECH</h2>
<ul>
  <li>.NET 7</li>
  <li>Entity Framework</li>
  <li>CQRS</li>
  <li>C# 11</li>
  <li>Clean architecture</li>
</ul>

