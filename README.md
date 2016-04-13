# n4.net.extensions
<img align="right" width="256px" height="256px" src="http://n4works.com/imagens/favicon.ico">


[![Build Status](https://travis-ci.org/bernardbr/n4.net.extensions.svg?branch=master)](https://travis-ci.org/bernardbr/n4.net.extensions)
[![Coverage Status](https://coveralls.io/repos/github/bernardbr/n4.net.extensions/badge.svg?branch=master)](https://coveralls.io/github/bernardbr/n4.net.extensions?branch=master)
[![NuGet](https://img.shields.io/nuget/v/n4.net.extensions.svg)](https://www.nuget.org/packages/N4.Net.Extensions)

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
