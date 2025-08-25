# Build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY Sample_API.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /out /p:UseAppHost=false

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 5000
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Sample_API.dll"]
