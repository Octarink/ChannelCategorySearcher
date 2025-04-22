FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ChanelCategorySearcher.sln ./
COPY ChanelCategorySearcher.WebApi/*.csproj ./ChanelCategorySearcher.WebApi/
COPY ChanelCategorySearcher.DAL/*.csproj ./ChanelCategorySearcher.DAL/
COPY ChanelCategorySearcher.BusinessLogic/*.csproj ./ChanelCategorySearcher.BusinessLogic/

RUN dotnet restore "ChanelCategorySearcher.sln"
COPY . .
RUN dotnet build -c Release -o /app/publish 

FROM build AS publish
WORKDIR "/src/ChanelCategorySearcher.WebApi"
RUN dotnet publish "ChanelCategorySearcher.WebApi.csproj" -c Release -o /app/publish --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChanelCategorySearcher.WebApi.dll"]