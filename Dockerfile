# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /apigateway

EXPOSE 85
EXPOSE 5050

COPY ./*.csproj ./
RUN dotnet restore 

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 
WORKDIR /apigateway
COPY --from=build /apigateway/out .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
