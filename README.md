To run this install Docker-CE and run docker-compose up in the root folder

follow this tutorial to setup https https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/aspnetcore-docker-https.md
change the volumes in docker-compose from 

      - ~/.microsoft/usersecrets/:/root/.microsoft/usersecrets
      - ~/.aspnet/https:/root/.aspnet/https/

to 

      - %USERPROFILE%\.aspnet\https/:/root/.aspnet/https/
and

      ASPNETCORE_Kestrel__Certificates__Default__Password=crypticpassword
to your cert passkey



You need to have npm installed and run npm install in the wwwroot folder for the reactive interfaces. Working on automating this and including it in the docker build, but I wanted to remove the libraries from the repository.
