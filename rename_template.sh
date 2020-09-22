#!/bin/bash

find . -iname "*DotNetCoreTemplate*" -exec rename "s/DotNetCoreTemplate/${parameterName}/" {} \;
find . -iname "*DotNetCoreTemplate*" -exec rename "s/DotNetCoreTemplate/${parameterName}/" {} \;

find . | xargs grep -sl "DotNetCoreTemplate" | xargs sed -i "s/DotNetCoreTemplate/${parameterName}/g"
