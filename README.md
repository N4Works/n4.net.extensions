# n4.net.extensions
<a href="http://n4works.com" target="blank"><img align="right" width="256px" height="256px" src="http://n4works.com/imagens/favicon.ico"></a>


[![Build Status](https://travis-ci.org/N4Works/n4.net.extensions.svg?branch=master)](https://travis-ci.org/N4Works/n4.net.extensions)
[![Build Status](https://ci.appveyor.com/api/projects/status/github/N4Works/n4.net.extensions?branch=master&svg=true)](https://ci.appveyor.com/project/bernardbr/n4-net-extensions)
[![Coverage Status](https://coveralls.io/repos/github/N4Works/n4.net.extensions/badge.svg?branch=master)](https://coveralls.io/github/N4Works/n4.net.extensions?branch=master)
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
