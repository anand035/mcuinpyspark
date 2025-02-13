# mcuinpyspark
# Detailed article link [here](https://medium.com/@anand001.desai/run-c-base-ml-library-in-pyspark-94e93a5aa069)

## C# TCP Server
	- Framework: net6.0
	- Export dll
	- Run in Windows terminal linux: dotnet MCUDummyServer.dll &
		- Code: DummyMCUServer
## Java Client
	- MCUClient.java		
## Deployment steps in Azure data bricks cluster
	- Find all the build files of C# project
	- Install dotnet in Init script
	- Add following command to above init script to start server in background in all workers
		- dotnet MCUDummyServer.dll &
	- Upload Jar as library
