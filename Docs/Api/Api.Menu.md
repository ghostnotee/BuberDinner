#### Create Menu Request

````js
POST /hosts/{hostId}/menus
````

````json
{
 "name": "Yummy Menu",
 "description": "A menu with yummy food",
 "sections": [
  {
   "name": "Appetizers",
   "description": "Starters",
   "items": [
    {
     "name": "Fried Pickles",
     "description": "Deep fried pickles",
     "price": 5.99
    }
   ]
  }
 ]
}
````