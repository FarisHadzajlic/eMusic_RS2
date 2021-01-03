FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5050
ENV ASPNETCORE_URLS=http://+:5050

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "eMusic" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD ./eMusic/Files ./Files

ENTRYPOINT ["dotnet", "eMusic.dll"]