# Vulnerable Dot Net HTTP Remoting Project

This repository contains a vulnerable C# application (client/server) that uses .NET Remoting over HTTP. This can be used for testing purposes and can be compiled using different versions of .NET Framework.

It also includes a copy of [ysoserial.net](https://github.com/pwntester/ysoserial.net/) (15/03/2018) that has been changed to work with .NET Framework 2.0 by [irsdl](https://twitter.com/irsdl). Although this project can be used to exploit applications that use .NET Framework v2.0, it also requires .NET Framework 3.5 to be installed on the target box as the gadgets depend on it. This problem will be resolved if new gadgets in .NET Framework 2.0 become identified in the future.

## Research:

Please refer to [NCC Group's blog](https://www.nccgroup.trust/uk/about-us/newsroom-and-events/blogs/2019/march/finding-and-exploiting-.net-remoting-over-http-using-deserialisation/)

## Copyright and License
This project is copyright 2019, NCC Group, and licensed under the Apache license (see LICENSE).
