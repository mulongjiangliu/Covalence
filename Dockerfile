FROM microsoft/aspnetcore:1.1
WORKDIR /Covalence
ENV ASPNETCORE_URLS http://+:80
EXPOSE 80
#COPY bin/Release/netcoreapp1.1/publish/ .
#ENTRYPOINT ["dotnet", "run"]
