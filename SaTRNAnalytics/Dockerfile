#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM sres.web.boeing.com:5000/dotnet/core/sdk:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM sres.web.boeing.com:5000/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["SaTRNAnalytics/SaTRNAnalytics.csproj", "SaTRNAnalytics/"]
RUN dotnet restore "SaTRNAnalytics/SaTRNAnalytics.csproj"
COPY . .
WORKDIR "/src/SaTRNAnalytics"
RUN dotnet build "SaTRNAnalytics.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SaTRNAnalytics.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SaTRNAnalytics.dll"]