# README
## Week 3 — REST  



### Function  
#### Intended function
REST-API which can read CSV files and populate a database with them, and have a web interface through which one can perform database queries.  
#### Current function
- Can read CSV files into program as table.



### Formats  
Program assumes supplied CSV file be in a format where rows are separated by line-breaks, and columns are separated by semicolon (;). 



### Design and design decisions  
Project opened using Visual Studio's REST API template.  

#### DataBaseConnector
Class DataBaseConnector is in charge of connecting to the database and performing commands, with all CRUD functions.  
This class should disallow access to commands depending on user authority level. Three access levels: READ-ONLY, NONE and ALL.  
DataBaseConnector performs its own checks with regards to whether commands are allowed or if another command should be performed in its stead, 
such as adhering to the rule that new entries cannot have a set ID, and an attempt at making an entry with an existing ID should update the 
existing entry instead.  

#### User (name pending; class unimplemented)
Separate class to determine user's level. This class to perform salt-and-hash as static method?  
How to log in to user before getting database access? Login method in DataBaseConnector?  

#### FileReader
FileReader class reads CSV file from set or default location. Multiple CSV files possible; must manually enumerate over them.  
Filereader returns table, a collection of collections of strings, which can be slotted into database.  