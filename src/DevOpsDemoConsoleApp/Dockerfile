FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

ENTRYPOINT ["dotnet", "run"]

