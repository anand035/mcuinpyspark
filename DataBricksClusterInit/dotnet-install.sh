#!/bin/sh

echo "installing .NET for Ubuntu 18.04x64 that is the OS for Databricks Runtime 7.0+ as per"
echo "  https://docs.microsoft.com/en-us/azure/databricks/release-notes/runtime/7.0#system-environment"
echo "  and https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#1804-"

wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update -y
sudo apt-get install -y apt-transport-https
sudo apt-get update -y
sudo apt-get install -y dotnet-runtime-6.0
dotnet DummyMCUServer.dll &
