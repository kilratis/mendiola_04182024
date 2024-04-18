# mendiola_04182024
For Exam

Just Clone repo and open it in Visual Studio 2022 or greater
VS will ask you to download bunch of things including docker, if you have docker already installed please make sure that you are using windows container

This API will accept a valid json format. 
I included a swagger documentation so if you run the solution directly on VS you can access the swagger file

API Documentation
Header Parameters:  
ApiKey : [please check the appsettings.json]
Name : Will return how many instance of name inside the json file
file : json file

JSON File Schema sample

[{
  "name": "Elon Zuckerberg",
  "age": 30,
  "email": "john.doe@example.com",
  "address": {
    "street": "123 Main St",
    "city": "Anytown",
    "zipcode": "12345"
  },
  "tags": ["developer", "musician", "gamer"]
},
{
  "name": "Elon Zuckerberg",
  "age": 30,
  "email": "john.doe@example.com",
  "address": {
    "street": "123 Main St",
    "city": "Anytown",
    "zipcode": "12345"
  },
  "tags": ["developer", "musician", "gamer"]
},
{
  "name": "Jun Tek",
  "age": 31,
  "email": "Jun.Tek@example.com",
  "address": {
    "street": "444 Sub St",
    "city": "Anywhere",
    "zipcode": "54321"
  },
  "tags": ["worker", "lawyer", "streamer"]
}]

in this sample if you put Elon Zuckerberg on the header parameter name, the api will return 2 instance

I didn't have the time to create some filtering so I just did a count that uses lambda expression

there is also a save file in the controller so you can save it anywhere, Its not configurable so you need to modify the path inside the code
