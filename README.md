# n4.net.extensions

[![Build Status](https://travis-ci.org/bernardbr/n4.net.extensions.svg?branch=master)](https://travis-ci.org/bernardbr/n4.net.extensions)

A collection of useful type extensions provided by N4Works.com for .net

__USAGE:__

__*IDataReader extension:*__
```csharp
using (var dataReader = ExecuteReader(command))
{
    IPerson person = new Person();
    
    person.Name = dataReader.GetFieldValue<string>("PersonName");
    
    return person;
}
```
